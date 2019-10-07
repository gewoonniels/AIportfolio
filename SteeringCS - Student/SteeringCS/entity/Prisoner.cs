using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SteeringCS.entity
{
    class Prisoner : MovingEntity
    {
        Image sprite = SteeringCS.Properties.Resources.prisoner;

        public Prisoner(Vector2D pos, World w) : base(pos, w)
        {
            Velocity = new Vector2D(0, 0);
            Scale = 5;
        }

        public override void Render(Graphics g)
        {
            double leftCorner = Pos.X - Scale;
            double rightCorner = Pos.Y - Scale;
            double size = Scale * 2;

            g.DrawImage(sprite, Convert.ToSingle(leftCorner), Convert.ToSingle(rightCorner));
        }
    }
}
