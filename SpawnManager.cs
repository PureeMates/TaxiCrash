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
        private static string[] textures;

        static private int spawnNumber;
        static private Spawn[] spawns;
        static private Vector2 position;

        private static int vehiclesNumber;
        private static Queue<Vehicle> vehicles;
        private static List<Vehicle> activeVehicles;

        public static bool Stopped;

        static SpawnManager()
        {
            textures = new string[] { "Assets/Police.png", "Assets/Ambulance.png", "Assets/Audi.png" };

            spawnNumber = 7;
            spawns = new Spawn[spawnNumber];
            position = new Vector2(45, -150);

            for (int i = 0; i < spawns.Length; i++)
            {
                spawns[i] = new Spawn(position);
                position.X += 105;
            }

            vehiclesNumber = 6;
            vehicles = new Queue<Vehicle>(vehiclesNumber);
            activeVehicles = new List<Vehicle>();

            for (int i = 0; i < vehiclesNumber; i++)
            {
                vehicles.Enqueue(new Vehicle(GetRandomTexture()));
            }

            Stopped = false;
        }
        
        public static List<Vehicle> GetActiveVehicles()
        {
            return activeVehicles;
        }

        public static void Update()
        {
            if(!Stopped)
            {
                for (int i = 0; i < spawns.Length; i++)
                {
                    spawns[i].Update();
                    if (vehicles.Count > 0 && spawns[i].GetTimer().CheckTimer())
                    {
                        Vehicle vehicle = vehicles.Dequeue();
                        activeVehicles.Add(vehicle);
                        vehicle.Position = spawns[i].Position;
                    }
                }

                for (int i = 0; i < activeVehicles.Count; i++)
                {
                    activeVehicles[i].Update();
                }
            }
        }

        public static void Draw()
        {
            for (int i = 0; i < activeVehicles.Count; i++)
            {
                activeVehicles[i].Draw();
            }
        }

        public static void ResetVehicle(Vehicle vehicle)
        {
            activeVehicles.Remove(vehicle);
            vehicle.SetTexture(GetRandomTexture());
            vehicle.Gained = false;
            vehicles.Enqueue(vehicle);
        }

        private static Texture GetRandomTexture()
        {
            int rand = RandomGen.GetRandomInt(0, textures.Length);
            return new Texture(textures[rand]);
        }

        public static void Stop()
        {

            foreach (Vehicle vehicle in activeVehicles)
            {
                Stopped = true;
                vehicle.Stop();
            }
        }
    }
}
