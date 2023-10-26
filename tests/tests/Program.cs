using static Obstacletask.ObstacleMapClass;
using static Obstacletask.SafeDirectionsClass;
using static Obstacletask.ObstaclesClass;
using static Obstacletask.PathFindingClass;

namespace Obstacletask
{
    public class Q1
    {
        // Main method where the program starts execution
        static void Main()
        {
            // Prompt the user for input
            UserInput();

            bool loop = true;
            while (loop == true)
            {
                Console.WriteLine("Enter code:");
                // Read the user's input
                string code = Console.ReadLine();
                // Process the user's choice based on the input code
                switch (code)
                {
                    case "g":
                        ObstacleGuard();
                        UserInput();
                        break;
                    case "f":
                        ObstacleFence();
                        UserInput();
                        break;
                    case "s":
                        ObstacleSensor();
                        UserInput();
                        break;
                    case "c":
                        ObstacleCamera();
                        UserInput();
                        break;
                    case "d":
                        // Combine obstacles and display safe directions
                        CombineObstacles();
                        SafeDirections();
                        UserInput();
                        break;
                    case "m":
                        ObstacleMap();
                        UserInput();
                        break;
                    case "p":
                        // Combine obstacles and perform path finding
                        CombineObstacles();
                        PathFinding();
                        UserInput();
                        break;
                    case "t":
                        ObstacleTower();
                        UserInput();
                        break;

                    case "x":
                        // Exit the loop and end the program
                        loop = false;
                        break;
                    default:
                        // Handle invalid input
                        Console.WriteLine("Invalid option.");
                        break;
                }
            }
        }
        // This function is used to separate user input into x and y coordinates
        public static int CordSplit(string input, out int x, out int y)
        {
            string[] splitInput = input.Split(",");

            x = int.Parse(splitInput[0]);
            y = int.Parse(splitInput[1]);
            return x + y;
        }

        // Function to handle adding a 'Guard' obstacle
        static void ObstacleGuard()
        {
            Console.WriteLine("Enter the sensor's location (X,Y):");
            GuardObstacle.Add(Console.ReadLine());
        }
        // Function to display user options
        static void UserInput()
        {
            Console.WriteLine("Select one of the following options");
            Console.WriteLine("g) Add 'Guard' obstacle");
            Console.WriteLine("f) Add 'Fence' obstacle");
            Console.WriteLine("s) Add 'Sensor' obstacle");
            Console.WriteLine("c) Add 'Camera' obstacle");
            Console.WriteLine("d) Show safe directions");
            Console.WriteLine("m) Display obstacle map");
            Console.WriteLine("p) Find safe path");
            Console.WriteLine("x) Exit");
        }
    }
}