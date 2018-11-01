/**
 * @(#) EnemyFactory.cs
 */

namespace EnemyFactory
{
	public abstract class EnemyFactory
	{
		public Entity createSpider( int difficultyLevel )
		{
            return SpiderFactory.createSpider(difficultyLevel);
		}
		
		public Entity createGoblin( int difficultyLevel )
		{
			return GoblinFactory.createGoblin(difficultyLevel);
		}
		
		public Entity createElemental( int difficultyLevel )
		{
			return ElementalFactory.createElemental(difficultyLevel);
		}
		
		public Entity createDragon( int difficultyLevel )
		{
			return DragonFactory(difficultyLevel);
		}
		
		public Entity createSlime( int difficultyLevel )
		{
			return SlimeFactory(difficultyLevel);
		}
		
		public Entity createDemon( int difficultyLevel )
		{
			return DemonFactory(difficultyLevel);
		}
		
		public Entity createSkeleton( int difficultyLevel )
		{
			return SkeletonFactory(difficultyLevel);
		}
		
	}
	
}
