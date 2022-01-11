using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Aiv.Fast2D;
using OpenTK;

namespace TaxiCrash
{
    class Background
    {
        private Sprite sprite;
        private Sprite sprite2;
        private Texture texture;
        private float speed;
       

        public Background()
        {
            texture = new Texture("Assets/Background720_900.png");
            sprite = new Sprite(texture.Width, texture.Height);
            sprite2 = new Sprite(texture.Width, texture.Height);
            sprite.position = new Vector2(0, Game.Win.Height - texture.Height);
            sprite2.position = new Vector2(0, Game.Win.Height - (texture.Height * 2f));
            speed = 300.0f;
        }

        public void Update()
        {
            sprite.position.Y += speed * Game.DeltaTime;
            sprite2.position.Y += speed * Game.DeltaTime;
            if (sprite.position.Y  >= texture.Height)
            {
                sprite.position.Y = sprite2.position.Y - texture.Height;
            }
            if (sprite2.position.Y  >= texture.Height)
            {
                sprite2.position.Y = sprite.position.Y - texture.Height;
            }
        }

        public void Draw()
        {
            sprite.DrawTexture(texture);
            sprite2.DrawTexture(texture);
        }

        public void Stop()
        {
            speed = 0;
        }
    }
}
