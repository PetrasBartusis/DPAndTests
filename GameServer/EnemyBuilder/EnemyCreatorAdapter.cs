

using System.Collections.Generic;
using GameServer.EnemyFactory;
/**
* @(#) EnemyCreatorAdapter.cs
*/
namespace GameServer.EnemyBuilder
{
	public class EnemyCreatorAdapter : IEnemyCreator
	{
		EnemyPartyDirector enemyPartyDirector;
		
        EnemyFactory.EnemyFactory enemyFactory;

        public EnemyParty createEnemies()
        {
            throw new System.NotImplementedException();
        }

        public EnemyParty getEnemyParty(  )
		{
			return null;
		}
		
		public EnemyParty getEnemyParty( EnemyType type, int difficulty )
		{
			return null;
		}
		
		public EnemyParty getEnemyParty( EnemyType type, int size, int difficulty )
		{
			return null;
		}
		
		public EnemyParty getEnemyParty( Dictionary<EnemyType,int> party, int difficultyLevel )
		{
			return null;
		}
		
	}
	
}
