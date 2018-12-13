

using System;
using System.Collections.Generic;
using System.Text;
/**
* @(#) MapHashTableIterator.cs
*/
namespace GameClient.Iterator
{
	public class MapHashTableIterator : Iterator
	{
        Dictionary<int, string> map = new Dictionary<int, string>();

        public MapHashTableIterator()
        {
            for(int i = 0; i < maxLength; i++)
            {
                for (int j = 0; j < maxLength; j++)
                {
                    addEntity('D', i, j);
                }
            }
        }

        int maxLength = 10;
        int curX = 0;
        int curY = 0;
        char curC = 'D';

        public void addEntity(char c, int x, int y)
        {
            map[x+y*10] = c.ToString();
        }

        public char first()
        {
            curX = 0;
            curY = 0;
            return map[curX + curY * 10][0];
        }

        public bool hasNext()
        {
            if (curY < maxLength)
            {
                return true;
            }
            else if (curY + 1 < maxLength && curX < maxLength)
            {
                return true;
            }
            return false;
        }

        public char next()
        {
            if (hasNext())
            {
                if (curX + 1 < maxLength)
                {
                    curX += 1;
                    return map[curX + curY*10][0];
                }
                else
                {
                    curY += 1;
                    curX = 0;
                    Console.WriteLine();
                    if (curY == maxLength)
                    {
                        return 'D';
                    }
                    return map[curX + curY * 10][0];
                }
            }
            else
            {
                return 'D';
            }
        }

        public void removeEntity(int x, int y)
        {
            map[x + y * 10] = "D";
        }
    }

}

