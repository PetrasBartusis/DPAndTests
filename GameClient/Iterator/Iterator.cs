/**
 * @(#) Iterator.cs
 */

namespace GameClient.Iterator
{
	public interface Iterator
	{
		bool hasNext(  );
		
		char next(  );
		
		char first(  );
		
		void addEntity(char c, int x, int y);
		
		void removeEntity(int x, int y);
		
	}
	
}
