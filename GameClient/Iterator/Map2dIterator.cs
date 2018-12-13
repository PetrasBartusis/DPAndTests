

using System;
using System.Text;
/**
* @(#) Map2dIterator.cs
*/
namespace GameClient.Iterator
{
    public class Map2dIterator : Iterator
    {
        public string[] currentMap = { "GGGGGGGGGG", "GGGGGGGGGG", "GGGGGGGGGG", "GGGGGGGGGG", "GGGGGGGGGG", "GGGGGGGGGG", "GGGGGGGGGG", "GGGGGGGGGG", "GGGGGGGGGG", "GGGGGGGGGG" };

        int maxLength = 10;
        int curX = 0;
        int curY = 0;
        char curC = 'G';

        public void addEntity(char c, int x, int y)
        {
            StringBuilder currentTile = new StringBuilder(currentMap[y]);
            currentTile[x] = c;
            currentMap[y] = currentTile.ToString();
        }

        public char first()
        {
            curX = 0;
            curY = 0;
            return currentMap[curX][curY];
        }

        public bool hasNext()
        {
            if(curY < maxLength)
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
                    return currentMap[curX][curY];
                }
                else 
                {
                    curY += 1;
                    curX = 0;
                    Console.WriteLine();
                    if(curY == maxLength)
                    {
                        return 'G';
                    }
                    return currentMap[curX][curY];
                }
            }
            else
            {
                return 'G';
            }
        }

        public void removeEntity(int x, int y)
        {
            StringBuilder currentTile = new StringBuilder(currentMap[y]);
            currentTile[x] = 'G';
            currentMap[y] = currentTile.ToString();
        }
    }

}
