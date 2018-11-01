

using GameServer.Models;
/**
* @(#) BuyCommand.cs
*/
namespace GameClient.ShopModule
{
	public interface ShoppingCommand
	{
        void addItem( Item item );
        void removeItem(Item item);
        void execute();
	}
	
}
