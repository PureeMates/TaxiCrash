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
        private string[] textures;
        public Vector2 Position;
        private Timer timer;

        public Spawn(Vector2 position)
        {
            textures = new string[] { "Assets/Police.png", "Assets/Ambulance.png", "Assets/Audi.png" };
            Position = position;
            timer = new Timer(2);

        }

        public void Update()
        {
            timer.Update();
        }

        public Texture GetRandomTexture()
        {
            int rand = RandomGen.GetRandomInt(0, textures.Length - 1);
            return new Texture(textures[rand]);
        }

        public Timer GetTimer()
        {
            return timer;
        }

    }
}
