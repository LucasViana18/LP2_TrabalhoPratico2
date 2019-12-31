using System;

namespace SnakeGame
{
    public class Snake
    {
        public void InputMove(ConsoleKey input, int xPosIn, int yPosIn, out int xPosOut, out int yPosOut)
        {
            switch (input)
            {
                case ConsoleKey.W:
                case ConsoleKey.UpArrow:
                    Console.SetCursorPosition(xPosIn, yPosIn);
                    Console.Write(" ");
                    yPosIn--;
                    break;
                case ConsoleKey.S:
                case ConsoleKey.DownArrow:
                    Console.SetCursorPosition(xPosIn, yPosIn);
                    Console.Write(" ");
                    yPosIn++;
                    break;
                case ConsoleKey.A:
                case ConsoleKey.LeftArrow:
                    Console.SetCursorPosition(xPosIn, yPosIn);
                    Console.Write(" ");
                    xPosIn--;
                    break;
                case ConsoleKey.D:
                case ConsoleKey.RightArrow:
                    Console.SetCursorPosition(xPosIn, yPosIn);
                    Console.Write(" ");
                    xPosIn++;
                    break;
            }

            xPosOut = xPosIn;
            yPosOut = yPosIn;
        }

        public bool CollideWithWall(int xPos, int yPos)
        {
            if (xPos == 1 || xPos == 61 || yPos == 1 || yPos == 41) return true;
            return false;
        }

        public bool AppleCheck(int xMove, int yMove, int xApplePos, int yApplePos)
        {
            if (xMove == xApplePos && yMove == yApplePos) return true;
            return false;
        }
    }
}
