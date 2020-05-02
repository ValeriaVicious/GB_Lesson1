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
        private static Bitmap background;
        private static Timer __Timer;

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
            background = new Bitmap(Properties.Resources.universe_back);

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

            __Timer = new Timer { Interval = __TimerInterval };
            __Timer.Tick += OnVimerTick;
            __Timer.Start();

            game_form.KeyDown += OnFormKeyDown;

        }

        private static void OnFormKeyDown(object sender, KeyEventArgs e)
        {
            switch (e.KeyCode)
            {
                case Keys.ControlKey:
                    __Bullet = new Bullet(__SpaceShip.Rect.Y);
                    break;

                case Keys.Up:
                    __SpaceShip.MoveUp();
                    break;

                case Keys.Down:
                    __SpaceShip.MoveDown();
                    break;
            }
        }

        private static void OnVimerTick(object sender, EventArgs e)
        {
            Update();
            Draw();
        }

        public static void Load()
        {
            List<VisualObject> game_object = new List<VisualObject>();

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

            const int health_count = 10;
            const int health_size = 20;
            const int health_speed = 15;

            for (int i = 0; i < asteroid_count; i++)
                game_object.Add(new Asteroids(new Point(rnd.Next(0, Width),
                    rnd.Next(0, Height)),
                    new Point(-rnd.Next(0, asteroid_max_speed), 0), asteroid_size));

            //инициализация хилок по списку, летают но пока ничего не делают
            for (int i = 0; i < health_count; i++)
            {
                game_object.Add(new Health(new Point(rnd.Next(0, Width), rnd.Next(0, Height)),
                    new Point(-rnd.Next(0, health_speed), 0), health_size));
            }

            __Bullet = new Bullet(200);
            __GameObjects = game_object.ToArray();

            //корабль
            __SpaceShip = new SpaceShip(new Point(10, 200), new Point(50, 50), new Size(50, 30), null);
            __SpaceShip.Destroyed += OnShipDestroyed;

            
        }


        /// <summary>
        /// описание метода графики уничтожения корабля и конца игры
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private static void OnShipDestroyed(object sender, EventArgs e)
        {
            __Timer.Stop();
            var g = __Buffer.Graphics;
            g.Clear(Color.DarkRed);
            g.DrawString("Bad Monkey -\nDead Monkey!\nGame over.", new Font(FontFamily.GenericSerif, 40, FontStyle.Bold), Brushes.Gray, 300, 300);
            g.DrawImage(Properties.Resources.spacemonkey_dead02, new Point(100, 100));
            __Buffer.Render();
        }
        public static void Draw()
        {
            Graphics g = __Buffer.Graphics;
            g.Clear(Color.Black);
            g.DrawImage(background, 0, 0);
            foreach (var game_object in __GameObjects)

                game_object?.Draw(g);

            __SpaceShip?.Draw(g);
            __Bullet?.Draw(g);

            if (!__Timer.Enabled) return;

            __Buffer.Render();

        }



        public static void Update()
        {
            foreach (var game_object in __GameObjects)
            {
                game_object?.Update();
                __Bullet?.Update();

                /*if (__Bullet is null || __Bullet.Rect.Left > Width)
                {
                    Random rnd = new Random();
                    __Bullet = new Bullet(rnd.Next(0, Height));
                }*/

                for (int i = 0; i < __GameObjects.Length; i++)
                {
                    var obj = __GameObjects[i];
                    if (obj is ICollision)
                    {
                        var collision_object = (ICollision)obj;


                        __SpaceShip.CheckCollision(collision_object);//столкновение объекта с кораблем

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
