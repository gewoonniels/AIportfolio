using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SteeringCS.Graph
{
    public class Node
    {
        public string name;
        public LinkedList<Edge> neighbors;
        public int dist;
        public Node prev;
        public int scratch;
        public int positionx, positiony;
        public Boolean doNotDraw = false;

        public Node(string name)
        {
            this.name = name;
            neighbors = new LinkedList<Edge>();
            Reset();
        }

        public Node(string name, int x, int y)
        {
            this.name = name;
            neighbors = new LinkedList<Edge>();
            positionx = x;
            positiony = y;
            Reset();
        }

        public void Reset()
        {
            dist = int.MaxValue;
            prev = null;
            scratch = 0;
        }

        public virtual void Draw(Graphics g)
        {
                Pen p = new Pen(Color.Red, 2);
                SolidBrush b = new SolidBrush(Color.Red);
                g.FillEllipse(b, new Rectangle(positionx - 5, positiony - 5, 9, 9));
                foreach (Edge edge in neighbors)
                {
                    g.DrawLine(p, this.positionx, this.positiony, edge.dest.positionx, edge.dest.positiony);
                }
            


        }

        public override string ToString()
        {
            string s = name +
                       (dist != int.MaxValue ? $"({dist})" : "(-1)") +
                       (neighbors.Any() ? " --> " : string.Empty);

            foreach (Edge edge in neighbors)
            {
                s += edge.dest.name + $"({edge.cost}) ";
            }
            return s;
        }
    }
}
