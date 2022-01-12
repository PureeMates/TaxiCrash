using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Aiv.Fast2D;
using OpenTK;

namespace TaxiCrash
{
    class Game
    {
        private static Window window;
        private static Background background;
        private static Player player;        

        public static Window Win { get { return window; } }

        public static float DeltaTime { get { return window.DeltaTime; } }

        public static void Init()
        {
            window = new Window(720, 900, "Taxi Crush");
            background = new Background();
            player = new Player();            
        }
        public static void Play()
        {
            while (window.IsOpened)
            {
                // INPUT
                Quit();
                player.Input();

                // UPDATE
                background.Update();
                SpawnManager.Update();
                GameOver();
                //player.Collides(vehicle);

                // DRAW
                background.Draw();
                player.Draw();               

                window.Update();
            }
        }

        private static void GameOver()
        {
            if (!player.IsAlive)
            {
                background.Stop();
            }
        }

        private static void Quit()
        {
            if(window.GetKey(KeyCode.Esc))
            {
                window.Exit();
            }
        }
    }
}
