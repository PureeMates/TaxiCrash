using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Aiv.Fast2D;
using OpenTK;

namespace TaxiCrash
{
    class Spawn
    {
        public Vector2 Position;
        private Timer timer;

        public Spawn(Vector2 position)
        {
            Position = position;
            timer = new Timer(2);
        }

        public Timer GetTimer()
        {
            return timer;
        }

        public void Update()
        {
            timer.Update();
        }
    }
}
