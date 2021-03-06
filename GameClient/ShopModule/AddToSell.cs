using System;
using System.Collections.Generic;
using GameServer.Models;

namespace GameClient.ShopModule
{
    public class AddToSell : ShoppingCommand
    {
        public AddToSell(IReceiver receiver)
        {
            this.receiver = receiver;
            items = new List<Item>();
        }

        IReceiver receiver;

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

        public object Clone()
        {
            AddToSell command = new AddToSell(receiver);
            foreach (Item item in items)
            {
                command.addItem(item);
            }
            return command;
        }
    }

}
