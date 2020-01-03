using System;
using System.Collections.Generic;

namespace SnakeGame
{
    /// <summary>
    /// Manages every action of the snake
    /// </summary>
    public class Snake
    {
        // Instance vatiables
        private List<ConsoleKey> controlKeys;
        private ConsoleKey lastKey;

        /// <summary>
        /// Constructor
        /// </summary>
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

        /// <summary>
        /// Movement of the snake depending on the input
        /// </summary>
        /// <param name="xPosIn">Last x Position</param>
        /// <param name="yPosIn">Last y Position</param>
        /// <param name="xPosOut">New x Position</param>
        /// <param name="yPosOut">New y Position</param>
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

        /// <summary>
        /// Determines if the key pressed is valid
        /// </summary>
        /// <param name="keyPressed">The key pressed by the user</param>
        public void ValidKeys(ConsoleKey keyPressed)
        {
            if (controlKeys.Contains(keyPressed))
                lastKey = keyPressed;
        }

        /// <summary>
        /// Determines if snake collided to the wall
        /// </summary>
        /// <param name="xPos"> X Position</param>
        /// <param name="yPos">Y Position</param>
        /// <returns>True if collided</returns>
        public bool CollideWithWall(int xPos, int yPos)
        {
            if (xPos == 1 || xPos == 61 || yPos == 1 || yPos == 41) return true;
            return false;
        }

        /// <summary>
        /// Checks if snake is in the same position as the apple
        /// </summary>
        /// <param name="xMove">Snake x position</param>
        /// <param name="yMove">Snake y position</param>
        /// <param name="xApplePos">Apple x position</param>
        /// <param name="yApplePos">Apple y position</param>
        /// <returns>True if they have the same position</returns>
        public bool AppleCheck(int xMove, int yMove, int xApplePos, int yApplePos)
        {
            if (xMove == xApplePos && yMove == yApplePos) return true;
            return false;
        }

        /// <summary>
        /// Checks if the snake hit itself
        /// </summary>
        /// <param name="xPos">X position</param>
        /// <param name="yPos">Y position</param>
        /// <param name="applesEaten">Number of apples eaten</param>
        /// <returns>True if collided with itself</returns>
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
