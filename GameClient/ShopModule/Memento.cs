using GameServer.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace GameClient.ShopModule
{
    class Memento
    {
        private ShoppingCommand sellItems;
        private ShoppingCommand buyItems;

        public Memento(ShoppingCommand sell, ShoppingCommand buy)
        {
            SellItems = sell;
            BuyItems = buy;
        }

        public ShoppingCommand BuyItems { get => buyItems; private set => buyItems = value; }
        public ShoppingCommand SellItems { get => sellItems; private set => sellItems = value; }
    }
}
