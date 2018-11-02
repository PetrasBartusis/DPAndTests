using System;
using System.Collections.Generic;

namespace GameServer.EnemyFactory
{
    public class FireEnvirnmentFactory : EnemyFactory
    {
        public FireEnvirnmentFactory() { }

        public override Entity createAvarageEnemy()
        {
            return GoblinFactory.createGoblin(GoblinTypes.warrior, EnemyFactory.DIFF_MEDIUM);
        }

        public override Entity createStrongEnemy()
        {
            return ElementalFactory.createElemental(ElementalTypes.fire, EnemyFactory.DIFF_HIGH);
        }

        public override Entity createWeakEnemy()
        {
            return SpiderFactory.createSpider(SpiderTypes.giant, EnemyFactory.DIFF_LOW);
        }
    }
}
