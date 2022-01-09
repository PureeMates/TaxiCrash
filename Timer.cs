using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaxiCrash
{
    class Timer
    {
        private int tune;
        private bool endReached;
        private float nextTimer;

        /// <summary>
        /// ctor for timer
        /// </summary>
        /// <param name="t">it's a parameter for tuning Time</param>
        public Timer(int t)
        {
            tune = t;
            nextTimer = ResetCounter();
            endReached = false;
        }

        public void Update()
        {
            if (!CheckTimer())
            {
                nextTimer -= Game.Win.DeltaTime;
            }
            else
            {
               nextTimer = ResetCounter();
            }
        }

        /// <summary>
        /// Return true if Timer has finshed else return false
        /// </summary>
        /// <returns></returns>
        public bool CheckTimer()
        {
            if (nextTimer <= 0)
            {
                endReached = true;
            }
            else
            {
                endReached = false;
            }
            #region Debug
            //Console.WriteLine(endReached);
            //Console.WriteLine(nextTimer); 
            #endregion
            return endReached;
        }

        private float ResetCounter()
        {
            endReached = false;
            return RandomGen.GetRandomFloat() * tune + 1;     //number for tuning
        }

    }
}
