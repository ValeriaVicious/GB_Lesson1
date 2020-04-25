﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Linq;
using System.Net.NetworkInformation;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.VisualStyles;


namespace Stars_Game
{

    internal static class Game
    {
        
        private static BufferedGraphicsContext __Context;
        private static BufferedGraphics __Buffer;
        private static VisualObject[] __GameObjects;

        public static int Width { get; set; }
        public static int Height { get; set; }
     


    public static void Initialize(Form form)
        {
            Width = form.Width;
            Height = form.Height;

            __Context = BufferedGraphicsManager.Current;
            Graphics g = form.CreateGraphics();
            __Buffer = __Context.Allocate(g, new Rectangle(0, 0, Width, Height));

            Timer timer = new Timer { Interval = 100 };
            timer.Tick += OnVimerTick;
            timer.Start();
        }

        private static void OnVimerTick(object sender, EventArgs e)
        {
            Update();
            Draw();
        }

      
        public static void Draw()
        {

            Graphics g = __Buffer.Graphics;
            g.Clear(Color.Black);

            Image newImage = Image.FromFile("universe-2742113_1920.jpg");
           
            g.DrawImage(newImage, new RectangleF(0, 0,
              Width, Height));
          

            foreach (var game_object in __GameObjects)

                game_object.Draw(g);

            __Buffer.Render();

        }

        public static void Load()
        {
            __GameObjects = new VisualObject[30];

            for (int i = 0; i < __GameObjects.Length / 2; i++)
            {
                __GameObjects[i] = new VisualObject
                    (new Point(600, i * 20),
                    new Point(15 - i, 20 - i),
                    new Size(20, 20));
            }

            for (int i = __GameObjects.Length / 2; i < __GameObjects.Length; i++)
            {
                __GameObjects[i] = new Star(
                    new Point(600, (int)i / 2 * 20),
                    new Point(-i, 0), 30);
            }
        }

        public static void Update()
        {
            foreach (var game_object in __GameObjects)
            {
                game_object.Update();
            }
        }
    }
}
namespace Stars_Game
{

    internal static class Game
    {
           private static BufferedGraphicsContext __Context;
        private static BufferedGraphics __Buffer;
        private static VisualObject[] __GameObjects;

        public static int Width { get; set; }
        public static int Height { get; set; }
     


    public static void Initialize(Form form)
        {
            Width = form.Width;
            Height = form.Height;

            __Context = BufferedGraphicsManager.Current;
            Graphics g = form.CreateGraphics();
            __Buffer = __Context.Allocate(g, new Rectangle(0, 0, Width, Height));

            Timer timer = new Timer { Interval = 100 };
            timer.Tick += OnVimerTick;
            timer.Start();
        }

        private static void OnVimerTick(object sender, EventArgs e)
        {
            Update();
            Draw();
        }

      
        public static void Draw()
        {

            Graphics g = __Buffer.Graphics;
            g.Clear(Color.Black);

            Image newImage = Image.FromFile("universe-2742113_1920.jpg");
           
            g.DrawImage(newImage, new RectangleF(0, 0,
              Width, Height));
          

            foreach (var game_object in __GameObjects)

                game_object.Draw(g);

            __Buffer.Render();

        }

        public static void Load()
        {
            __GameObjects = new VisualObject[30];

            for (int i = 0; i < __GameObjects.Length / 2; i++)
            {
                __GameObjects[i] = new VisualObject
                    (new Point(600, i * 20),
                    new Point(15 - i, 20 - i),
                    new Size(20, 20));
            }

            for (int i = __GameObjects.Length / 2; i < __GameObjects.Length; i++)
            {
                __GameObjects[i] = new Star(
                    new Point(600, (int)i / 2 * 20),
                    new Point(-i, 0), 30);
            }
        }

        public static void Update()
        {
            foreach (var game_object in __GameObjects)
            {
                game_object.Update();
            }
        }
    }
}
namespace Stars_Game
{

    internal static class Game
    {
      
        private const int __TimerInterval = 100;

        private static BufferedGraphicsContext __Context;
        private static BufferedGraphics __Buffer;
        private static VisualObject[] __GameObjects;

        public static int Width { get; set; }
        public static int Height { get; set; }
     

    public static void Initialize(Form form)
        {
            Width = form.Width;
            Height = form.Height;

            __Context = BufferedGraphicsManager.Current;
            Graphics g = form.CreateGraphics();
            __Buffer = __Context.Allocate(g, new Rectangle(0, 0, Width, Height));

            Timer timer = new Timer {Inteval = __TimerInterval};
            timer.Tick += OnVimerTick;
            timer.Start();
        }

        private static void OnVimerTick(object sender, EventArgs e)
        {
            Update();
            Draw();
        }

      
        public static void Draw()
        {

            Graphics g = __Buffer.Graphics;
            g.Clear(Color.Black);

            Image newImage = Image.FromFile("universe-2742113_1920.jpg");
           
            g.DrawImage(newImage, new RectangleF(0, 0,
              Width, Height));
          

            foreach (var game_object in __GameObjects)

                game_object.Draw(g);

            __Buffer.Render();

        }

        public static void Load()
        {
            __GameObjects = new VisualObject[30];

            for (int i = 0; i < __GameObjects.Length / 2; i++)
            {
                __GameObjects[i] = new VisualObject
                    (new Point(600, i * 20),
                    new Point(15 - i, 20 - i),
                    new Size(20, 20));
            }

            for (int i = __GameObjects.Length / 2; i < __GameObjects.Length; i++)
            {
                __GameObjects[i] = new Star(
                    new Point(600, (int)i / 2 * 20),
                    new Point(-i, 0), 30);
            }
        }

        public static void Update()
        {
            foreach (var game_object in __GameObjects)
            {
                game_object.Update();
            }
        }
    }
}
