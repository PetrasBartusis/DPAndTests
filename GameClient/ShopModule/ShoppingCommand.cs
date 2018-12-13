

using GameServer.Models;
using System;
/**
* @(#) BuyCommand.cs
*/
namespace GameClient.ShopModule
{
	public interface ShoppingCommand : ICloneable
	{
        void addItem( Item item );
        void removeItem(Item item);
        void execute();
	}
	
}
