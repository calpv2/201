using static Obstacletask.Q1;
using static Obstacletask.ObstaclesClass;

namespace Obstacletask
{
    public class ObstacleMapClass
    {
        // Function to display the obstacle map
        public static void ObstacleMap()
        {

            Console.WriteLine("Enter the location of the top-left cell of the map (X,Y):");
            string topLeftInput = Console.ReadLine();
            Console.WriteLine("Enter the location of the bottom-right cell of the map (X,Y):");
            string bottomRightInput = Console.ReadLine();

            // Split user input into left and right coordinates
            CordSplit(topLeftInput, out int leftx, out int lefty);
            CordSplit(bottomRightInput, out int rightx, out int righty);

            // Calculate the number of rows and columns in the map
            int numberOfRows = (righty - lefty) + 1;
            int numberOfColumns = (rightx - leftx) + 1;

            for (int x = 0; x < numberOfRows; ++x)
            {
                for (int y = 0; y < numberOfColumns; y++)
                {
                    // Calculate the actual coordinates in the global map by adding leftx and lefty
                    if (FenceObstacle.Contains((y + leftx) + "," + (x + lefty)))
                    {
                        Console.Write("f"); // Display 'f' for Fence obstacle
                    }
                    else if (GuardObstacle.Contains((y + leftx) + "," + (x + lefty)))
                    {
                        Console.Write("g"); // Display 'g' for Guard obstacle
                    }
                    else if (SensorObstacle.Contains((y + leftx) + "," + (x + lefty)))
                    {
                        Console.Write("s"); // Display 's' for Sensor obstacle
                    }
                    else if (CameraObstacle.Contains((y + leftx) + "," + (x + lefty)))
                    {
                        Console.Write("c"); // Display 'c' for Camera obstacle
                    }
                    else if (TowerObstacle.Contains((y + leftx) + "," + (x + lefty)))
                    {
                        Console.Write("t"); // Display 't' for Tower obstacle
                    }
                    else
                    {
                        Console.Write("."); // Display '.' for empty space
                    }
                }
                Console.WriteLine();
            }
        }
    }
}
