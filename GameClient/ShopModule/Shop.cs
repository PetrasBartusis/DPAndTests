

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
        private Caretaker caretaker = new Caretaker();
        public Shop(IReceiver receiver)
        {
            cart = new AddToCart(receiver);
            sell = new AddToSell(receiver);
        }

        ShoppingCommand cart;
        ShoppingCommand sell;

        public void addToCart( Item item )
        {
            caretaker.AddState(new Memento(sell, cart));
            LoggerLazy.getInstance().log(Tag, "addToCart" + item.ToString());
            cart.addItem(item);
        }
        public void addToSell(Item item)
        {
            caretaker.AddState(new Memento(sell, cart));
            LoggerLazy.getInstance().log(Tag, "addToSell" + item.ToString());
            sell.addItem(item);
        }

        public void removeFromCart(Item item)
        {
            caretaker.AddState(new Memento(sell, cart));
            LoggerLazy.getInstance().log(Tag, "removeFromCart" + item.ToString());
            cart.removeItem(item);
        }
        public void removeFromSell(Item item)
        {
            caretaker.AddState(new Memento(sell, cart));
            LoggerLazy.getInstance().log(Tag, "removeFromSell" + item.ToString());
            sell.removeItem(item);
        }

        public void execute(  )
        {
            LoggerLazy.getInstance().log(Tag, "execute");
            cart.execute();
            sell.execute();
            caretaker.Clear();
        }

        public bool Undo()
        {
            if (caretaker.CanUndo())
            {
                caretaker.Undo().ResetState(sell, cart);
                return true;
            }
            return false;
        }
        public bool Redo()
        {
            if (caretaker.CanRedo())
            {
                caretaker.Redo().ResetState(sell, cart);
                return true;
            }
            return false;
        }

    }
	
}
