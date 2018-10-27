/**
 * @(#) IEnemyPartyBuilder.cs
 */

namespace ClassDiagram.EnemyPartyBuilder
{
	public interface IEnemyPartyBuilder
	{
		void startNew(  );
		
		EnemyParty build(  );
		
		void addEnemy( ClassDiagram.EnemyFactory.EnemyType type, int difficultyLevel );
		
	}
	
}
