using static Obstacletask.Q1;
using static Obstacletask.ObstaclesClass;
using System.ComponentModel.Design;

namespace Obstacletask
{
    public class PathFindingClass
    {
        static List<string> Path = new List<string>();
        static List<string> PathCoordinates = new List<string>();
        public static void PathFinding()
        {
            Console.WriteLine("Enter your current location (X,Y):");
            string CurrentLocation = Console.ReadLine();
            Console.WriteLine("Enter the location of your objective (X,Y):");
            string Objective = Console.ReadLine();

            bool path = false;
            CordSplit(CurrentLocation, out int Currentx, out int Currenty);
            CordSplit(Objective, out int Objectivex, out int Objectivey);

            PathCoordinates.Add(Currentx + "," + Currenty);

            bool N = false;
            int Northx = 0;

            while (path == false)
            {
                // Calculate the cost for moving north, east, south, and west
                DistanceTo(Currentx, Currenty - 1, Objectivex, Objectivey, out double NorthToObjective);
                DistanceTo(Currentx, Currenty - 1, Currentx, Currenty, out double NorthToAgent);
                double NorthFCost = NorthToObjective + NorthToAgent;
                Console.WriteLine(NorthFCost);

                DistanceTo(Currentx + 1, Currenty, Objectivex, Objectivey, out double EastToObjective);
                DistanceTo(Currentx + 1, Currenty, Currentx, Currenty, out double EastToAgent);
                double EastFCost = EastToObjective + EastToAgent;
                Console.WriteLine(EastFCost);

                DistanceTo(Currentx, Currenty + 1, Objectivex, Objectivey, out double SouthToObjective);
                DistanceTo(Currentx, Currenty + 1, Currentx, Currenty, out double SouthToAgent);
                double SouthFCost = SouthToObjective + SouthToAgent;
                Console.WriteLine(SouthFCost);

                DistanceTo(Currentx - 1, Currenty, Objectivex, Objectivey, out double WestToObjective);
                DistanceTo(Currentx - 1, Currenty, Currentx, Currenty, out double WestToAgent);
                double WestFCost = WestToObjective + WestToAgent;
                Console.WriteLine(WestFCost);

                if (NorthFCost == EastFCost & NorthFCost == SouthFCost & NorthFCost == WestFCost)
                {
                    // If all costs are equal, a path to the objective is found
                    Console.WriteLine("The following path will take you to the objective:");
                    for (var i = 0; i < Path.Count; i++)
                    {
                        Console.Write(Path[i]);
                    }
                    path = true;
                    Console.WriteLine();
                    return;
                }

                double minimumCost = Math.Min(NorthFCost, Math.Min(EastFCost, Math.Min(SouthFCost, WestFCost)));

                // Check the lowest cost and move accordingly
                //if (NorthFCost <= EastFCost & NorthFCost <= SouthFCost & NorthFCost <= WestFCost)
                if (NorthFCost == minimumCost)
                    {
                    // Check if the north move is valid and not visited or contains an obstacle
                    // If yes, add it to the path
                    // Otherwise, try the other directions
                    if (!Obstacle.Contains(Currentx + "," + (Currenty - 1)) & !PathCoordinates.Contains(Currentx + "," + (Currenty - 1)))
                    {
                        Path.Add("N");
                        Currenty = Currenty - 1;

                        PathCoordinates.Add(Currentx + "," + Currenty);
                        Console.WriteLine(Currentx + "," + Currenty);
                    }
                    else if (!Obstacle.Contains((Currentx + 1) + "," + Currenty) & !PathCoordinates.Contains((Currentx + 1) + "," + Currenty))
                    {
                        Path.Add("E");
                        Currentx = Currentx + 1;
                        PathCoordinates.Add(Currentx + "," + Currenty);
                        Console.WriteLine(Currentx + "," + Currenty);
                    }
                    else if (!Obstacle.Contains((Currentx - 1) + "," + Currenty) & !PathCoordinates.Contains((Currentx - 1) + "," + Currenty))
                    {
                        Path.Add("W");
                        Currentx = Currentx - 1;
                        PathCoordinates.Add(Currentx + "," + Currenty);
                        Console.WriteLine(Currentx + "," + Currenty);
                    }
                    else if (!Obstacle.Contains(Currentx + "," + (Currenty + 1)) & !PathCoordinates.Contains(Currentx + "," + (Currenty + 1)))
                    {
                        Path.Add("S");
                        Currenty = Currenty + 1;
                        PathCoordinates.Add(Currentx + "," + Currenty);
                        Console.WriteLine(Currentx + "," + Currenty);
                    }
                }
               // else if (EastFCost <= NorthFCost & EastFCost <= SouthFCost & EastFCost <= WestFCost)
                else if (EastFCost == minimumCost)
                {
                    if (!Obstacle.Contains((Currentx + 1) + "," + Currenty) & !PathCoordinates.Contains((Currentx + 1) + "," + Currenty))
                    {
                        Path.Add("E");
                        Currentx = Currentx + 1;
                        PathCoordinates.Add(Currentx + "," + Currenty);
                        Console.WriteLine(Currentx + "," + Currenty);
                    }
                    else if (!Obstacle.Contains(Currentx + "," + (Currenty + 1)) & !PathCoordinates.Contains(Currentx + "," + (Currenty + 1)))
                    {
                        Path.Add("S");
                        Currenty = Currenty + 1;
                        PathCoordinates.Add(Currentx + "," + Currenty);
                        Console.WriteLine(Currentx + "," + Currenty);
                    }
                    else if (!Obstacle.Contains(Currentx + "," + (Currenty - 1)) & !PathCoordinates.Contains(Currentx + "," + (Currenty - 1)))
                    {
                        Path.Add("N");
                        Currenty = Currenty - 1;
                        PathCoordinates.Add(Currentx + "," + Currenty);
                        Console.WriteLine(Currentx + "," + Currenty);
                    }
                    else if (!Obstacle.Contains((Currentx - 1) + "," + Currenty) & !PathCoordinates.Contains((Currentx - 1) + "," + Currenty))
                    {
                        Path.Add("W");
                        Currentx = Currentx - 1;
                        PathCoordinates.Add(Currentx + "," + Currenty);
                        Console.WriteLine(Currentx + "," + Currenty);
                    }
                }
                //else if (SouthFCost <= NorthFCost & SouthFCost <= EastFCost & SouthFCost <= WestFCost)
                else if (SouthFCost == minimumCost)
                {

                    if (!Obstacle.Contains(Currentx + "," + (Currenty + 1)) & !PathCoordinates.Contains(Currentx + "," + (Currenty + 1)))
                    {
                        Path.Add("S");
                        Currenty = Currenty + 1;
                        PathCoordinates.Add(Currentx + "," + Currenty);
                        Console.WriteLine(Currentx + "," + Currenty);
                    }
                    else if (!Obstacle.Contains((Currentx + 1) + "," + Currenty) & !PathCoordinates.Contains((Currentx + 1) + "," + Currenty))
                    {
                        Path.Add("E");
                        Currentx = Currentx + 1;
                        PathCoordinates.Add(Currentx + "," + Currenty);
                        Console.WriteLine(Currentx + "," + Currenty);
                    }
                    else if (!Obstacle.Contains((Currentx - 1) + "," + Currenty) & !PathCoordinates.Contains((Currentx - 1) + "," + Currenty))
                    {
                        Path.Add("W");
                        Currentx = Currentx - 1;
                        PathCoordinates.Add(Currentx + "," + Currenty);
                        Console.WriteLine(Currentx + "," + Currenty);
                    }
                    else if (!Obstacle.Contains(Currentx + "," + (Currenty - 1)) & !PathCoordinates.Contains(Currentx + "," + (Currenty - 1)))
                    {
                        Path.Add("N");
                        Currenty = Currenty - 1;
                        PathCoordinates.Add(Currentx + "," + Currenty);
                        Console.WriteLine(Currentx + "," + Currenty);
                    }
                }
                //else if (WestFCost <= NorthFCost & WestFCost <= EastFCost & WestFCost <= SouthFCost)
                else if (WestFCost == minimumCost)
                {

                    if (!Obstacle.Contains((Currentx - 1) + "," + Currenty) & !PathCoordinates.Contains((Currentx - 1) + "," + Currenty))
                    {
                        Path.Add("W");
                        Currentx = Currentx - 1;
                        PathCoordinates.Add(Currentx + "," + Currenty);
                        Console.WriteLine(Currentx + "," + Currenty);
                    }
                    else if (!Obstacle.Contains(Currentx + "," + (Currenty + 1)) & !PathCoordinates.Contains(Currentx + "," + (Currenty + 1)))
                    {
                        Path.Add("S");
                        Currenty = Currenty + 1;
                        PathCoordinates.Add(Currentx + "," + Currenty);
                        Console.WriteLine(Currentx + "," + Currenty);
                    }
                    else if (!Obstacle.Contains(Currentx + "," + (Currenty - 1)) & !PathCoordinates.Contains(Currentx + "," + (Currenty - 1)))
                    {
                        Path.Add("N");
                        Currenty = Currenty - 1;
                        PathCoordinates.Add(Currentx + "," + Currenty);
                        Console.WriteLine(Currentx + "," + Currenty);
                    }
                    else if (!Obstacle.Contains((Currentx + 1) + "," + Currenty) & !PathCoordinates.Contains((Currentx + 1) + "," + Currenty))
                    {
                        Path.Add("E");
                        Currentx = Currentx + 1;
                        PathCoordinates.Add(Currentx + "," + Currenty);
                        Console.WriteLine(Currentx + "," + Currenty);
                    }

                }
               
            }
            // Function to calculate the Euclidean distance between two points
            static double DistanceTo(int Initialx, int Initialy, int Finalx, int Fianly, out double Distance)
            {
                Distance = Math.Sqrt(((Initialx - Finalx) * (Initialx - Finalx)) + ((Initialy - Fianly) * (Initialy - Fianly)));
                return Distance;
            }
        }
    }
}
