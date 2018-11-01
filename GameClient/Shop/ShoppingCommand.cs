

using GameServer.Models;
/**
* @(#) BuyCommand.cs
*/
namespace GameClient.Shop
{
	public interface ShoppingCommand
	{
        void addItem( Item item );
        void removeItem(Item item);
        void execute();
	}
	
}
