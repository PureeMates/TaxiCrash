using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Aiv.Fast2D;
using OpenTK;

namespace TaxiCrush
{
    class Vehicle
    {
        private Texture texture;
        private Sprite sprite;

        public Vector2 Position { get { return sprite.position; } set { sprite.position = value; } }

        private Vector2 velocity;
        private float speed;

        public Vehicle()
        {
            texture = new Texture("Assets/Audi.png");
            sprite = new Sprite(texture.Width, texture.Height);
            sprite.pivot = new Vector2(sprite.Width * 0.5f, sprite.Height * 0.5f);

            speed = 100f;
        }

        public void Update()
        {
            sprite.position += velocity * Game.DeltaTime;
        }

        public void Draw()
        {
            sprite.DrawTexture(texture);
        }
    }
}
