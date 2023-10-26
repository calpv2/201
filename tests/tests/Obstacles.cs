using static Obstacletask.Q1;
using static Obstacletask.ObstacleMapClass;
using System.Runtime.InteropServices;
using System.Runtime.CompilerServices;
using Microsoft.VisualBasic;

namespace Obstacletask
{
    public class ObstaclesClass
    {
        public static List<string> Obstacle = new List<string>();

        public static List<string> GuardObstacle = new List<string>();
        public static List<string> FenceObstacle = new List<string>();
        public static List<string> SensorObstacle = new List<string>();
        public static List<string> CameraObstacle = new List<string>();
        public static List<string> TowerObstacle = new List<string>();

        public static void CombineObstacles()
        {
            Obstacle.AddRange(GuardObstacle);
            Obstacle.AddRange(FenceObstacle);
            Obstacle.AddRange(SensorObstacle);
            Obstacle.AddRange(CameraObstacle);
            Obstacle.AddRange(TowerObstacle);
        }


        public static void ObstacleFence()
        {
            Console.WriteLine("Enter the location where the fence starts (X,Y):");
            string FenceStart = Console.ReadLine();
            Console.WriteLine("Enter the location where the fence ends (X,Y):");
            string FenceEnd = Console.ReadLine();

            // Split user input into starting and ending coordinates
            CordSplit(FenceStart, out int startx, out int starty);
            CordSplit(FenceEnd, out int endx, out int endy);

            if (startx != endx)
            {
                // Calculate the length of the fence along the X-axis
                int FenceLength = Math.Abs(startx - endx);

                // Loop to add fence obstacles along the X-axis
                for (int i = 0; i < FenceLength + 1; ++i)
                {
                    // Add the fence obstacle at the current coordinate
                    FenceObstacle.Add(startx + "," + endy);

                    // Adjust the X-coordinate based on the direction
                    if (startx > endx)
                        startx--;
                    else if (startx < endx)
                        startx++;
                }
            }
            else if (starty != endy)
            {
                // Calculate the length of the fence along the Y-axis
                int FenceLength = Math.Abs(starty - endy);

                // Loop to add fence obstacles along the Y-axis
                for (int i = 0; i < FenceLength + 1; ++i)
                {
                    // Add the fence obstacle at the current coordinate
                    FenceObstacle.Add(endx + "," + starty);

                    // Adjust the Y-coordinate based on the direction
                    if (starty > endy)
                        starty--;
                    else if (starty < endy)
                        starty++;
                }
            }
        }
        public static void ObstacleSensor()
        {
            Console.WriteLine("Enter the sensor's location (X,Y):");
            string sensorLocation = Console.ReadLine();
            Console.WriteLine("Enter the sensor's range (in klicks):");
            float sensorRange = float.Parse(Console.ReadLine());

            // Split the sensor location into X and Y coordinates
            CordSplit(sensorLocation, out int centerX, out int centerY);

            // Calculate the maximum range ceiling
            int rangeCeiling = (int)Math.Ceiling(sensorRange);

            for (int x = centerX - rangeCeiling; x <= centerX + rangeCeiling; x++)
            {
                for (int y = centerY - rangeCeiling; y <= centerY + rangeCeiling; y++)
                {
                    // Calculate the distance between the current position and the sensor location
                    double distance = Math.Sqrt(Math.Pow(x - centerX, 2) + Math.Pow(y - centerY, 2));

                    // Check if the current position is within the sensor's range
                    if (distance < sensorRange)
                    {
                        SensorObstacle.Add(x + "," + y); // Add the sensor obstacle
                    }
                }
            }
        }
        public static void ObstacleTower()
        {
            // Prompt the user for the tower's location (X,Y)
            Console.WriteLine("Enter the tower's location (X,Y):");
            string towerLocation = Console.ReadLine();

            // Prompt the user for the tower's size
            Console.WriteLine("Enter the tower's size:");
            int towerSize = Convert.ToInt32(Console.ReadLine());

            // Add the tower's location to the TowerObstacle list
            TowerObstacle.Add(towerLocation);

            // Split the tower location into X and Y coordinates
            CordSplit(towerLocation, out int towerX, out int towerY);

            // Create obstacles in all four directions (up, down, left, and right) in a single loop
            for (int i = 1; i <= towerSize; i++)
            {
                // Add obstacles to the right
                TowerObstacle.Add((towerX + i) + "," + towerY);
                // Add obstacles to the left
                TowerObstacle.Add((towerX - i) + "," + towerY);
                // Add obstacles upward
                TowerObstacle.Add(towerX + "," + (towerY - i));
                // Add obstacles downward
                TowerObstacle.Add(towerX + "," + (towerY + i));
            }
        }


        public static void ObstacleCamera()
        {
            Console.WriteLine("Enter the camera's location (X,Y):");
            string CameraLocation = Console.ReadLine();
            Console.WriteLine("Enter the direction the camera is facing (n, s, e or w):");
            string CameraDirection = Console.ReadLine();
            CameraObstacle.Add(CameraLocation);

            int CameraLength = 1;
            CordSplit(CameraLocation, out int Camerax, out int Cameray);

            for (int i = 0; i < 100; i++)
            {
                // Check the camera's direction to determine its movement and add obstacles accordingly
                if (CameraDirection == "n")
                {
                    // Add the camera's new location when facing north
                    CameraObstacle.Add(Camerax + "," + Cameray--);
                    // Add obstacles to the left and right of the camera's path
                    for (int j = 1; j < CameraLength; j++)
                    {
                        CameraObstacle.Add(Camerax - j + "," + (Cameray + 1));
                        CameraObstacle.Add(Camerax + j + "," + (Cameray + 1));
                    }
                    CameraLength++;
                }

                if (CameraDirection == "e")
                {
                    // Add the camera's new location when facing east
                    CameraObstacle.Add(Camerax++ + "," + Cameray);
                    // Add obstacles above and below the camera's path
                    for (int j = 1; j < CameraLength; j++)
                    {
                        CameraObstacle.Add(Camerax - 1 + "," + (Cameray - j));
                        CameraObstacle.Add(Camerax - 1 + "," + (Cameray + j));
                    }
                    CameraLength++;
                }
                if (CameraDirection == "s")
                {
                    // Add the camera's new location when facing south
                    CameraObstacle.Add(Camerax + "," + Cameray++);
                    // Add obstacles to the left and right of the camera's path
                    for (int j = 1; j < CameraLength; j++)
                    {
                        CameraObstacle.Add(Camerax - j + "," + (Cameray - 1));
                        CameraObstacle.Add(Camerax + j + "," + (Cameray - 1));
                    }
                    CameraLength++;
                }

                if (CameraDirection == "w")
                {
                    // Add the camera's new location when facing west
                    CameraObstacle.Add(Camerax-- + "," + Cameray);
                    // Add obstacles above and below the camera's path
                    for (int j = 1; j < CameraLength; j++)
                    {
                        CameraObstacle.Add(Camerax + 1 + "," + (Cameray - j));
                        CameraObstacle.Add(Camerax + 1 + "," + (Cameray + j));
                    }
                    CameraLength++;
                }

            }

        }
    }
}
