using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Aiv.Fast2D;
using OpenTK;

namespace TaxiCrash
{
    class Vehicle
    {
        private Texture texture;
        private Sprite sprite;

        public Vector2 Position { get { return sprite.position; } set { sprite.position = value; } }

        public Sprite Collider { get { return sprite; } }

        private Vector2 velocity;
        private float speed;

        public bool IsAlive;
        public bool Gained;
        

        public Vehicle()
        {
            texture = new Texture("Assets/Audi.png");
            sprite = new Sprite(texture.Width * 0.75f, texture.Height * 0.75f);
            sprite.pivot = new Vector2(sprite.Width * 0.5f, sprite.Height * 0.5f);
            sprite.position = new Vector2(Game.Win.Width * 0.5f, 55.0f);

            speed = 200f;
            IsAlive = true; // true for debug
            Gained = false;
        }

        public void Update()
        {
            if (IsAlive)
            {
                velocity.Y = speed;
                sprite.position += velocity * Game.DeltaTime;

                if (Position.Y - sprite.Height * 0.5f >= Game.Win.Height)
                {
                    IsAlive = false;
                    ScoreManager.AddScore(this);
                    
                }
            }
        }

        public Sprite GetSprite()
        {
            return sprite;
        }

        public void Draw()
        {
            if (IsAlive)
            {
                sprite.DrawTexture(texture);
            }

        }

        public void Stop()
        {
            speed = 0;
        }

    }
}
