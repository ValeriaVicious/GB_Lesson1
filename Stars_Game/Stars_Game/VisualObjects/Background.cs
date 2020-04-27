using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Stars_Game.VisualObjects
{

    internal abstract class Background : ImageObject
    {

        ///<summary>Добавление картинки для фона из Ресурсов </summary>
        public Background(Point Position, Point Direction,
                        int ImageSize) : base(Position, Direction, new Size(ImageSize, ImageSize), null)
        {
            
        }

        public override void Draw(Graphics g)
        {
            
        }

        public override void Update()
        {
            throw new NotImplementedException();
        }
    }

}

