using System;

namespace SnakeGame
{
    class Program
    {
        static void Main(string[] args)
        {
            MainControl mc = new MainControl();

            mc.MainMenuControl();
            Environment.Exit(0);
        }
    }
}
