using System;
using System.Collections.Generic;
using GameServer.EnemyFactory;
using GameServer.Models;

namespace GameServer.EnemyBuilder
{
    public class EnemyPartyDirector
    {
        public EnemyPartyDirector(EnemyFactory.EnemyFactory factory) => builder = new EnemyPartyBuilder(factory);

        private IEnemyPartyBuilder builder;

        public EnemyParty construct(int difficultyLevel, int enemyCnt, Coordinates p)
        {
            builder.StartNew(p);
            for (int i = 0; i < enemyCnt; i++)
            {
                builder.AddEnemy(difficultyLevel++);
            }
            return builder.Build();
        }

    }

}
