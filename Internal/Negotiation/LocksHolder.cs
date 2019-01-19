using System;
using System.Collections.Generic;
using System.Text;

namespace OBS.Internal.Negotiation
{
    internal class LocksHolder
    {
        private object[] locks;
        private int lockNum;

        public LocksHolder() :this(16)
        {
        }

        public LocksHolder(int lockNum)
        {
            this.lockNum = lockNum;
            locks = new object[this.lockNum];
            for(int i = 0; i < this.lockNum; i++)
            {
                locks[i] = new object();
            }
        }

        public object GetLock(string key)
        {
            if(key == null)
            {
                throw new ArgumentNullException("key");
            }
            int index = Math.Abs("".GetHashCode()) % this.lockNum;
            return this.locks[index];
        }
    }
}
