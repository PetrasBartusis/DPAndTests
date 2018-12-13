

using System.Collections;
/**
* @(#) MapHashTable.cs
*/
namespace GameClient.Iterator
{
    public class MapHashTable : Aggregator
    {
        public MapHashTableIterator mapHashTableIterator = new MapHashTableIterator();
        public override IEnumerator GetEnumerator()
        {
            char e = mapHashTableIterator.first();
            for (char c = mapHashTableIterator.first();
                mapHashTableIterator.hasNext();
                c = mapHashTableIterator.next())
            {
                yield return c;
            }
        }
    }

}
