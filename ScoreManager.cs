using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Aiv.Fast2D;

namespace TaxiCrash
{
    static class ScoreManager
    {
        private static Background bg;

        private static int scorePlayer;
        private static int enemyPoints;

        private static float bgExtraSpeed;
        private static float vehicleExtraSpeed;

        public static bool Gained;

        public static void Init(Background _bg)
        {
            bg = _bg;

            scorePlayer = 0;
            enemyPoints = 1;

            bgExtraSpeed = 150.0f;
            vehicleExtraSpeed = 275.0f;

            Gained = false;
        }

        public static void Update(List<Vehicle> vehicles)
        {
            if (scorePlayer > 0 && scorePlayer % 10 == 0)
            {
                if(!Gained)
                {
                    IncreaseSpeed(vehicles);
                }
            }
            else
            {
                Gained = false;
            }
        }

        public static void AddScore(Vehicle vehicle)
        {
            if (!vehicle.Gained)
            {
                vehicle.Gained = true;
                scorePlayer += enemyPoints;
            }
        }

        private static void IncreaseSpeed(List<Vehicle> vehicles)
        {
            Gained = true;
            for (int i = 0; i < vehicles.Count; i++)
            {
                vehicles[i].IncreaseSpeed(vehicleExtraSpeed);
            }
            bg.IncreaseSpeed(bgExtraSpeed);
            Console.WriteLine($"Score : {scorePlayer}, GOING FASTER!");
        }

        public static void DisplayScore()
        {
            Console.WriteLine($"YOUR SCORE IS: {scorePlayer}, CONGRATS!");
        }
    }
}
