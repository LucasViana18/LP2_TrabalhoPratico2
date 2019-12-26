using System;

namespace SnakeGame
{
    class Program
    {
        static void Main(string[] args)
        {
            Render render = new Render();
            MainControl mc = new MainControl();

            mc.GameLoop();
        }
    }
}
