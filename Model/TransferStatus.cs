using OBS.Internal;
using System;
using System.Collections.Generic;
using System.Text;

namespace OBS.Model
{
    /// <summary>
    /// 数据传输状态。
    /// </summary>
    public class TransferStatus : EventArgs
    {
        private long _newlyTransferredBytes;
        private long _transferredBytes;
        private long _totalBytes;
        private double _intervalSeconds;
        private double _totalSeconds;
        private IList<BytesUnit> _instantaneousBytes;

        internal TransferStatus(long newlyTransferredBytes, long transferredBytes, long totalBytes,
            double intervalSeconds, double totalSeconds)
        {
            this._newlyTransferredBytes = newlyTransferredBytes;
            this._transferredBytes = transferredBytes;
            this._totalBytes = totalBytes;
            this._intervalSeconds = intervalSeconds;
            this._totalSeconds = totalSeconds;
        }

        internal void SetInstantaneousBytes(IList<BytesUnit> instantaneousBytes)
        {
            this._instantaneousBytes = instantaneousBytes;
        }

        /// <summary>
        /// 瞬时速率。
        /// </summary>
        public double InstantaneousSpeed
        {
            get {
                if(this._instantaneousBytes != null)
                {
                    long instantaneousSpeed = 0;
                    foreach (BytesUnit item in this._instantaneousBytes)
                    {
                        instantaneousSpeed += item.Bytes;
                    }
                    return instantaneousSpeed;
                }
                return this._newlyTransferredBytes / this._intervalSeconds;
            }
        }

        /// <summary>
        /// 平均速率。
        /// </summary>
        public double AverageSpeed
        {
           get { return this._transferredBytes / this._totalSeconds; }
        }

        /// <summary>
        /// 传输进度。
        /// </summary>
        public int TransferPercentage
        {
            get {
                if(this._totalBytes < 0)
                {
                    return -1;
                }else if(this._totalBytes == 0)
                {
                    return 100;
                }
                return (int)((this._transferredBytes * 100) / this._totalBytes);
            }
        }

        /// <summary>
        /// 新增的字节数。
        /// </summary>
        public long NewlyTransferredBytes
        {
            get { return this._newlyTransferredBytes; }
        }

        /// <summary>
        /// 已传输的字节数。
        /// </summary>
        public long TransferredBytes
        {
            get { return this._transferredBytes; }
        }

        /// <summary>
        /// 待传输的总字节数。
        /// </summary>
        public long TotalBytes
        {
            get { return this._totalBytes; }
        }

    }
}
