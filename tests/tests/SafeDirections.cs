using static Obstacletask.Q1;
using static Obstacletask.ObstacleMapClass;
using static Obstacletask.ObstaclesClass;

namespace Obstacletask
{
    public class SafeDirectionsClass
    {
        public static void SafeDirections()
        {
            Console.WriteLine("Enter your current location (X,Y):");
            string AgentPosition = Console.ReadLine();
            CordSplit(AgentPosition, out int Currentx, out int Currenty);
            bool N = false;
            bool S = false;
            bool E = false;
            bool W = false;

            // Check if the agent's current location is compromised by an obstacle
            if (Obstacle.Contains(Currentx + "," + Currenty))
            {
                Console.WriteLine("Agent, your location is compromised. Abort mission.");
                return;
            }

            // Check if it's safe to move in each of the cardinal directions
            if (!Obstacle.Contains((Currentx - 1) + "," + Currenty)) { W = true; }
            if (!Obstacle.Contains((Currentx + 1) + "," + Currenty)) { E = true; }
            if (!Obstacle.Contains(Currentx + "," + (Currenty + 1))) { S = true; }
            if (!Obstacle.Contains(Currentx + "," + (Currenty - 1))) { N = true; }

            // Display safe directions for the agent
            if (N || S || E || W == true)
            {
                Console.Write("You can safely take any of the following directions: ");

                if (N) { Console.Write("N"); }
                if (S) { Console.Write("S"); }
                if (E) { Console.Write("E"); }
                if (W) { Console.Write("W"); }
            }
            else
            {
                Console.WriteLine("You cannot safely move in any direction. Abort mission.");
            }
            Console.WriteLine();
        }
    }
}