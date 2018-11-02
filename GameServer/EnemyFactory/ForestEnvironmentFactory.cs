using System;
using System.Collections.Generic;

namespace GameServer.EnemyFactory
{
    public class ForestEnvironmentFactory : EnemyFactory
    {
        public ForestEnvironmentFactory() { }

        public override Entity createAvarageEnemy()
        {
            return SpiderFactory.createSpider(SpiderTypes.giant, EnemyFactory.DIFF_MEDIUM);
        }

        public override Entity createStrongEnemy()
        {
            return GoblinFactory.createGoblin(GoblinTypes.warrior, EnemyFactory.DIFF_HIGH);
        }

        public override Entity createWeakEnemy()
        {
            return GoblinFactory.createGoblin(GoblinTypes.rogue, EnemyFactory.DIFF_LOW);
        }
    }
}
