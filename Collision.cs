using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Aiv.Fast2D;
using OpenTK;

namespace TaxiCrash
{
    static class Collision
    {
        static bool collide;

        static Collision()
        {
            collide = false;
        }
        /// <summary>
        /// Return true when it finds a collision between two objects
        /// </summary>
        /// <param name="enemy">vehicles, obstacles, power-ups</param>
        /// <param name="player">player</param>
        /// <returns></returns>
        static public bool GetCollision(Sprite entity, Sprite player)        //enemy proiettile, player alieno fermo(da cui raggio e 
        {                                                                    //position)

            float dist = (new Vector2(player.position.X, player.position.Y - player.Height * 0.40f) - entity.position).Length;
            float dist2 = (new Vector2(player.position.X, player.position.Y + player.Height * 0.30f) - entity.position).Length;

            if (dist <= (entity.Height * 0.5f ) || dist2 <= entity.Height *0.5f)
            {
                collide = true;
            }
            else
            {
                collide = false;
            }
            return collide;
        }
    }
}
