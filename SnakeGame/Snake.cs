using System;
using System.Collections.Generic;
using System.Text;

namespace SnakeGame
{
    public class Snake
    {
        private int xMove;
        private int yMove;

        public void Input()
        {
            ConsoleKey input = Console.ReadKey().Key;

            switch (input)
            {
                case ConsoleKey.UpArrow:
                    Console.SetCursorPosition(xMove, yMove);
                    Console.Write(" ");
                    yMove--;
                    break;
                case ConsoleKey.DownArrow:
                    Console.SetCursorPosition(xMove, yMove);
                    Console.Write(" ");
                    yMove++;
                    break;
                case ConsoleKey.LeftArrow:
                    Console.SetCursorPosition(xMove, yMove);
                    Console.Write(" ");
                    xMove--;
                    break;
                case ConsoleKey.RightArrow:
                    Console.SetCursorPosition(xMove, yMove);
                    Console.Write(" ");
                    xMove++;
                    break;
            }
        }
    }
}
