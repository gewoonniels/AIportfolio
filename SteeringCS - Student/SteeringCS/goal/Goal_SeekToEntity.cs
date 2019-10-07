using SteeringCS.behaviour;
using SteeringCS.entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SteeringCS.goal
{
    class Goal_SeekToEntity : Goal
    {
        public Goal_SeekToEntity(MovingEntity owner) : base(owner) { }

        public override void Activate()
        {
            this.Status = 2; //active
            Random random = new Random();
            int randomObject = random.Next(0, this.Owner.MyWorld.objects.Count());
            this.Owner.SB = new SeekBehaviour(this.Owner);
        }

        public override void AddSubgoal(Goal g)
        {
            throw new NotImplementedException();
        }

        public override int Process()
        {
            if(this.Status == 1)
            {
                this.Activate();
            }
            return this.Status;
        }

        public override void Terminate()
        {
            this.Owner.SB = null;
        }
    }
}
