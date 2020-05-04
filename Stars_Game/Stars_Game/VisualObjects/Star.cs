using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Stars_Game.VisualObjects
{
    class Star : VisualObject
    {
        public Star(Point Position, Point Direction,
            int Size) : base(Position, Direction, new Size(Size, Size))
        {

        }

        public override void Draw(Graphics g)
        {
            g.DrawImage(Properties.Resources.alien_side_green, new RectangleF(_Position.X, _Position.Y,
              _Size.Width, _Size.Height));

        }
        public override void Update()
        {
            _Position.X += _Direction.X;
            _Position.Y += _Direction.Y;
            if (_Position.X <= 0 || _Position.X + _Size.Width >= Game.Width)
                _Direction.X *= -1;
            if (_Position.Y <= 0 || _Position.Y + _Size.Height >= Game.Height)
                _Direction.Y *= -1;
        }

    }
}
