using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Stars_Game.VisualObjects
{
    /// <summary> Отдельный класс с выводом информации на экран</summary>
    internal class Game_Interface : VisualObject
    {
        public Game_Interface(Point Position, Point Direction, Size Size) : base(Position, Direction, Size)
        {
        }

        public override void Draw(Graphics g)
        {
            g.DrawString("Количество сбитых астероидов: ", new Font(FontFamily.GenericSerif, 20, FontStyle.Bold), Brushes.PeachPuff, 0, 0);
            g.DrawString("Здоровье мартышки: ", new Font(FontFamily.GenericSerif, 20, FontStyle.Bold), Brushes.PeachPuff, 0, 40);
        }

        public override void Update() { }

    }
}
