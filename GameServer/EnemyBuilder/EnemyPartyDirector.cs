using System;
using System.Collections.Generic;
using GameServer.EnemyFactory;
using GameServer.Models;

namespace GameServer.EnemyBuilder
{
    public class EnemyPartyDirector
    {
        public EnemyPartyDirector() => builder = new EnemyPartyBuilder();

        private IEnemyPartyBuilder builder;

        public void setFactory(EnemyFactory.EnemyFactory factory)
        {
            builder.setFactory(factory);
        }
        public EnemyParty construct(int difficultyLevel, Coordinates p)
        {
            builder.StartNew(p);
            for (int pSize = difficultyLevel / 3; pSize > 0; pSize--)
            {
                builder.AddEnemy(difficultyLevel--);
            }
            return builder.Build();
        }

    }

}
