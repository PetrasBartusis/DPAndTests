

using GameServer.EnemyBuilder;
using GameServer.Models;
/**
* @(#) FightContorller.cs
*/
namespace GameServer.Controllers
{
	public class FightContorller
	{
		Player player;
		
		TurnController turnController;
		
		EnemyParty enemyPartyBuilder;
		
		public bool attack(Entity attacker, Entity defender )
		{
            return false;
		}
		
		public bool useItem( Item item, Entity target )
		{
            return false;
		}
		
		public bool run( Player player, EnemyParty party )
		{
            return false;
		}
		
	}
	
}
