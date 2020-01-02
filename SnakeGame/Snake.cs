using System;
using System.Collections.Generic;

namespace SnakeGame
{
    public class Snake
    {
        private List<ConsoleKey> controlKeys;

        private ConsoleKey lastKey;

        public Snake()
        {
            lastKey = ConsoleKey.UpArrow;
            controlKeys = new List<ConsoleKey>()
            {
                ConsoleKey.W, ConsoleKey.UpArrow,
                ConsoleKey.S, ConsoleKey.DownArrow,
                ConsoleKey.A, ConsoleKey.LeftArrow,
                ConsoleKey.D, ConsoleKey.RightArrow
            };
        }

        public void InputMove(int xPosIn, int yPosIn, out int xPosOut, out int yPosOut)
        {
            switch (lastKey)
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

        public void ValidKeys(ConsoleKey keyPressed)
        {
            if (controlKeys.Contains(keyPressed))
                lastKey = keyPressed;
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

        public bool HitBodyCheck(int[] xPos, int[] yPos, int applesEaten)
        {
            for(int i = 1; i < applesEaten + 1; i++)
            {
                if (xPos[0] == xPos[i] && yPos[0] == yPos[i])
                    return true;
            }
            return false;
        }
    }
}
