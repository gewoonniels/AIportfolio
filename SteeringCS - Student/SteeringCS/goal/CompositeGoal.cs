using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SteeringCS.entity;

namespace SteeringCS.goal
{
     abstract class CompositeGoal : Goal
    {
        public List<Goal> SubGoals;

        public CompositeGoal(MovingEntity owner) : base(owner)
        {
        }

        public abstract override void Activate();
        public abstract override int Process();
        public abstract override void Terminate();

        public override void AddSubgoal(Goal g)
        {
            SubGoals.Add(g);
        }

        public void RemoveAllSubgoals()
        {
            foreach(Goal g in SubGoals)
            {
                g.Terminate();
                SubGoals.Remove(g);
            }
        }

        //public void ProcessSubgoals()
        //{
        //    while(SubGoals.Count() > 0 && SubGoals[0].)
        //}

    }
}
