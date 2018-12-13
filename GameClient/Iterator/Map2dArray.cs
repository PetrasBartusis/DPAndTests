

using System.Collections;
/**
* @(#) Map2dArray.cs
*/
namespace GameClient.Iterator
{
	public class Map2dArray : Aggregator
	{
        public Map2dIterator map2DIterator = new Map2dIterator();

        public override IEnumerator GetEnumerator()
        {
            char e = map2DIterator.first();
            for (char c = map2DIterator.first(); 
                map2DIterator.hasNext(); 
                c = map2DIterator.next())
            {
                yield return c;
            }
        }
    }

}
