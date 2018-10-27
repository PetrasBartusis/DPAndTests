/**
 * @(#) PlayerController.cs
 */

namespace ClassDiagram.WebAPIGameServer.Controllers
{
	public class PlayerController
	{
		public List<Player> getAllPlayers(  )
		{
			return null;
		}
		
		public ClassDiagram.WebAPIGameServer.Models.Player getPlayerById( Int id )
		{
			return null;
		}
		
		public ClassDiagram.WebAPIGameServer.Models.Player createPlayer( String name )
		{
			return null;
		}
		
		public ClassDiagram.WebAPIGameServer.Models.Player move( ClassDiagram.GameClient.Direction direction, int playerId )
		{
			return null;
		}
		
		public ClassDiagram.GameClient.Bool delete( ClassDiagram.WebAPIGameServer.Models.Player player )
		{
			return null;
		}
		
		public void PartialUpdate( ClassDiagram.WebAPIGameServer.Models.Coordinates coord )
		{
			
		}
		
		public ClassDiagram.GameClient.List<Item> getInventory(  )
		{
			return null;
		}
		
		public ClassDiagram.GameClient.Bool buy( ClassDiagram.GameClient.List<Item> items )
		{
			return null;
		}
		
		public ClassDiagram.GameClient.Bool removeItem( ClassDiagram.ShopModule.Item item )
		{
			return null;
		}
		
	}
	
}
