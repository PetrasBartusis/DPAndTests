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
            sellItems = sell.Clone() as ShoppingCommand;
            buyItems = buy.Clone() as ShoppingCommand;
        }

        public void ResetState(ShoppingCommand sell, ShoppingCommand buy)
        {
            sell = sellItems;
            buy = buyItems;
        }
    }
}
