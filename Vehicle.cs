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

        public Vector2 Collider { get { return new Vector2(Position.X + sprite.Width * 0.5f, Position.Y + sprite.Height * 0.5f); } }
        

        private Vector2 velocity;
        private float speed;

        public bool IsAlive;

        

        public Vehicle()
        {
            texture = new Texture("Assets/Audi.png");
            sprite = new Sprite(texture.Width * 0.75f, texture.Height * 0.75f);
            sprite.pivot = new Vector2(sprite.Width * 0.5f, sprite.Height * 0.5f);
            sprite.position = new Vector2(Game.Win.Width * 0.5f, 55.0f);

            speed = 550f;
            velocity.Y = speed;
            IsAlive = true; // true for debug
        }

        public void Update()
        {
            if (IsAlive)
            {
                sprite.position += velocity * Game.DeltaTime;

                if (Position.Y - sprite.Height * 0.5f >= Game.Win.Height)
                {
                    IsAlive = false;
                }
            }
        }

        public void Draw()
        {
            if (IsAlive)
            {
                sprite.DrawTexture(texture);
            }
            
        }

        
       
    }
}
