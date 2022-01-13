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

        public bool Gained;

        public Vehicle(Texture texture)
        {
            this.texture = texture;
            sprite = new Sprite(texture.Width * 0.65f, texture.Height * 0.65f);
            sprite.pivot = new Vector2(sprite.Width * 0.5f, sprite.Height * 0.5f);

            speed = 550.0f;
            Gained = false;
        }

        public void SetTexture(Texture texture)
        {
            this.texture = texture;
        }

        public void Update()
        {
            velocity.Y = speed;
            sprite.position += velocity * Game.DeltaTime;

            if (Position.Y - sprite.Height * 0.5f >= Game.Win.Height)
            {
                ScoreManager.AddScore(this);
                SpawnManager.ResetVehicle(this);
            }
        }

        public void Draw()
        {
            sprite.DrawTexture(texture);
        }

        public void IncreaseSpeed(float speed)
        {
            this.speed += speed;
        }

        public void Stop()
        {
            speed = 0;
        }
    }
}
