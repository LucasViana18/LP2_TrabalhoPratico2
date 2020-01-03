using System;

namespace SnakeGame
{
    /// <summary>
    /// Program class
    /// </summary>
    class Program
    {
        /// <summary>
        /// Main method
        /// </summary>
        /// <param name="args"></param>
        static void Main(string[] args)
        {
            // Local Instance
            MainControl mc = new MainControl();

            // Start of the program
            mc.MainMenuControl();

            // Exit program
            Environment.Exit(0);
        }
    }
}
