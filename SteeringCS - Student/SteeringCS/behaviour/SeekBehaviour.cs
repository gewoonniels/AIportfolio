using SteeringCS.entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SteeringCS.behaviour
{
    class SeekBehaviour : SteeringBehaviour
    {
        public SeekBehaviour(MovingEntity me) : base(me) { }
        
        public override Vector2D Calculate()
        {
            Vector2D targetPos = new Vector2D(ME.MyWorld.Target.Pos.X, ME.MyWorld.Target.Pos.Y);
            Vector2D DesiredVelocity = targetPos.Sub(ME.Pos).Normalize().Multiply(ME.MaxSpeed);
            return (DesiredVelocity.Sub(ME.Velocity));
        }
    }
}
