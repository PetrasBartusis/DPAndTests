using GameServer.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace GameClient.ShopModule
{
    public interface IReceiver
    {
        void PurchaseItems(List<Item> items);

        void SellItems(List<Item> items);
    }
}
