using System;

namespace SnakeGame
{
    public class MainControl
    {
        private const double MS_PER_UPDATE = 5;

        private Snake snake;

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

               //Input();

                while (lag >= MS_PER_UPDATE)
                {
                    //Update();
                    lag -= MS_PER_UPDATE;
                }

                //Render();
            }
        }
    }
}
