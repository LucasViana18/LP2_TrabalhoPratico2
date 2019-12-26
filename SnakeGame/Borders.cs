using System;
using System.Collections.Generic;
using System.Text;

namespace SnakeGame
{
    public class Borders
    {
        // Visual construction of the game borders
        public void GameBorder()
        {
            // Left vertical border
            for(int i = 1; i < 41; i++)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.SetCursorPosition(1, i);
                Console.Write("&");
            }

            // Right vertical border
            for (int i = 1; i < 41; i++)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.SetCursorPosition(61, i);
                Console.Write("&");
            }

            // Top horizontal border
            for (int i = 1; i < 61; i++)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.SetCursorPosition(i, 1);
                Console.Write("&");
            }

            // Bottom horizontal border
            for (int i = 1; i < 62; i++)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.SetCursorPosition(i, 41);
                Console.Write("&");
            }
        }
    }
}
