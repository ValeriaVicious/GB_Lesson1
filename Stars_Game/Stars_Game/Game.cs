using System;
using System.Collections.Generic;
using System.Collections;
using System.ComponentModel;
using System.Drawing;
using System.Linq;
using System.Net.NetworkInformation;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.VisualStyles;
using Stars_Game.VisualObjects;
using System.IO;

namespace Stars_Game
{
    /// <summary> Класс игровой логики </summary>
    internal static class Game
    {
        /// <summary>Константа Интервала времени</summary>
        private const int __TimerInterval = 100;
        private static BufferedGraphicsContext __Context;
        private static BufferedGraphics __Buffer;
        private static List<VisualObject> __GameObjects = new List<VisualObject>();
        private static List<Asteroids> __Asteroids = new List<Asteroids>();
        private static List<Health> __Healths = new List<Health>();
        private static Bullet __Bullet;
        private static SpaceShip __SpaceShip;
        private static Bitmap background;
        private static Timer __Timer;
        private static int asteroid_score = 0;
        private static int health_count = 0;
        private static Game_Interface __Interface;
        private static Random rnd = new Random();

        /// <summary> Ширина игровой формы </summary>
        public static int Width { get; private set; }
        /// <summary> Высота игровой формы </summary>
        public static int Height { get; private set; }



        /// <summary> Инициализация игровой логики </summary>

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

            for (int i = 0; i < 10; i++)
            {
                __GameObjects.Add(new Star(
                    new Point(600, i / 2 * 20),
                    new Point(-i, 0), 30));

            }


            const int asteroid_count = 10;
            const int asteroid_size = 25;
            const int asteroid_max_speed = 20;

            const int health_count = 10;
            const int health_size = 25;
            const int health_speed = 20;

            for (int i = 0; i < asteroid_count; i++)
                __Asteroids.Add(new Asteroids(new Point(rnd.Next(150, Width),
                    rnd.Next(150, Height)),
                    new Point(-rnd.Next(0, asteroid_max_speed), 0), asteroid_size));

            for (int i = 0; i < health_count; i++)
            {
                __Healths.Add(new Health(new Point(rnd.Next(0, Width), rnd.Next(0, Height)),
                    new Point(-rnd.Next(0, health_speed), 0), health_size));
            }

            __Bullet = new Bullet(200);
            __SpaceShip = new SpaceShip(new Point(10, 200), new Point(50, 50), new Size(50, 30), null);
            __SpaceShip.Destroyed += OnShipDestroyed;



        }

        /// <summary>Метод регенерации астероидов</summary>
        public static void RegenerateAsteroids()
        {
            const int asteroid_count = 10;
            const int asteroid_size = 25;
            const int asteroid_max_speed = 22;

            for (int i = 0; i < asteroid_count + 1; i++)
            {
                __Asteroids.Add(new Asteroids(new Point(rnd.Next(200, Width), rnd.Next(200, Height)),
                    new Point(-rnd.Next(0, asteroid_max_speed)), asteroid_size));
            }

        }

        /// <summary>описание метода графики уничтожения корабля и конца игры</summary>
        private static void OnShipDestroyed(object sender, EventArgs e)
        {
            __Timer.Stop();
            var g = __Buffer.Graphics;
            g.Clear(Color.DarkRed);
            g.DrawString("Bad Monkey -\nDead Monkey!\nGame over.", new Font(FontFamily.GenericSerif, 40, FontStyle.Bold), Brushes.Gray, 200, 200);
            g.DrawImage(Properties.Resources.spacemonkey_dead02, new Point(200, 100));
            __Buffer.Render();
        }


        public static void Draw()
        {
            Graphics g = __Buffer.Graphics;
            g.Clear(Color.Black);
            g.DrawImage(background, 0, 0);

            __Interface = new Game_Interface(new Point(0, 0), new Point(0, 0), new Size(0, 0));
            g.DrawString(" " + asteroid_score, new Font(FontFamily.GenericSerif, 20, FontStyle.Bold), Brushes.PeachPuff, 400, 0);
            g.DrawString(" " + __SpaceShip.EnergyShip, new Font(FontFamily.GenericSerif, 20, FontStyle.Bold), Brushes.PeachPuff, 265, 40);
            __Interface.Draw(g);

            foreach (var game_object in __GameObjects)

                game_object?.Draw(g);

            foreach (Asteroids asteroids in __Asteroids)
            {
                asteroids.Draw(g);
            }

            foreach (Health health in __Healths)
            {
                health.Draw(g);
            }

            __SpaceShip?.Draw(g);
            __Bullet?.Draw(g);

            if (__SpaceShip != null)

                if (!__Timer.Enabled) return;

            __Buffer.Render();

        }

        public static void Update()
        {
            foreach (VisualObject game_object in __GameObjects)
            {
                game_object?.Update();
                __Bullet?.Update();
            }

            foreach (Asteroids asteroids in __Asteroids)
            {
                asteroids.Update();
            }

            foreach (Health health in __Healths)
            {
                health.Update();
            }

            for (int i = 0; i < __Asteroids.Count; i++)
            {
                var obj = __Asteroids[i];
                if (obj is ICollision)
                {
                    var collision_object = (ICollision)obj;

                    if (__Bullet != null)
                        if (__Bullet.CheckCollision(collision_object))
                        {
                            __Bullet = null;
                            __Asteroids.RemoveAt(i);
                            asteroid_score++;
                        }

                    if (__Asteroids.Count == 0)
                    {
                        RegenerateAsteroids();
                    }

                }

                if (__SpaceShip.CheckCollision(obj))
                {
                    __SpaceShip.EnergyLow(rnd.Next(1, 10));

                    if (__SpaceShip.EnergyShip <= 0) __SpaceShip.Update();

                }

            }

            for (int i = 0; i < __Healths.Count; i++)
            {
                var obj = __Healths[i];
                if (obj is ICollision)
                {
                    var collision_object = (ICollision)obj;
                }

                if (__SpaceShip.CheckCollision(obj))
                {
                    __SpaceShip.EnergyHigh(rnd.Next(1, 20));

                    __SpaceShip.Update();

                }

            }
        }

    }
}


