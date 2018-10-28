/**
 * @(#) AddToCart.cs
 */

namespace ClassDiagram.ShopModule.Command
{
	public class AddToCart : BuyCommand
	{
		Receiver receiver;
		
		ClassDiagram.List<Items> items;
		
		public void buy( ClassDiagram.ShopModule.Item item )
		{
			
		}
		
		public void undo(  )
		{
			
		}
		
	}
	
}
