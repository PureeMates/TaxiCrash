using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Aiv.Fast2D;
using OpenTK;

namespace TaxiCrush
{
    class Game
    {
        private static Window window;
        private static Player player;

        public static Window Win { get { return window; } }

        public static void Init()
        {
            window = new Window(720, 1280, "Taxi Crush");
        }
        public static void Play()
        {
            while (window.IsOpened)
            {
                // INPUT
                

                // UPDATE
                

                // DRAW
                

                window.Update();
            }
        }

    }
}
