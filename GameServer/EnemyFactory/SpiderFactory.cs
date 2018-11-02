/**
 * @(#) SpiderFactory.cs
 */

using System;

namespace GameServer.EnemyFactory
{
	public class SpiderFactory
    {
        public static Entity createSpider(SpiderTypes type, int difficultyLevel)
        {
            Entity enemy;
            const int ATT = 2;
            const int DEF = 4;

            switch (type)
            {
                default:
                case SpiderTypes.normal: enemy = new Enemies.Spider("normal spider", 10, ATT, DEF); break;
                case SpiderTypes.giant: enemy = new Enemies.GiantSpider("giant spider", 20, ATT, DEF); break;
                //case 2: enemy = new Enemies.Spider("poison spider", 10, ATT, DEF); break;
            }
            return enemy;
        }
    }
	
}
