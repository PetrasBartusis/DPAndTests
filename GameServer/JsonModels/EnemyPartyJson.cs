
using System;
using System.Collections;
using System.Collections.Generic;
/**
* @(#) Player.cs
*/
namespace GameServer.Models
{
    public class EnemyPartyJson
    {
        public long id { get; set; }

        public ICollection<EnemyJson> enemies { get; set; }

        public long x { get; set; }
        public long y { get; set; }

        public EnemyPartyJson()
        {
        }

    }

}
