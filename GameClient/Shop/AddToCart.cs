using System.Collections.Generic;
using GameServer.Models;

namespace GameClient.Shop
{
	public class AddToCart : ShoppingCommand
    {
		Receiver receiver;

        List<Item> items;
		
		public void addItem( Item item )
		{
            items.Add(item);
		}

        public void execute()
        {
            throw new System.NotImplementedException();
        }

        public void removeItem(Item item)
        {
            items.Remove(item);
        }

    }
	
}
