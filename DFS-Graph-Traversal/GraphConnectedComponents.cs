namespace Graph
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public static class GraphConnectedComponents
    {
        private static List<int>[] graph;
        private static bool[] visited;

        public static void Main()
        {
            graph = ReadGraph();
            FindGraphConnectdComponnents();
        }

        private static List<int>[] ReadGraph()
        {
            var nodesCount = int.Parse(Console.ReadLine());
            var readGraph = new List<int>[nodesCount];
            for (int i = 0; i < nodesCount; i++)
            {
                readGraph[i] = Console.ReadLine()
                    .Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries)
                    .Select(int.Parse)
                    .ToList();
            }

            return readGraph;
        }

        private static void FindGraphConnectdComponnents()
        {
            visited = new bool[graph.Length];
            for (int startNode = 0; startNode < graph.Length; startNode++)
            {
                if (!visited[startNode])
                {
                    Console.Write("Connected component:");
                    DepthFirstSearch(startNode);
                    Console.WriteLine();
                }
            }
        }

        private static void DepthFirstSearch(int node)
        {
            if (!visited[node])
            {
                visited[node] = true;
                foreach (var childNode in graph[node])
                {
                    DepthFirstSearch(childNode);
                }

                Console.Write(" " + node);
            }
        }
    }
}
