using System.Collections.Generic;

namespace GameServer.EnemyBuilder
{
	public class EnemyPartyDirector
	{

        public EnemyPartyDirector(EnemyFactory factory)
        {
            builder = new EnemyBuilder(factory);
        }

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
