﻿using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Stars_Game
{
    class Star : VisualObject
    {
        public Star(Point Position, Point Direction, 
            int Size) :base(Position, Direction, new Size(Size, Size))
        {

        }

        public override void Draw(Graphics g)
        {
            g.DrawImage(Resource.alien_side_green, new RectangleF(_Position.X, _Position.Y,
              _Size.Width, _Size.Height)); 
           
        }
        public override void Update()
        {
            _Position.X += _Direction.X;
            if (_Position.X < 0)
                _Position.X = Game.Width + _Size.Width;
        }

    }
}