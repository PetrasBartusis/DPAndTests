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
                case SpiderTypes.normal: enemy = new Enemies.Spider("normal spider", 10, difficultyLevel * ATT, difficultyLevel * DEF); break;
                case SpiderTypes.giant: enemy = new Enemies.GiantSpider("giant spider", 20, difficultyLevel * ATT, difficultyLevel * DEF); break;
                case SpiderTypes.poison: enemy = new Enemies.PoisonSpider("poison spider", 10, difficultyLevel * ATT, difficultyLevel * DEF); break;
            }
            return enemy;
        }
    }
	
}
