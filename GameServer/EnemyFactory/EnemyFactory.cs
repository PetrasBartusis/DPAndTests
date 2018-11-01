

using GameServer.Models;
/**
* @(#) EnemyFactory.cs
*/
namespace GameServer.EnemyFactory
{
	public abstract class EnemyFactory
	{
		public Entity createSpider( int difficultyLevel )
		{
            return new Entity("Fart", 15, 1, 1);
		}
		
		public Entity createGoblin( int difficultyLevel )
        {
            return new Entity("Fart", 15, 1, 1);
        }
		
		public Entity createElemental( int difficultyLevel )
        {
            return new Entity("Fart", 15, 1, 1);
        }
		
		public Entity createDragon( int difficultyLevel )
        {
            return new Entity("Fart", 15, 1, 1);
        }
		
		public Entity createSlime( int difficultyLevel )
        {
            return new Entity("Fart", 15, 1, 1);
        }
		
		public Entity createDemon( int difficultyLevel )
        {
            return new Entity("Fart", 15, 1, 1);
        }
		
		public Entity createSkeleton( int difficultyLevel )
        {
            return new Entity("Fart", 15, 1, 1);
        }
		
	}
	
}
