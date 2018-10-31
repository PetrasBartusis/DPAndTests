/**
 * @(#) Shop.cs
 */

namespace ClassDiagram.ShopModule.Command
{
	public class Shop
	{
		Receiver receiver;
        ShoppingCommand cart;
        ShoppingCommand sell;

        public void addToCart( ClassDiagram.ShopModule.Item item )
		{
            cart.addItem(item);
        }
        public void addToSell(ClassDiagram.ShopModule.Item item)
        {
            sell.addItem(item);
        }

        public void removeFromCart(ClassDiagram.ShopModule.Item item)
        {
            cart.removeItem(item);
        }
        public void removeFromSell(ClassDiagram.ShopModule.Item item)
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
