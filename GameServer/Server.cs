

using System.Collections.Generic;
using GameServer.Controllers;
using GameServer.Models;
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
			
		public List<Player> getAllPlayers(  )
		{
            return playerController.getAllPlayers();
		}
		
		public bool useItem( int playerId, Item item )
		{
			return false;
		}
		
		public Position move( int playerId, Direction direction )
		{
			return null;
		}
		
		public bool run( int playerId )
		{
			return false;
		}
		
		public bool buyItems( int playerId, List<Item> items )
		{
			return false;
		}
		
		public bool attack( int playerId, int enemyId )
		{
			return false;
		}
		
		public List<Item> getInventory( int playerId )
		{
			return null;
		}
		
		public bool startFight( int playerId )
		{
			return false;
		}
		
		public Player createPlayer(string name )
		{
			return null;
		}
		
	}
	
}
