using System;

namespace SnakeGame
{
    class Program
    {
        static void Main(string[] args)
        {
            Render render = new Render();

            render.GameBorder();
            render.Snek();
            render.Apple();
        }
    }
}
