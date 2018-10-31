/**
 * @(#) BuyCommand.cs
 */

namespace ClassDiagram.ShopModule.Command
{
	public interface ShoppingCommand
	{
		void addItem( ClassDiagram.ShopModule.Item item );
        void removeItem(ClassDiagram.ShopModule.Item item);
        void execute();
	}
	
}
