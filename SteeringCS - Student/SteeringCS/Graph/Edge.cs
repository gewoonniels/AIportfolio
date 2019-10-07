using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SteeringCS.Graph
{
    public class Edge
    {
        /// <summary>
        /// Second vertex in Edge.
        /// </summary>
        public Node dest;

        /// <summary>
        /// Edge cost.
        /// </summary>
        public int cost;

        public Edge(Node dest, int cost)
        {
            this.dest = dest;
            this.cost = cost;
        }
    }
}
