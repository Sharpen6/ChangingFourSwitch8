using System;
using System.Collections.Generic;

namespace SimpleGamesSolver
{
    class Program
    {
        static void Main(string[] args)
        {
            SolveChangeFourSwitch8();
        }

        private static void SolveChangeFourSwitch8()
        {
            // Set begining layout.
            Map start = new Map(new string[] { "A", "A", "A", "A", " ", "B", "B", "B", "B" });
            // Set ending layout
            Map end = new Map(new string[] { "B", "B", "B", "B", " ", "A", "A", "A", "A" });

            Console.WriteLine("start: " + start);
            Console.WriteLine("end: " + end);

            // Search a solution by using BFS.
            List<SearchableState> solution = SearchSolutionPath(start, end);

            // Print solution
            if (solution != null)
                PrintProcedure(solution);
            else
                Console.WriteLine("no solution");

            Console.ReadKey();
        }

        /// <summary>
        /// Run BFS algorithm from a begining state to an ending state.
        /// </summary>
        /// <param name="start"></param>
        /// <param name="end"></param>
        /// <returns></returns>
        private static List<SearchableState> SearchSolutionPath(SearchableState start, SearchableState end)
        {
            Stack<SearchableState> openList = new Stack<SearchableState>();
            HashSet<SearchableState> closedList = new HashSet<SearchableState>();

            openList.Push(start);
            while (openList.Count != 0)
            {
                SearchableState current = openList.Pop();
                closedList.Add(current);
                List<SearchableState> PossibleSteps = current.GetAllNeighbors();
                foreach (var step in PossibleSteps)
                {
                    if (step.Equals(end))
                    {
                        // Constract the path using the parent state.
                        List<SearchableState> steps = new List<SearchableState>();
                        SearchableState s = current;
                        while (s != null)
                        {
                            steps.Add(s);
                            s = s.Origin;
                        }

                        steps.Reverse();
                        steps.Add(end);
                        return steps;
                    }

                    if (!closedList.Contains(step) && !openList.Contains(step))
                        openList.Push(step);
                }
            }
            return null;
        }
        private static void PrintProcedure(List<SearchableState> steps)
        {
            int iStep = 0;
            foreach (var s in steps)
            {
                iStep += 1;
                Console.WriteLine(iStep.ToString().PadRight(3) + ": " + s);
            }
        }
    }
}
