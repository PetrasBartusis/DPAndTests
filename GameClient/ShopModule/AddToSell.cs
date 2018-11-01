using System.Collections.Generic;
using GameServer.Models;

namespace GameClient.ShopModule
{
    public class AddToSell : ShoppingCommand
    {
        public AddToSell(Receiver receiver)
        {
            this.receiver = receiver;
            items = new List<Item>();
        }

        Receiver receiver;

        List<Item> items;

        public void addItem(Item item)
        {
            items.Add(item);
        }

        public void execute()
        {
            receiver.SellItems(items);
            items.Clear();
        }

        public void removeItem(Item item)
        {
            items.Remove(item);
        }

    }

}