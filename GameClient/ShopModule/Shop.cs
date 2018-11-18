

using GameServer;
using GameServer.Models;
/**
* @(#) Shop.cs
*/
namespace GameClient.ShopModule
{
	public class Shop
	{
        private string Tag = "Shop";
        public Shop(IReceiver receiver)
        {
            cart = new AddToCart(receiver);
            sell = new AddToSell(receiver);
        }

        ShoppingCommand cart;
        ShoppingCommand sell;

        public void addToCart( Item item )
        {
            LoggerLazy.getInstance().log(Tag, "addToCart" + item.ToString());
            cart.addItem(item);
        }
        public void addToSell(Item item)
        {
            LoggerLazy.getInstance().log(Tag, "addToSell" + item.ToString());
            sell.addItem(item);
        }

        public void removeFromCart(Item item)
        {
            LoggerLazy.getInstance().log(Tag, "removeFromCart" + item.ToString());
            cart.removeItem(item);
        }
        public void removeFromSell(Item item)
        {
            LoggerLazy.getInstance().log(Tag, "removeFromSell" + item.ToString());
            sell.removeItem(item);
        }

        public void execute(  )
        {
            LoggerLazy.getInstance().log(Tag, "execute");
            cart.execute();
            sell.execute();
        }
		
	}
	
}
