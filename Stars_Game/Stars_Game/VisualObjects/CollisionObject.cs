﻿using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Stars_Game.VisualObjects
{
    internal abstract class CollisionObject : VisualObject, ICollision
    {
        protected CollisionObject(Point Position, Point Direction, Size Size, object VisualObject)
            : base(Position, Direction, Size, VisualObject)
        {

        }

        public Rectangle Rect
        {
            get
            {
                {
                    return new Rectangle(_Position, _Size);
                }
            }


        }
        public bool CheckCollision(ICollision obj) => Rect.IntersectsWith(obj.Rect);

    }
}
