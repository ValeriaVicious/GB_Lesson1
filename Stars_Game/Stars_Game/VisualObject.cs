﻿using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Stars_Game
{
    internal class VisualObject
    {
        protected Point _Position;
        protected Point _Direction;
        protected Size _Size;
       

        public VisualObject(Point Position, Point Direction, Size Size)
        {
            _Position = Position;
            _Direction = Direction;
            _Size = Size;
        }

        
        public virtual void Draw(Graphics g)
        {
            g.DrawImage(Resource.powerup_banana, new RectangleF(_Position.X, _Position.Y,
                _Size.Width, _Size.Height));

        }

        public virtual void Update()
        {
            _Position.X += _Direction.X;
            _Position.Y += _Direction.Y;

            if (_Position.X < 0 || _Position.Y < 0 || _Position.X > Game.Width || _Position.Y > Game.Height)
            {
                _Direction.X *= -1;
                _Direction.Y *= -1;
            }
            
        }
    }
}
