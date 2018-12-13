

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
            LoggerLazy.getInstance().log(Tag, "addToCart" + item.ToString());
            cart.addItem(item);
            caretaker.AddState(new Memento(sell, cart));
        }
        public void addToSell(Item item)
        {
            LoggerLazy.getInstance().log(Tag, "addToSell" + item.ToString());
            sell.addItem(item);
            caretaker.AddState(new Memento(sell, cart));
        }

        public void removeFromCart(Item item)
        {
            LoggerLazy.getInstance().log(Tag, "removeFromCart" + item.ToString());
            cart.removeItem(item);
            caretaker.AddState(new Memento(sell, cart));
        }
        public void removeFromSell(Item item)
        {
            LoggerLazy.getInstance().log(Tag, "removeFromSell" + item.ToString());
            sell.removeItem(item);
            caretaker.AddState(new Memento(sell, cart));
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
                Memento memento = caretaker.Undo();
                cart = memento.BuyItems;
                sell = memento.SellItems;
                return true;
            }
            return false;
        }
        public bool Redo()
        {
            if (caretaker.CanRedo())
            {
                Memento memento = caretaker.Redo();
                cart = memento.BuyItems;
                sell = memento.SellItems;
                return true;
            }
            return false;
        }

    }
	
}
