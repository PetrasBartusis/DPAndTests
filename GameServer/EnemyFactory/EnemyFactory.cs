/**
 * @(#) EnemyFactory.cs
 */

using System;

namespace GameServer.EnemyFactory
{
	public abstract class EnemyFactory
	{
        public abstract Entity createWeakEnemy();
        public abstract Entity createAvarageEnemy();
        public abstract Entity createStrongEnemy();
    }
	
}
