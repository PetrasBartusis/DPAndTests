using GameServer.EnemyFactory.Enemies;
using System;
using System.Collections.Generic;

namespace GameServer.EnemyFactory
{
    public class GrassEnvirnmentFactory : EnemyFactory
    {
        public GrassEnvirnmentFactory() { }

        public override Entity createAvarageEnemy()
        {
            return GoblinFactory.createGoblin(GoblinTypes.rogue, EnemyFactory.DIFF_MEDIUM);
        }

        public override Entity createStrongEnemy()
        {
            return ElementalFactory.createElemental(ElementalTypes.earth, EnemyFactory.DIFF_HIGH);
        }

        public override Entity createWeakEnemy()
        {
            return SpiderFactory.createSpider(SpiderTypes.normal, EnemyFactory.DIFF_LOW);
        }
    }
}
