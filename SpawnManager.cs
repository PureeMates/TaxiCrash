using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Aiv.Fast2D;
using OpenTK;

namespace TaxiCrash
{
    static class SpawnManager
    {
        static private int spawnNumber;
        static private Spawn[] spawns;
        static private Vector2 position;

        static SpawnManager()
        {
            spawnNumber = 7;
            spawns = new Spawn[spawnNumber];
            position = new Vector2(45, 150);

            for (int i = 0; i < spawns.Length; i++)
            {
                spawns[i] = new Spawn(position);
                position.X += 105;
            }
        }

        static public void Update()
        {
            for (int i = 0; i < spawns.Length; i++)
            {
                spawns[i].Update();
                if (spawns[i].GetTimer().CheckTimer())
                {
                    Vehicle vehicle = new Vehicle(spawns[i].GetRandomTexture());
                    vehicle.Position = spawns[i].Position;
                    vehicle.Draw();
                }
            }
        }
    }
}
