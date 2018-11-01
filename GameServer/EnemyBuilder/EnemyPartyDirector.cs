using System;
using System.Collections.Generic;
using GameServer.EnemyFactory;
using GameServer.Models;

namespace GameServer.EnemyBuilder
{
	public class EnemyPartyDirector
	{
        private Random random = new Random();
        public EnemyPartyDirector(EnemyFactory.EnemyFactory factory) => builder = new EnemyPartyBuilder(factory);

        private IEnemyPartyBuilder builder;
		
		public EnemyParty construct(int difficultyLevel, int enemyCnt, Coordinates p)
		{
            builder.StartNew(p);
            for (int i = 0; i < enemyCnt; i++)
            {
                int r = random.Next(100);
                if (difficultyLevel < 10)
                {
                    if(r < 50)
                    {
                        builder.AddEnemy(0);
                    } else if(r < 85)
                    {
                        builder.AddEnemy(1);
                    } else
                    {
                        builder.AddEnemy(2);
                    }
                }
                else if (difficultyLevel < 50)
                {
                    if (r < 25)
                    {
                        builder.AddEnemy(0);
                    }
                    else if (r < 70)
                    {
                        builder.AddEnemy(1);
                    }
                    else
                    {
                        builder.AddEnemy(2);
                    }
                }
                else
                {
                    if (r < 15)
                    {
                        builder.AddEnemy(0);
                    }
                    else if (r < 40)
                    {
                        builder.AddEnemy(1);
                    }
                    else
                    {
                        builder.AddEnemy(2);
                    }
                }
            }
            return builder.Build();
		}
		
	}
	
}
