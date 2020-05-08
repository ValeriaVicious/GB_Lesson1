 using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Stars_Game.VisualObjects
{

    internal class Asteroids : ImageObject, ICollision
    {
        public int Power { get; private set; } = 10;


        ///<summary>Добавление астероида из Ресурсов </summary>
        public Asteroids(Point Position, Point Direction,
                         int ImageSize) : base(Position, Direction, new Size(ImageSize, ImageSize),
                             Properties.Resources.object_asteroid_02)
        {

        }

        public Rectangle Rect => new Rectangle(_Position, _Size);

        public bool CheckCollision(ICollision obj) => Rect.IntersectsWith(obj.Rect);

        public override void Update()
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



