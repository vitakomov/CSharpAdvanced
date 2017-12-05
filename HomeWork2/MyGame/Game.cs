using System;
using System.Windows.Forms;
using System.Drawing;

namespace MyGame
{
    static class Game
    {
        private static BufferedGraphicsContext _context;
        public static BufferedGraphics Buffer;
        public static int Width { get; set; }
        public static int Height { get; set; }
        static Game()
        {
        }
        
        public static Asteroid[] asteroids;
        public static Bullet bullet;
        public static void Load()
        {
            Random rnd = new Random();
            int s = 0;
            asteroids = new Asteroid[30];
            for (int i = 0; i < asteroids.Length; i++)
            { s = rnd.Next(10, 30);  asteroids[i] = new Asteroid(new Point(rnd.Next(20, 1900), rnd.Next(20, 1000)), new Point(rnd.Next(3, 10), rnd.Next(3, 10)), new Size(s, s)); }
            bullet = new Bullet(new Point(0, rnd.Next(20, 1000)), new Point(rnd.Next(30, 50), 0), new Size(1, 5));
        }

        public static void Init(Form form)
        {
            Graphics g;
            _context = BufferedGraphicsManager.Current;
            g = form.CreateGraphics();
            Width = form.Width;
            Height = form.Height;
            if (Width < 2000 && Height < 2000 && Width > 0 && Height > 0)
                Buffer = _context.Allocate(g, new Rectangle(0, 0, Width, Height));
            else throw new ArgumentOutOfRangeException("Не правильные размеры!");
        }
        public static void Draw()
        {
            Buffer.Graphics.Clear(Color.Black);
            foreach (Asteroid obj in asteroids)
                obj.Draw();
            bullet.Draw();
            Buffer.Render();
        }
        public static void Update()
        {
            foreach (Asteroid a in asteroids)
            {
                a.Update();
                if (a.Collision(bullet)) { Random rnd = new Random(); bullet = new Bullet(new Point(0, rnd.Next(20, 600)), new Point(rnd.Next(3, 10), 0), new Size(1, 3)); }
            }
            bullet.Update();
        }

    }
}
