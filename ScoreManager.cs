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
        public static float ScorePlayer;
        public static float enemyPoints;

        
        //private static  int energy = 1;

        static ScoreManager()
        {
            ScorePlayer = 0.0f;
            
            enemyPoints = 1.0f;
            
        }

        //public static void CheckOffSet(Vehicle vehicle)
        //{
        //    if (vehicle.Position.Y + vehicle.GetSprite().Height * 0.5f >= Game.Win.Height )
        //    {
        //        ScoreManager.AddScore(vehicle);
        //    }
        //}



        //public static bool IsAlive()
        //{
        //    return energy > 0;
        //}



        public static void AddScore(Vehicle vehicle)
        {
            if (!vehicle.Gained && !vehicle.IsAlive)
            {
                vehicle.Gained = true;
                ScorePlayer += enemyPoints;
                Console.WriteLine("score : " + ScorePlayer);
                
            }
   
        }


        public static void BgIncreaseSpeed(Background bg)
        {
            if (ScorePlayer >= 1)
            {
                bg.SetSpeed(60);
            }
        }
        



    }

   

    




    

    
}
