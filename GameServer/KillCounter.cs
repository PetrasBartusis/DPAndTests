using System;
using System.Collections.Generic;

namespace GameServer
{
    public class KillCounter : ICloneable
    {
        public int killCount { get; private set; }
        public KillCounter()
        {
            killCount = 0;
        }
        public void Increment()
        {
            killCount++;
        }

        public object Clone()
        {
            return this.MemberwiseClone();
        }
    }
}
