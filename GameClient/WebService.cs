

using System.Collections.Generic;
using GameServer.Models;
/**
* @(#) WebService.cs
*/
namespace ClassDiagram.GameClient
{
	public class WebService
	{
        GameServer.Server server;
		
		public List<Player> getAllPlayers(  )
		{
			return null;
		}
		
		public bool useItem( Item item )
		{
			return false;
		}
		
		public Position move( Direction direction )
		{
			return null;
		}
		
		public bool run(  )
		{
            return false;
		}
		
		public bool buyItems( List<Item> items )
		{
			return false;
		}
		
		public bool attack(  )
		{
			return false;
		}
		
		public List<Item> getInventory(  )
		{
			return null;
		}
		
		public bool startFight(  )
		{
			return false;
		}
		
		public Player createPlayer( string name )
		{
			return null;
		}
		
	}
	
}
