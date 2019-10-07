using SteeringCS.entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SteeringCS.behaviour
{
    class FleeBehaviour : SteeringBehaviour
    {
        public FleeBehaviour(MovingEntity me) : base(me) { }

        public override Vector2D Calculate()
        {
           // enum Speed { slow = 3, normal = 2, fast = 1 };

        Vector2D targetPos = new Vector2D(ME.MyWorld.Target.Pos.X, ME.MyWorld.Target.Pos.Y);

            Vector2D ToTarget = targetPos.Sub(ME.Pos);
            double dist = ToTarget.Length();

            if(dist > 0)
            {
                const double DecelerationTweaker = 0.3;
            }
            return new Vector2D(0, 0);
            
        }
    
    }
}
