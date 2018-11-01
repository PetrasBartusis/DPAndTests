

using GameServer.Models;
/**
* @(#) Shop.cs
*/
namespace GameClient.ShopModule
{
	public class Shop
	{
        public Shop(Receiver receiver)
        {
            cart = new AddToCart(receiver);
            sell = new AddToSell(receiver);
        }

        ShoppingCommand cart;
        ShoppingCommand sell;

        public void addToCart( Item item )
		{
            cart.addItem(item);
        }
        public void addToSell(Item item)
        {
            sell.addItem(item);
        }

        public void removeFromCart(Item item)
        {
            cart.removeItem(item);
        }
        public void removeFromSell(Item item)
        {
            sell.removeItem(item);
        }

        public void execute(  )
		{
            cart.execute();
            sell.execute();
        }
		
	}
	
}
