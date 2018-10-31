using System.Collections.Generic.List;

namespace GameClient.Shop
{
    public class AddToSell : ShoppingCommand
    {
        Receiver receiver;

        System.Collections.Generic.List<Items> items;

        public void addItem(ClassDiagram.ShopModule.Item item)
        {
            items.Add(item);
        }

        public void removeItem(ClassDiagram.ShopModule.Item item)
        {
            items.Remove(item);
        }

    }

}
