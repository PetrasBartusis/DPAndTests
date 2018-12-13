
using System.Collections;
/**
* @(#) Aggregator.cs
*/
namespace GameClient.Iterator
{
    public abstract class Aggregator : IEnumerable
    {
        public abstract IEnumerator GetEnumerator();
    }

}
