using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Stars_Game.VisualObjects
{
    /// <summary>Класс объекта для пополнения здоровья игрока</summary>
    internal class Health : ImageObject, ICollision
    {
        public int Health_Power { get; private set; } = 20;
        public Health(Point Position, Point Direction, int ImageSize) : 
            base(Position, Direction, new Size(ImageSize, ImageSize), Properties.Resources.powerup_banana)
        {
        }

        public Rectangle Rect => new Rectangle();

        public bool CheckCollision(ICollision obj) => Rect.IntersectsWith(obj.Rect);
        

        public override void Update()//доработать
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
