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

        private int counter;

        public Vector2 Position { get { return sprite.position; } set { sprite.position = value; } }

        public Vector2 Collider { get { return new Vector2(Position.X + sprite.Width * 0.5f, Position.Y - sprite.Height * 0.5f); } }

        public Player()
        {
            texture = new Texture("Assets/taxi.png");
            sprite = new Sprite(texture.Width * 0.75f, texture.Height * 0.75f);
            sprite.pivot = new Vector2(sprite.Width * 0.5f, sprite.Height * 0.5f);
            sprite.position = new Vector2(Game.Win.Width * 0.5f, Game.Win.Height - 105.0f);

            speed = 105.0f;

            IsAlive = true;
            keyPressed = false;

            counter = 0;
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

        private void MoveRight()
        {
            keyPressed = true;
            velocity.X = speed;
            Position += velocity;
            counter++;
        }

        private void MoveLeft()
        {
            keyPressed = true;
            velocity.X = -speed;
            Position += velocity;
            counter--;
        }

        private void MovementInput()
        {
            if ((Game.Win.GetKey(KeyCode.A) || Game.Win.GetKey(KeyCode.Left)) && counter > -3)
            {
                if(!keyPressed)
                {
                    MoveLeft();
                }
            }
            else if ((Game.Win.GetKey(KeyCode.D) || Game.Win.GetKey(KeyCode.Right)) && counter < 3)
            {
                if (!keyPressed)
                {
                    MoveRight();
                }
            }
            else
            {
                keyPressed = false;
                velocity.X = 0.0f;
            }
        }

        

        public bool Collides(Vehicle vehicle)
        {
            if (vehicle.IsAlive)
            {
                Vector2 dist;
                dist = Vector2.Subtract(Collider, vehicle.Collider);

                if (dist.X == 0 && dist.Y <= 0)
                {
                    
                    return true;
                }
            }

            
            return false;
        }

        




    }
}
