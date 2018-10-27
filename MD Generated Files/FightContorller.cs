/**
 * @(#) FightContorller.cs
 */

namespace ClassDiagram.WebAPIGameServer
{
	public class FightContorller
	{
		ClassDiagram.WebAPIGameServer.Models.Player player;
		
		TurnController turnController;
		
		ClassDiagram.EnemyPartyBuilder.EnemyParty enemyPartyBuilder;
		
		public ClassDiagram.GameClient.Bool attack( ClassDiagram.Entity attacker, ClassDiagram.Entity defender )
		{
			return null;
		}
		
		public ClassDiagram.GameClient.Bool useItem( ClassDiagram.ShopModule.Item item, ClassDiagram.Entity target )
		{
			return null;
		}
		
		public ClassDiagram.GameClient.Bool run( ClassDiagram.WebAPIGameServer.Models.Player player, ClassDiagram.EnemyPartyBuilder.EnemyParty party )
		{
			return null;
		}
		
	}
	
}
