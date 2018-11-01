/**
 * @(#) Server.cs
 */

namespace GameServer
{
	public class Server
	{
		FightContorller fightController;

        GameServer.Controllers.EnemyController enemyController;

        GameServer.Controllers.PlayerController playerController;
		
		GameClient.WebService ws;
		
		public List<Player> getAllPlayers(  )
		{
            return playerController.getAllPlayers();
		}
		
		public bool useItem( int playerId, Item item )
		{
			return null;
		}
		
		public Position move( int playerId, Direction direction )
		{
			return null;
		}
		
		public bool run( int playerId )
		{
			return null;
		}
		
		public bool buyItems( int playerId, List<Item> items )
		{
			return null;
		}
		
		public bool attack( int playerId, int enemyId )
		{
			return null;
		}
		
		public List<Item> getInventory( int playerId )
		{
			return null;
		}
		
		public Bool startFight( int playerId )
		{
			return null;
		}
		
		public Player createPlayer( String name )
		{
			return null;
		}
		
	}
	
}
