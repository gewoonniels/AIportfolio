using SteeringCS.entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SteeringCS.goal
{
    abstract class Goal
    {
        public Goal(MovingEntity owner)
        {
            this.Status = 1; //inactive
            this.Owner = owner;
        }

        public MovingEntity Owner;
        public int Status; //1 inactive 2 active 3completed 4 failed


        public abstract void Activate();
        public abstract int Process();
        public abstract void Terminate();
        public abstract void AddSubgoal(Goal g);
    }
}
