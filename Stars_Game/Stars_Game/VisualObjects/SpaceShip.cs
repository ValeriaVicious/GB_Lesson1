using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Stars_Game.VisualObjects
{
    internal class SpaceShip : VisualObject, ICollision
    {

        private int _EnergyShip = 20;
        public int EnergyShip => _EnergyShip;
        public Rectangle Rect => new Rectangle(_Position, _Size);

        /// <summary>
        /// событие/делегат уничтоженного корабля
        /// </summary>
        public event EventHandler Destroyed;

        public SpaceShip(Point Position, Point Direction,
                         Size Size) : base(Position, Direction, new Size(), Properties.Resources.spacemonkey_fly02)
                           
        {
        }

        public override void Draw(Graphics g) 
        {
            
        }
        

        public bool CheckCollision(ICollision obj)
        {
            bool is_collision = Rect.IntersectsWith(obj.Rect);
            if (is_collision && obj is Asteroids asteroids)
            {
                ChangeEnergyShip(-asteroids.Power);
            }
            return is_collision;
        }

        public override void Update() { }

        public void ChangeEnergyShip(int delta)
        {
            _EnergyShip += delta;

            if (_EnergyShip < 0)
                Destroyed.Invoke(this, EventArgs.Empty);

        }

        public void MoveDown()
        {
            if (_Position.Y - _Size.Height < Game.Height)
                _Position.Y += _Direction.Y;
        }

        public void MoveUp()
        {
            if (_Position.Y > 0) _Position.Y -= _Direction.Y;
        }


    }
}
