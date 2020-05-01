using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Stars_Game.VisualObjects
{
    internal class SpaceShip : VisualObject
    {
        public SpaceShip(Point Position, Point Direction, Size Size, object VisualObject) :
            base(Position, Direction, Size, VisualObject)
        {
        }

        public override void Draw(Graphics g)
        {
            throw new NotImplementedException();
        }

        public override void Update()
        {
            throw new NotImplementedException();
        }
    }
}
