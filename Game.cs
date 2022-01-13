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

        private static bool gameOver;

        public static Window Win { get { return window; } }

        public static float DeltaTime { get { return window.DeltaTime; } }

        public static void Init()
        {
            window = new Window(720, 900, "Taxi Crush");
            background = new Background();
            player = new Player();

            gameOver = false;

            ScoreManager.Init(background);
        }

        public static void Play()
        {
            while (window.IsOpened)
            {
                //INPUT
                Quit();
                player.Input();

                //UPDATE
                background.Update();
                SpawnManager.Update();
                ScoreManager.Update(SpawnManager.GetActiveVehicles());
                player.Update(SpawnManager.GetActiveVehicles());

                GameOver();

                //DRAW
                background.Draw();
                player.Draw();
                SpawnManager.Draw();

                window.Update();
            }
        }

        private static void GameOver()
        {
            if (!player.IsAlive && !gameOver)
            {
                gameOver = true;
                background.Stop();
                SpawnManager.Stop();
                ScoreManager.DisplayScore();
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
