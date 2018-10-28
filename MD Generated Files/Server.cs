/**
 * @(#) Server.cs
 */

namespace ClassDiagram.WebAPIGameServer
{
	public class Server
	{
		FightContorller fightController;
		
		ClassDiagram.WebAPIGameServer.Controllers.EnemyController enemyController;
		
		ClassDiagram.WebAPIGameServer.Controllers.PlayerController playerController;
		
		ClassDiagram.GameClient.WebService ws;
		
		public ClassDiagram.WebAPIGameServer.Controllers.List<Player> getAllPlayers(  )
		{
			return null;
		}
		
		public ClassDiagram.GameClient.Bool useItem( int playerId, ClassDiagram.ShopModule.Item item )
		{
			return null;
		}
		
		public ClassDiagram.Position move( int playerId, ClassDiagram.GameClient.Direction direction )
		{
			return null;
		}
		
		public ClassDiagram.GameClient.Bool run( int playerId )
		{
			return null;
		}
		
		public ClassDiagram.GameClient.Bool buyItems( int playerId, ClassDiagram.GameClient.List<Item> items )
		{
			return null;
		}
		
		public ClassDiagram.GameClient.Bool attack( int playerId, int enemyId )
		{
			return null;
		}
		
		public ClassDiagram.GameClient.List<Item> getInventory( int playerId )
		{
			return null;
		}
		
		public ClassDiagram.GameClient.Bool startFight( int playerId )
		{
			return null;
		}
		
		public ClassDiagram.WebAPIGameServer.Models.Player createPlayer( String name )
		{
			return null;
		}
		
	}
	
}
