using OBS.Model;
using System;
using System.Collections.Generic;
using System.Threading;

namespace OBS.Internal
{

    internal class ThreadSafeTransferStreamByBytes : TransferStreamManager
    {

        protected readonly object _lock = new object();
        protected bool flag = false;

        public ThreadSafeTransferStreamByBytes(object sender, EventHandler<TransferStatus> handler, long totalBytes,
            long transferredBytes, double intervalByBytes) : base(sender, handler, totalBytes, transferredBytes)
        {
            this.interval = intervalByBytes;
        }

        public override void TransferStart()
        {
            if (!flag)
            {
                lock (_lock)
                {
                    flag = true;
                    base.TransferStart();
                }
            }
        }

        public override void TransferReset(long resetBytes)
        {
            Interlocked.Add(ref transferredBytes, -resetBytes);
        }

        public override void TransferEnd()
        {
            lock (_lock){
                base.TransferEnd();
            }
        }

        protected override void DoBytesTransfered(int bytes)
        {
            Interlocked.Add(ref transferredBytes, bytes);
            Interlocked.Add(ref newlyTransferredBytes, bytes);
            DateTime now = DateTime.Now;
            IList<BytesUnit> currentInstantaneousBytes = this.CreateCurrentInstantaneousBytes(bytes, now);
            this.lastInstantaneousBytes = currentInstantaneousBytes;
            // 并发请求下最后一段不汇报，交由上层处理。
            long _newlyTransferredBytes = Interlocked.Read(ref newlyTransferredBytes);
            long _transferredBytes = Interlocked.Read(ref transferredBytes);
            if (_newlyTransferredBytes >= this.interval && _transferredBytes < totalBytes)
            {
                if (Interlocked.CompareExchange(ref newlyTransferredBytes, 0, _newlyTransferredBytes) == _newlyTransferredBytes)
                {
                    TransferStatus status = new TransferStatus(_newlyTransferredBytes,
                       _transferredBytes, totalBytes, (now - lastCheckpoint).TotalSeconds, (now - startCheckpoint).TotalSeconds);
                    status.SetInstantaneousBytes(currentInstantaneousBytes);
                    handler(sender, status);
                    lastCheckpoint = now;
                }
            }
        }
    }


    internal class ThreadSafeTransferStreamBySeconds : ThreadSafeTransferStreamByBytes
    {

        private Timer timer;

        public ThreadSafeTransferStreamBySeconds(object sender, EventHandler<TransferStatus> handler, long totalBytes,
            long transferredBytes, double intervalBySeconds) : base(sender, handler, totalBytes, transferredBytes, intervalBySeconds)
        {
            
        }

        public void DoRecord(object state)
        {
            DateTime now = DateTime.Now;
            long _transferredBytes = Interlocked.Read(ref transferredBytes);
            if (_transferredBytes < this.totalBytes)
            {
                long _newlyTransferredBytes = Interlocked.Read(ref newlyTransferredBytes);
                TransferStatus status = new TransferStatus(_newlyTransferredBytes,
                    _transferredBytes, totalBytes, interval, (now - startCheckpoint).TotalSeconds);
                handler(sender, status);
                // Reset
                Interlocked.Add(ref newlyTransferredBytes, -_newlyTransferredBytes);
                lastCheckpoint = now;
            }
        }

        public override void TransferStart()
        {
            if (!flag)
            {
                lock (_lock)
                {
                    flag = true;
                    startCheckpoint = DateTime.Now;
                    lastCheckpoint = DateTime.Now;
                    timer = new Timer(this.DoRecord, null, 0, Convert.ToInt32(this.interval * 1000));
                }
            }
        }

        public override void TransferEnd()
        {
            lock (_lock)
            {
                timer?.Dispose();
                DateTime now = DateTime.Now;
                TransferStatus status = new TransferStatus(Interlocked.Read(ref newlyTransferredBytes),
                              Interlocked.Read(ref transferredBytes), totalBytes, (now - lastCheckpoint).TotalSeconds, (now - startCheckpoint).TotalSeconds);
                handler(sender, status);
            }
        }

        protected override void DoBytesTransfered(int bytes)
        {

            Interlocked.Add(ref transferredBytes, bytes);
            Interlocked.Add(ref newlyTransferredBytes, bytes);
        }
    }
}
