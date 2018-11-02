/**
 * @(#) EnemyFactory.cs
 */

using System;

namespace GameServer.EnemyFactory
{
	public abstract class EnemyFactory
	{
        public static int DIFF_LOW = 0;
        public static int DIFF_MEDIUM = 1;
        public static int DIFF_HIGH = 2;
        public abstract Entity createWeakEnemy();
        public abstract Entity createAvarageEnemy();
        public abstract Entity createStrongEnemy();
    }
	
}
