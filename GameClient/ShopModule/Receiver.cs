

using GameServer.Models;
using System;
using System.Collections.Generic;
/**
* @(#) Receiver.cs
*/
namespace GameClient.ShopModule
{
	public class Receiver
	{
        public void PurchaseItems(List<Item> items)
        {
            if (items == null || items.Count == 0)
            {
                Console.WriteLine("No items selected to buy");
            }
            else
            {
                Console.WriteLine("Buying was success");
            }
        }

        public void SellItems(List<Item> items)
        {
            if (items == null || items.Count == 0)
            {
                Console.WriteLine("No items selected to sell");
            }
            else
            {
                Console.WriteLine("Selling was success");
            }
        }
    }
	
}
