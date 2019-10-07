using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SteeringCS.Graph
{
    public class Graph
    {
        public readonly Dictionary<string, Node> vertices = new Dictionary<string, Node>();

        private bool hasCycle;

        /// <summary>
        /// Adds a new edge to the graph.
        /// </summary>
        public void AddEdge(string sourceName, string destName, int cost)
        {
            Node v = GetNode(sourceName);
            Node w = GetNode(destName);
            v.neighbors.AddLast(new Edge(w, cost));
        }

        public void PrintPath(string destName)
        {
            if (!vertices.TryGetValue(destName, out Node w))
            {
                throw new NullReferenceException("There's no Node with that name.");
            }

            if (w.dist == int.MaxValue)
            {
                Console.WriteLine($"{destName} is unreachable.");
            }
            else
            {
                Console.Write($"(Cost is: {w.dist}) ");
                PrintPath(w);
                Console.WriteLine();
            }
        }

        public void Unweighted(string startName)
        {
            ClearAll();

            if (!vertices.TryGetValue(startName, out Node start))
            {
                throw new NullReferenceException("Start Node not found.");
            }

            Queue<Node> q = new Queue<Node>();
            q.Enqueue(start);
            start.dist = 0;

            while (q.Any())
            {
                Node v = q.Dequeue();

                foreach (Edge e in v.neighbors)
                {
                    Node w = e.dest;

                    if (w.dist == int.MaxValue)
                    {
                        w.dist = v.dist + 1;
                        w.prev = v;
                        q.Enqueue(w);
                    }
                }
            }
        }

        

        /// <summary>
        /// If NodeName is not present, add it to the vertices dictionary.
        /// </summary>
        /// <param name="NodeName">The name of the Node to get.</param>
        /// <returns>The Node.</returns>
        public Node GetNode(string NodeName)
        {
            if (!vertices.TryGetValue(NodeName, out Node v))
            {
                v = new Node(NodeName);
                vertices.Add(NodeName, v);
            }

            return v;
        }

        /// <summary>
        /// Recursive routine to print shortest path to dest after running shortest path algorithm. The path is know to exist.
        /// </summary>
        private void PrintPath(Node dest)
        {
            if (dest.prev != null)
            {
                PrintPath(dest.prev);
                Console.Write(" to ");
            }

            Console.Write(dest.name);
        }

        /// <summary>
        /// Initializes the Node ouput info prior to running any shortes path algorithm.
        /// </summary>
        private void ClearAll()
        {
            hasCycle = false;

            foreach (var Node in vertices)
            {
                Node.Value.Reset();
            }
        }

        public override string ToString()
        {
            return string.Join("\n", vertices.Values);
        }

        public void ShowCycles()
        {
            foreach (var Node in vertices.Values)
            {
                Console.WriteLine($"{Node.name} is part of a cycle: {HasCycle(Node.name)}");
            }
        }

        public bool HasCycle(string NodeName)
        {
            ClearAll();
            FindCycle(GetNode(NodeName));
            return hasCycle;
        }

        private void FindCycle(Node v)
        {
            v.scratch = 1;

            // Just using dist because it's available.
            v.dist = 1;

            foreach (Edge edge in v.neighbors)
            {
                if (edge.dest.scratch == 0)
                {
                    FindCycle(edge.dest);
                }
                else if (edge.dest.dist == 1)
                {
                    hasCycle = true;
                }
            }

            v.dist = 0;
        }

        public virtual void DrawGraph(Graphics g)
        {
            ConnectNodes();
            for (int i = 0; i < vertices.Count(); i++)
            {
                if (!vertices[i.ToString()].doNotDraw)
                {
                vertices[i.ToString()].Draw(g);
                }
            } 
        }

        public void ConnectNodes()
        {
            for(int i = 0; i < vertices.Count(); i++)
            {
               vertices[i.ToString()].neighbors.Clear();
            
                if( i%20 != 19)
                {

                    //check if one to the right is available
                    if (vertices.TryGetValue((i + 1).ToString(), out Node b))
                    {
                        this.AddEdge(i.ToString(), (i + 1).ToString(), 1);
                    }
                }

                if(i%20 != 0)
                {
                    //Check if one to the left is available
                    if (vertices.TryGetValue((i - 1).ToString(), out Node v))
                    {
                        this.AddEdge(i.ToString(), (i - 1).ToString(), 1);
                    }
                }

                    //check if one upstairs is available
                    if (vertices.TryGetValue((i - 20).ToString(), out Node j))
                    {
                        this.AddEdge(i.ToString(), (i - 20).ToString(), 1);
                    }

                    //check if one down stars is available
                    if (vertices.TryGetValue((i + 20).ToString(), out Node k))
                    {
                        this.AddEdge(i.ToString(), (i + 20).ToString(), 1);
                    }
                

            }
           
        }
    }

}

                
            