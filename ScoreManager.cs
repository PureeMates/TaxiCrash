using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Aiv.Fast2D;

namespace TaxiCrush
{
    
    static class ScoreManager
    {
        public static float ScorePlayer;        

        static ScoreManager()
        {
            ScorePlayer = 0.0f;
            
        }

        public static void AddScore(float enemyPoints)
        {
            ScorePlayer += enemyPoints;
        }

    }

   

    




    

    
}
