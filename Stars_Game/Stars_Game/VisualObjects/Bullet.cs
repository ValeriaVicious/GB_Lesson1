using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Stars_Game.VisualObjects
{
    /// <summary>Класс "Пуля"</summary>
    internal class Bullet : CollisionObject
    {
        private const int __BulletSpeed = 3;
        private const int __BulletSizeX = 35;
        private const int __BulletSizeY = 25;
        public Bullet(int Position)
            : base(new Point(0, Position), Point.Empty,
                 new Size(__BulletSizeX, __BulletSizeY), null)
        {

        }

        public override void Draw(Graphics g)
        {
            g.DrawImage(Properties.Resources.powerup_blue, new Rectangle(_Position, _Size));
            
        }



        public override void Update()
        {
            _Position = new Point(_Position.X + __BulletSpeed, _Position.Y);
        }

        public static implicit operator List<object>(Bullet v)
        {
            throw new NotImplementedException();
        }
    }


}
