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
            sprite = new Sprite(texture.Width * 0.45f, texture.Height * 0.45f);
            sprite.pivot = new Vector2(sprite.Width * 0.5f, sprite.Height * 0.5f);
            sprite.position = new Vector2(Game.Win.Width * 0.5f, Game.Win.Height - 70.0f);

            speed = 75.0f;

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
            
        }

        public void Draw()
        {
            sprite.DrawTexture(texture);
        }

        private void MovementInput()
        {
            if (Game.Win.GetKey(KeyCode.A) || Game.Win.GetKey(KeyCode.Left))
            {
                if(!keyPressed)
                {
                    keyPressed = true;
                    velocity.X = -speed;
                    Position += velocity;
                }
            }
            else if (Game.Win.GetKey(KeyCode.D) || Game.Win.GetKey(KeyCode.Right))
            {
                if (!keyPressed)
                {
                    keyPressed = true;
                    velocity.X = speed;
                    Position += velocity;
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
