using SteeringCS.goal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SteeringCS.entity
{

    abstract class MovingEntity : BaseGameEntity
    {
        public Vector2D Velocity { get; set; }
        public float Mass { get; set; }
        public float MaxSpeed { get; set; }
        public Vector2D Heading { get; set; }
        public Vector2D Side { get; set; }
        public Goal currentGoal;

        public SteeringBehaviour SB { get; set; }

        public MovingEntity(Vector2D pos, World w) : base(pos, w)
        {
            Mass = 30;
            MaxSpeed = 150;
            Velocity = new Vector2D();
        }

        public override void Update(float timeElapsed)
        {
            if (currentGoal != null)
            {
                currentGoal.Process();
            }
            //calculate the combined force from each steering behavior in the
            //vehicle’s list
            Vector2D SteeringForce = SB.Calculate();

            // Acceleration = Force / Mass
            Vector2D acceleration = SteeringForce.divide(Mass);

            //update velocity
            this.Velocity.Add(acceleration.Multiply(timeElapsed));

            //make sure vehicle does not exceed maximum velocity
            Velocity.truncate(MaxSpeed);
            //update the position
            this.Pos.Add(Velocity.Multiply(timeElapsed));

            //update the heading if the vehicle has a velocity greater than a very small
            //value
            if (Velocity.LengthSquared() > 0.00000001)
            {
                Heading = Velocity.Normalize();
                Side = Heading.Perp();
            }

        }

        public override string ToString()
        {
            return String.Format("{0}", Velocity);
        }
    }
}
