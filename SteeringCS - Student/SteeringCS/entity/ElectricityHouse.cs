using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SteeringCS.entity
{
    class ElectricityHouse : BaseGameEntity
    {
        Image sprite = SteeringCS.Properties.Resources.lighthouse;
        int scale = 100;

        public ElectricityHouse(Vector2D pos, World w) : base(pos, w)
        {

        }

        public override void Render(Graphics g)
        {
            double leftCorner = Pos.X - Scale;
            double rightCorner = Pos.Y - Scale;
            double size = Scale * 2;

            g.DrawImage(sprite, Convert.ToSingle(leftCorner), Convert.ToSingle(rightCorner));
        }

        public override void Update(float delta)
        {
            throw new NotImplementedException();
        }
    }
}
