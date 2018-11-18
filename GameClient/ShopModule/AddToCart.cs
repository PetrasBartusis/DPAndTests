using System.Collections.Generic;
using GameServer.Models;

namespace GameClient.ShopModule
{
	public class AddToCart : ShoppingCommand
    {
        public AddToCart(IReceiver receiver)
        {
            this.receiver = receiver;
            items = new List<Item>();
        }

        Receiver receiver;

        List<Item> items;
		
		public void addItem( Item item )
		{
            items.Add(item);
		}

        public void execute()
        {
            receiver.PurchaseItems(items);
            items.Clear();
        }

        public void removeItem(Item item)
        {
            items.Remove(item);
        }

    }
	
}
