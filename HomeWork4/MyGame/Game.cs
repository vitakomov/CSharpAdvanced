using System;
using System.Windows.Forms;
using System.Drawing;
using System.Collections.Generic;

namespace MyGame
{
    static class Game
    {
        public delegate void ConsoleMessage<T>(T arg);
        public static Timer timer = new Timer();
        public static Random Rnd = new Random();
        private static BufferedGraphicsContext _context;
        public static BufferedGraphics Buffer;
        public static int Count { get; set; }
        public static int Width { get; set; }
        public static int Height { get; set; }
        private static Ship ship = new Ship(new Point(10, 400), new Point(5, 5), new Size(10, 10));
        static Game()
        {
        }
        //public static Asteroid[] asteroids;
        //public static BaseObject[] objs;
        //public static Bullet bullet;
        public static Heal heal;
        private static List<Bullet> bullets = new List<Bullet>();
        private static List<Asteroid> asteroids = new List<Asteroid>();
        public static void Load()
        {
            Random rnd = new Random();
            int s = 0;
            //asteroids = new Asteroid<30>;
            for (int i = 0; i < 30; i++)
            { s = rnd.Next(10, 30);  asteroids.Add(new Asteroid(new Point(rnd.Next(20, 1900), rnd.Next(20, 1000)), new Point(rnd.Next(3, 10), rnd.Next(3, 10)), new Size(s, s))); }
            heal = new Heal(new Point(Game.Width, rnd.Next(20, 1000)), new Point(rnd.Next(20, 50), rnd.Next(20, 50)), new Size(5, 5));
            //bullet = new Bullet(new Point(ship.Rect.X + 60, ship.Rect.Y + 30), new Point(rnd.Next(30, 50), 0), new Size(1, 5));
        }

        public static void Init(Form form)
        {
            Graphics g;
            _context = BufferedGraphicsManager.Current;
            g = form.CreateGraphics();
            Width = form.Width;
            Height = form.Height;
            Count = 0;
            if (Width < 2000 && Height < 2000 && Width > 0 && Height > 0)
                Buffer = _context.Allocate(g, new Rectangle(0, 0, Width, Height));
            else throw new ArgumentOutOfRangeException("Не правильные размеры!");
            form.KeyDown += Form_KeyDown;
            Ship.MessageDie += Finish;
        }
        public static void Draw()
        {
            Buffer.Graphics.Clear(Color.Black);
            //foreach (BaseObject obj in objs)
            //    obj.Draw();
            foreach (Asteroid a in asteroids)
            {
                a?.Draw();
            }
            heal?.Draw();
            //bullet?.Draw();
            foreach (Bullet b in bullets) b.Draw();
            ship?.Draw();
            if (ship != null)
                Buffer.Graphics.DrawString("Energy:" + ship.Energy, SystemFonts.DefaultFont, Brushes.White, 0, 0);
            Buffer.Render();
        }
        //public static void Update()
        //{
        //    ConsoleMessage<string> strTarget = new ConsoleMessage<string>(StringTarget);
        //    //foreach (BaseObject obj in objs) obj.Update();
        //    //bullet?.Update();
        //    foreach (Bullet b in bullets) b.Update();
        //    heal?.Update();
        //    if (heal != null && heal.Collision(ship))
        //    {
        //        if (ship.Energy <= 90) { ship?.EnergyHeal(10); strTarget("Ship is healed"); }
        //        else ship.EnergyClear();
        //        Random rnd = new Random();
        //        heal = new Heal(new Point(Game.Width, rnd.Next(20, 1000)), new Point(rnd.Next(3, 10), rnd.Next(3, 10)), new Size(5, 5));
        //    }
        //    for (var i = 0; i < asteroids.Length; i++)
        //    {
        //        if (asteroids[i] == null) continue;
        //        asteroids[i].Update();
        //        if (bullet != null && bullet.Collision(asteroids[i]))
        //        {
        //            System.Media.SystemSounds.Hand.Play();
        //            asteroids[i] = null;
        //            bullet = null;
        //            Count++;
        //            strTarget("Asteroid is hit");
        //            continue;
        //        }
        //        if (!ship.Collision(asteroids[i])) continue;
        //        var rnd = new Random();
        //        ship?.EnergyLow(rnd.Next(1, 10));
        //        strTarget("Ship is hit");
        //        System.Media.SystemSounds.Asterisk.Play();
        //        if (ship.Energy <= 0) ship?.Die();
        //    }
        //}
        public static void Update()
        {
            //foreach (BaseObject obj in _objs) obj.Update();
            ConsoleMessage<string> strTarget = new ConsoleMessage<string>(StringTarget);
            foreach (Bullet b in bullets) b.Update();
            heal?.Update();
            int c = 30;
            if (heal != null && heal.Collision(ship))
            {
                if (ship.Energy <= 90) { ship?.EnergyHeal(10); strTarget("Ship is healed"); }
                else ship.EnergyClear();
                Random rnd = new Random();
                heal = new Heal(new Point(Game.Width, rnd.Next(20, 1000)), new Point(rnd.Next(3, 10), rnd.Next(3, 10)), new Size(5, 5));
            }
            for (var i = 0; i < asteroids.Count; i++)
            {
                if (asteroids[i] == null) continue;
                asteroids[i].Update();
                for (int j = 0; j < bullets.Count; j++)
                    if (asteroids[i] != null && bullets[j].Collision(asteroids[i]))
                    {
                        System.Media.SystemSounds.Hand.Play();
                        asteroids[i] = null;
                        bullets.RemoveAt(j);
                        j-- ;
                        Count++;
                        strTarget("Asteroid is hit");
                        if (asteroids.Count == 0)
                        {
                            c++;
                            Random rnd = new Random();
                            int s = 0;
                            for (int k = 0; k < c; k++)
                            { s = rnd.Next(10, 30); asteroids.Add(new Asteroid(new Point(rnd.Next(20, 1900), rnd.Next(20, 1000)), new Point(rnd.Next(3, 10), rnd.Next(3, 10)), new Size(s, s))); }
                        }
                    }
                if (asteroids[i] == null || !ship.Collision(asteroids[i])) continue;
                ship.EnergyLow(Rnd.Next(1, 10));
                strTarget("Ship is hit");
                System.Media.SystemSounds.Asterisk.Play();
                if (ship.Energy <= 0) ship.Die();
            }
        }
        public static void Finish()
        {
            timer.Stop();
            Buffer.Graphics.DrawString($"The End! Your count is: {Count}", new Font(FontFamily.GenericSansSerif, 60, FontStyle.Underline), Brushes.White, 200, 100);
            Buffer.Render();
        }
        private static void Form_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.ControlKey)
                bullets.Add(new Bullet(new Point(ship.Rect.X + 50, ship.Rect.Y +40), new Point(30, 0), new Size(4, 1)));

            if (e.KeyCode == Keys.Up) ship.Up();
            if (e.KeyCode == Keys.Down) ship.Down();
        }
        static void StringTarget(string arg)
        {
            Console.WriteLine(arg);
        }
    }
}
