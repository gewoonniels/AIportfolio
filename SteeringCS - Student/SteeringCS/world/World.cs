using SteeringCS.behaviour;
using SteeringCS.Graph;
using SteeringCS.entity;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SteeringCS.goal;

namespace SteeringCS
{
    class World
    {
        public List<MovingEntity> entities = new List<MovingEntity>();
        public List<BaseGameEntity> objects = new List<BaseGameEntity>();
        public Vehicle Target { get; set; }
        public int Width { get; set; }
        public int Height { get; set; }
        public Graph.Graph graph = new Graph.Graph();
        public bool DrawGraph = false;

        public World(int w, int h)
        {
            Width = w;
            Height = h;
            populate();
            MakeGraph();
        }

        private void MakeGraph()
        {

            for(int i =0; i < 259; i++)
            {
                graph.AddEdge(i.ToString(), (i + 1).ToString(),1);
            }
            int count = 0;
            for (int i = 0; i < 13; i++)
            {
                for (int j = 0; j < 20; j++)
                {
                    //    Boolean AddNode = true;
                    //    foreach(BaseGameEntity obstacle in objects)
                    //    {
                    //        Console.WriteLine(j * 50 + " " + obstacle.Pos.X + " " + j * 50 + " " + (obstacle.Pos.X + 100) + " " + i * 50 + " " + obstacle.Pos.Y + " " + i * 50 + " " + (obstacle.Pos.Y + 100));
                    //        if(j * 50 > obstacle.Pos.X && j * 50 < (obstacle.Pos.X + 100) && i * 50 > obstacle.Pos.Y && i * 50 > (obstacle.Pos.Y + 100))
                    //        {
                    //            AddNode = false;
                    //        }
                    //    }
                    //    if (AddNode)
                    //    {
                    //        graph.vertices[count.ToString()].positionx = j * 50;
                    //        graph.vertices[count.ToString()].positiony = i * 50;

                    //    }
                    //    else
                    //    {
                    //        graph.vertices[count.ToString()].doNotDraw = true;
                    //    }
                    //        count++;
                    //}
                    graph.vertices[count.ToString()].positionx = j * 50;
                    graph.vertices[count.ToString()].positiony = i * 50;
                    count++;
                }
            }
        }

        private void populate()
        {
            //Add prisoners
            Prisoner p = new Prisoner(new Vector2D(10,10), this);
            p.SB = new SeekBehaviour(p);
            entities.Add(p);

            //Add police
            Police p2 = new Police(new Vector2D(400, 400), this);

            p2.currentGoal = new Goal_SeekToEntity(p2);
            entities.Add(p2);

            //Add houses
            ElectricityHouse e1 = new ElectricityHouse(new Vector2D(800, 400), this);
            ElectricityHouse e2 = new ElectricityHouse(new Vector2D(200, 200), this);
            ElectricityHouse e3 = new ElectricityHouse(new Vector2D(500, 500), this);
            objects.Add(e1);
            objects.Add(e2);
            //objects.Add(e3);

            //Target
            Target = new Vehicle(new Vector2D(100, 60), this);
            Target.VColor = Color.DarkRed;
            Target.Pos = new Vector2D(100, 40);
        }

        public void Update(float timeElapsed)
        {
            foreach (MovingEntity me in entities)
            {
                //me.SB = new SeekBehaviour(me); // restore later
                me.Update(timeElapsed);
            }  
        }

        public void Render(Graphics g)
        {
            entities.ForEach(e => e.Render(g));
            objects.ForEach(e => e.Render(g));
            if (DrawGraph)
            {
            graph.DrawGraph(g);
            }
            Target.Render(g);
        }
    }
}
