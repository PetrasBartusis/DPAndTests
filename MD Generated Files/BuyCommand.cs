/**
 * @(#) BuyCommand.cs
 */

namespace ClassDiagram.ShopModule.Command
{
	public interface BuyCommand
	{
		void buy( ClassDiagram.ShopModule.Item item );
		
		void undo(  );
		
	}
	
}
