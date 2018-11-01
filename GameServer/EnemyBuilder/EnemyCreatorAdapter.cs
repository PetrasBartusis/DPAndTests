/**
 * @(#) EnemyCreatorAdapter.cs
 */

namespace GameServer.EnemyBuilder
{
	public class EnemyCreatorAdapter : IEnemyCreator
	{
		ClassDiagram.EnemyPartyBuilder.EnemyPartyDirector enemyPartyDirector;
		
		ClassDiagram.EnemyFactory.EnemyFactory enemyFactory;
		
		public ClassDiagram.EnemyPartyBuilder.EnemyParty getEnemyParty(  )
		{
			return null;
		}
		
		public ClassDiagram.EnemyPartyBuilder.EnemyParty getEnemyParty( ClassDiagram.EnemyFactory.EnemyType type, int difficulty )
		{
			return null;
		}
		
		public ClassDiagram.EnemyPartyBuilder.EnemyParty getEnemyParty( ClassDiagram.EnemyFactory.EnemyType type, int size, int difficulty )
		{
			return null;
		}
		
		public ClassDiagram.EnemyPartyBuilder.EnemyParty getEnemyParty( Map<EnemyType,int> party, int difficultyLevel )
		{
			return null;
		}
		
	}
	
}
