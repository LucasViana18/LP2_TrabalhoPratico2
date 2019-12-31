using System;
using System.IO;

namespace SnakeGame
{
    public class Render
    {
        // Visual construction of the game borders
        public void GameBorder()
        {
            Console.Clear();

            //Borders

            // Left vertical border
            for (int i = 1; i < 41; i++)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.SetCursorPosition(1, i);
                Console.Write("#");
            }
            
            // Right vertical border
            for (int i = 1; i < 41; i++)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.SetCursorPosition(61, i);
                Console.Write("#");
            }

            // Top horizontal border
            for (int i = 1; i < 61; i++)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.SetCursorPosition(i, 1);
                Console.Write("#");
            }

            // Bottom horizontal border
            for (int i = 1; i < 62; i++)
            {

                Console.SetCursorPosition(i, 41);
                Console.Write("#");
            }
        }

        //Snake
        public void RenderSnake(int applesEaten, int[] xPosIn, int[] yPosIn,
            out int[] xPosOut, out int[] yPosOut)
        {

            //Render Head
            Console.SetCursorPosition(xPosIn[0], yPosIn[0]);
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("O");

            //Render Body
            for (int i = 1; i < applesEaten + 1; i++)
            {
                Console.SetCursorPosition(xPosIn[i], yPosIn[i]);
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.WriteLine("o");
            }

            //Erase snake last part
            Console.SetCursorPosition(xPosIn[applesEaten + 1], yPosIn[applesEaten + 1]);
            Console.WriteLine(" ");

            //Record position of each body part
            for (int i = applesEaten + 1; i > 0; i--)
            {
                xPosIn[i] = xPosIn[i - 1];
                yPosIn[i] = yPosIn[i - 1];
            }

            //Return new arrey
            xPosOut = xPosIn;
            yPosOut = yPosIn;
        }

        public void MainMenu()
        {
            Console.WriteLine(RepeatChar('-', 90));
            Console.WriteLine("\n███████╗███╗   ██╗ █████╗ ██╗  ██╗███████╗     ██████╗  █████╗ ███╗   ███╗███████╗");
            Console.WriteLine("██╔════╝████╗  ██║██╔══██╗██║ ██╔╝██╔════╝    ██╔════╝ ██╔══██╗████╗ ████║██╔════╝");
            Console.WriteLine("███████╗██╔██╗ ██║███████║█████╔╝ █████╗      ██║  ███╗███████║██╔████╔██║█████╗  ");
            Console.WriteLine("╚════██║██║╚██╗██║██╔══██║██╔═██╗ ██╔══╝      ██║   ██║██╔══██║██║╚██╔╝██║██╔══╝  ");
            Console.WriteLine("███████║██║ ╚████║██║  ██║██║  ██╗███████╗    ╚██████╔╝██║  ██║██║ ╚═╝ ██║███████╗");
            Console.WriteLine("╚══════╝╚═╝  ╚═══╝╚═╝  ╚═╝╚═╝  ╚═╝╚══════╝     ╚═════╝ ╚═╝  ╚═╝╚═╝     ╚═╝╚══════╝\n");

            Console.Write("1. New Game    \n" +
                          "2. High Scores \n" +
                          "3. Quit        \n --> ");
            
        }

        public void HighScores()
        {
            string fileName = "HighScores.txt";
            char separator = '\t';

            StreamReader sr = new StreamReader(fileName);
            string s;

            Console.WriteLine("\n" + RepeatChar('-', 90));
            Console.WriteLine("\nHighScores\n");

            while ((s = sr.ReadLine()) != null)
            {
                string[] nameAndScore = s.Split(separator);
                string name = nameAndScore[0];
                float score = Convert.ToSingle(nameAndScore[1]);
                Console.WriteLine($"Player: {name}\tScore: {score,4}\n");
            }

            sr.Close();
        }

        public void RenderApple(int x, int y)
        {
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.SetCursorPosition(x, y);
            Console.WriteLine("0");
        }

        public void RenderScore(MainControl mc)
        {
            Console.SetCursorPosition(65, 5);
            Console.Write("Score: " + mc.Score);
        }

        private string RepeatChar(char character, int number)
        {
            string result = "";
            for (int i = 0; i < number; i++)
                result += character;
            return result;
        }
    }
}

