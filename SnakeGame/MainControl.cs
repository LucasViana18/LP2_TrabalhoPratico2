using System;

namespace SnakeGame
{
    public class MainControl
    {
        private Render render = new Render();
        private Snake snake = new Snake();

        private const double MS_PER_UPDATE = 5;


        public void GameLoop()
        {
            double previous = DateTime.Now.Ticks;
            double lag = 0l;

            while (true)
            {
                double current = DateTime.Now.Ticks;
                double elapsed = current - previous;
                previous = current;
                lag += elapsed;

                snake.Input();

                while (lag >= MS_PER_UPDATE)
                {
                    //Update();
                    lag -= MS_PER_UPDATE;
                }

                render.Apple();
                render.Snek();
                render.GameBorder();

            }
        }
        private void Update()
        {

        }
    }
}
