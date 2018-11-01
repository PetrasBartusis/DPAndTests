/**
 * @(#) EnemyFactory.cs
 */

using System;

namespace GameServer.EnemyFactory
{
	public abstract class EnemyFactory
	{
		public virtual Entity createSpider( int difficultyLevel )
		{
            throw new InvalidOperationException("Unimplemented factory function");
		}
		
		public virtual Entity createGoblin( int difficultyLevel )
        {
            throw new InvalidOperationException("Unimplemented factory function");
        }

        public virtual Entity createElemental(int difficultyLevel)
        {
            throw new InvalidOperationException("Unimplemented factory function");
        }
		
		public virtual Entity createDragon( int difficultyLevel )
        {
            throw new InvalidOperationException("Unimplemented factory function");
        }
		
		public virtual Entity createSlime( int difficultyLevel )
        {
            throw new InvalidOperationException("Unimplemented factory function");
        }
		
		public virtual Entity createDemon( int difficultyLevel )
        {
            throw new InvalidOperationException("Unimplemented factory function");
        }
		
		public virtual Entity createSkeleton( int difficultyLevel )
        {
            throw new InvalidOperationException("Unimplemented factory function");
        }
		
	}
	
}
