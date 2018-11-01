/**
 * @(#) SpiderFactory.cs
 */

using System;

namespace GameServer.EnemyFactory
{
	public class SpiderFactory
    {
        public Entity createSpider(int difficultyLevel)
        {
            Entity enemy;
            const int ATT = 2;
            const int DEF = 4;

            Random rand = new Random();
            int type = rand.Next(0, 1);
            switch (type)
            {
                default:
                case 0: enemy = new Enemies.Spider("normal spider", 10, ATT, DEF); break;
                case 1: enemy = new Enemies.GiantSpider("giant spider", 20, ATT, DEF); break;
                //case 2: enemy = new Enemies.Spider("poison spider", 10, ATT, DEF); break;
            }
            return enemy;
        }
    }
	
}
