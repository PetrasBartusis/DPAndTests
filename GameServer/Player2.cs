
using System;
using System.Collections;
using System.Collections.Generic;
/**
* @(#) Player.cs
*/
namespace GameServer.Models
{
	public class Player2
	{
		public int level { get; set; }

        public int experience { get; set; }

        public int gold { get; set; }

        public long id { get; set; }

        public string name { get; set; }

        public int hitpoints { get; set; }

        public int currentHitpoints { get; set; }

        public int attack { get; set; }

        public int defence { get; set; }

        public long x { get; set; }
        public long y { get; set; }

        public Player2()
        {
        }

    }

}
