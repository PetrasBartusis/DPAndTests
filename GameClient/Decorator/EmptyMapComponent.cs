

using System;
using System.Text;
/**
* @(#) EmptyMapComponent.cs
*/
namespace GameClient.Decorator
{
    public class EmptyMapComponent : MapComponent
    {
        public override void draw(int x, int y)
        {
            Console.Clear();
            foreach (string line in currentMap)
            {
                foreach(char c in line)
                {
                    switch (c)
                    {
                        case 'G':
                            printInColor(ConsoleColor.Green, c);
                            break;
                        case 'P':
                            printInColor(ConsoleColor.Blue, c);
                            break;
                        case 'E':
                            printInColor(ConsoleColor.Red, c);
                            break;
                        default:
                            Console.WriteLine();
                            break;
                    }
                }
                Console.WriteLine();
            }
        }

        private void printInColor(ConsoleColor color, char c)
        {
            Console.BackgroundColor = color;
            Console.ForegroundColor = ConsoleColor.White;
            Console.Write("  ");
            Console.ResetColor();  
        }
    }

}
