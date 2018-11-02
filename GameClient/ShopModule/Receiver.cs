

using GameServer;
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
        private string Tag = "Receiver";
        public void PurchaseItems(List<Item> items)
        {
            LoggerLazy.getInstance().log(Tag, "PurchaseItems");
            if (items == null || items.Count == 0)
            {
                LoggerLazy.getInstance().log(Tag, "No items selected to buy");
            }
            else
            {
                LoggerLazy.getInstance().log(Tag, "Buying was success");
            }
        }

        public void SellItems(List<Item> items)
        {
            LoggerLazy.getInstance().log(Tag, "SellItems");
            if (items == null || items.Count == 0)
            {
                LoggerLazy.getInstance().log(Tag, "No items selected to sell");
            }
            else
            {
                LoggerLazy.getInstance().log(Tag, "Selling was success");
            }
        }
    }
	
}
