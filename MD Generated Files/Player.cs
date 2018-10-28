/**
 * @(#) Player.cs
 */

namespace ClassDiagram.WebAPIGameServer.Models
{
	public class Player : ClassDiagram.Entity, ClassDiagram.PlayerPrototype
	{
		int level;
		
		int experience;
		
		int gold;
		
		ClassDiagram.GameClient.List<Item> items;
		
	}
	
}
