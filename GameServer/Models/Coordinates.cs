﻿using System;
namespace GameServer.Models
{
    public class Coordinates
    {
        public long x { get; set; }
        public long y { get; set; }

        public Coordinates(long x, long y)
        {
            this.x = x;
            this.y = y;
        }
        public Coordinates(int x, int y)
        {
            this.x = x;
            this.y = y;
        }
    }
}
