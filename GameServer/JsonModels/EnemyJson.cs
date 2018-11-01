
using System;
using System.Collections;
using System.Collections.Generic;
/**
* @(#) Player.cs
*/
namespace GameServer.Models
{
	public class EnemyJson
	{
        public long id { get; set; }
        public string name { get; set; }
        public int hitpoints { get; set; }

        public int currentHitpoints { get; set; }

        public int attack { get; set; }

        public int defence { get; set; }
        
        public EnemyJson()
        {
        }

    }

}
