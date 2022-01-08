using Aiv.Fast2D;
using OpenTK;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaxiCrush
{
    class Player
    {
        private Texture texture;
        private Sprite sprite;

        private Vector2 velocity;
        private float speed;

        public bool IsAlive;

        public Player()
        {
            texture = new Texture("Assets/taxi.png");
            sprite = new Sprite(texture.Width, texture.Height);
            sprite.pivot = new Vector2(sprite.Width * 0.5f, sprite.Height * 0.5f);

            speed = 700.0f;

            IsAlive = true;
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

        }

        private void MovementInput()
        {
            if(Game.Window.GetKey(KeyCode.A) || Game.Window.GetKey(KeyCode.Left))
            {
                velocity = new Vector2();
            }
            else if(Game.Window.GetKey(KeyCode.D) || Game.Window.GetKey(KeyCode.Right))
            {

            }
            else
            {
                velocity = new Vector2(0.0f, 0.0f);
            }
        }
    }
}
