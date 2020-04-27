using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Linq;
using System.Net.NetworkInformation;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.VisualStyles;
using Stars_Game.VisualObjects;

namespace Stars_Game
{
    /// <summary> Класс игровой логики </summary>
    internal static class Game
    {
        /// <summary>Константа Интервала времени</summary>
        private const int __TimerInterval = 100;
        private static BufferedGraphicsContext __Context;
        private static BufferedGraphics __Buffer;
        private static VisualObject[] __GameObjects;
        private static Bullet __Bullet;
        private static SpaceShip __SpaceShip;

        /// <summary> Ширина игровой формы </summary>
        public static int Width { get; private set; }
        /// <summary> Высота игровой формы </summary>
        public static int Height { get; private set; }


        /// <summary> Инициализация игровой логики </summary>
        /// <param name="form">Игровая форма</param>
        public static void Initialize(Form game_form)
        {
            Width = game_form.Width;
            Height = game_form.Height;

            if (game_form.Width < 0 || game_form.Width > 1000)
            {
                throw new ArgumentOutOfRangeException("Исключение. Ширина формы меньше 0 или больше 1000");
            }

            if (game_form.Height < 00 || game_form.Width > 1000)
            {
                throw new ArgumentOutOfRangeException("Исключение. Высота формы меньше 0 или больше 1000");


            }


            __Context = BufferedGraphicsManager.Current;
            Graphics g = game_form.CreateGraphics();
            __Buffer = __Context.Allocate(g, new Rectangle(0, 0, Width, Height));

            Timer timer = new Timer { Interval = __TimerInterval };
            timer.Tick += OnVimerTick;
            timer.Start();
        }

        private static void OnVimerTick(object sender, EventArgs e)
        {
            Update();
            Draw();
        }

        public static void Load()
        {
            List<VisualObject> game_object = new List<VisualObject>();

            /* for (int i = 0; i < 30; i++)
             *//*{
                 game_object.Add(new VisualObject
                     (new Point(600, i * 20),
                     new Point(15 - i, 20 - i),
                     new Size(20, 20)));
             }*/


            for (int i = 0; i < 10; i++)
            {
                game_object.Add(new Star(
                    new Point(600, i / 2 * 20),
                    new Point(-i, 0), 30));

            }

            Random rnd = new Random();

            const int asteroid_count = 10;
            const int asteroid_size = 25;
            const int asteroid_max_speed = 20;

            for (int i = 0; i < asteroid_count; i++)
                game_object.Add(new Asteroids(new Point(rnd.Next(0, Width),
                    rnd.Next(0, Height)),
                    new Point(-rnd.Next(0, asteroid_max_speed), 0), asteroid_size));


            __Bullet = new Bullet(200);
            __GameObjects = game_object.ToArray();

        }

        public static void Draw()
        {

            Graphics g = __Buffer.Graphics;
            g.Clear(Color.Black);

            foreach (var game_object in __GameObjects)

                game_object?.Draw(g);

            __Bullet?.Draw(g);
            __Buffer.Render();
            

        }



        public static void Update()
        {
            foreach (var game_object in __GameObjects)
            {
                game_object?.Update();
                __Bullet?.Update();

                if (__Bullet is null || __Bullet.Rect.Left > Width)
                {
                    Random rnd = new Random();
                    __Bullet = new Bullet(rnd.Next(0, Height));
                }

                for (int i = 0; i < __GameObjects.Length; i++)
                {
                    var obj = __GameObjects[i];
                    if (obj is ICollision)
                    {
                        var collision_object = (ICollision)obj;
                        if (__Bullet != null)
                            if (__Bullet.CheckCollision(collision_object))
                            {
                                __Bullet = null;
                                __GameObjects[i] = null;
                            }
                    }
                }
            }
        }
    }
}
