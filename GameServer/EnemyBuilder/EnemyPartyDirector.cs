using System.Collections.Generic;
using GameServer.EnemyFactory;
using GameServer.Models;

namespace GameServer.EnemyBuilder
{
	public class EnemyPartyDirector
	{

        public EnemyPartyDirector(EnemyFactory.EnemyFactory factory) => builder = new EnemyPartyBuilder(factory);

        private IEnemyPartyBuilder builder;
		
		public EnemyParty construct( Dictionary<EnemyType, int> party, int difficultyLevel, Position p, int id)
		{
            builder.startNew(id, p);
            foreach(var pair in party)
            {
                for(int i = 0; i < pair.Value; i++)
                {
                    builder.addEnemy(pair.Key, difficultyLevel);
                }
            }
            return builder.build();
		}
		
	}
	
}
