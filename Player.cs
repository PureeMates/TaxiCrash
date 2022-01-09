using Aiv.Fast2D;
using OpenTK;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaxiCrash
{
    class Player
    {
        private Texture texture;
        private Sprite sprite;

        private Vector2 velocity;
        private float speed;

        public bool IsAlive;
        private bool keyPressed;

        public Vector2 Position { get { return sprite.position; } set { sprite.position = value; } }

        public Player()
        {
            texture = new Texture("Assets/taxi.png");
            sprite = new Sprite(texture.Width, texture.Height);
            sprite.pivot = new Vector2(sprite.Width * 0.5f, sprite.Height * 0.5f);

            speed = 700.0f;

            IsAlive = true;
            keyPressed = false;
        }

        public void Input()
        {
            if(IsAlive)
            {
                MovementInput();
            }
        }

        public void Update()
        {
            if(IsAlive)
            {
                Move();
            }
        }

        public void Draw()
        {
            sprite.DrawTexture(texture);
        }

        private void Move()
        {
            Position += velocity * Game.DeltaTime;
        }

        private void MovementInput()
        {
            if (Game.Window.GetKey(KeyCode.A) || Game.Window.GetKey(KeyCode.Left))
            {
                if(!keyPressed)
                {
                    keyPressed = true;
                    velocity.X = -speed;
                }
            }
            else if (Game.Window.GetKey(KeyCode.D) || Game.Window.GetKey(KeyCode.Right))
            {
                if (!keyPressed)
                {
                    keyPressed = true;
                    velocity.X = speed;
                }
            }
            else
            {
                keyPressed = false;
                velocity.X = 0.0f;
            }
        }
    }
}
