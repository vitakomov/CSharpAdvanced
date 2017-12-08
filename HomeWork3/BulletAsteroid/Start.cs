using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BulletAsteroid
{
    static class Start
    {
        private static BufferedGraphicsContext _context;
        public static BufferedGraphics Buffer;
        public static int Width { get; set; }
        public static int Height { get; set; }

        static Start()
        {
        }
        public static BaseObj asteroid;
        public static BaseObj bullet;
        public static void Load()
        {
            Random rnd = new Random();
            int s = rnd.Next(20, 800);
            bullet = new Bullet(new Point(0, s), new Point(0, 20), new Size(3,0));
            asteroid = new Asteroid(new Point(Start.Width, s), new Point(0, -20), new Size(10, 10));
        }
        public static void Init(Form form)
        {
            Graphics g;
            _context = BufferedGraphicsManager.Current;
            g = form.CreateGraphics();
            Width = form.Width;
            Height = form.Height;
            //if (Width < 1000 && Height < 1000 && Width > 0 && Height > 0)
                Buffer = _context.Allocate(g, new Rectangle(0, 0, Width, Height));
            //
        }
        public static void Draw()
        {
            Buffer.Graphics.Clear(Color.Black);
            if(asteroid!=null)
                asteroid.Draw();
            if (bullet != null)
                bullet.Draw();
            Buffer.Render();
        }
        public static void Update()
        {
            asteroid.Update();
            bullet.Update();
        }
    }
}
