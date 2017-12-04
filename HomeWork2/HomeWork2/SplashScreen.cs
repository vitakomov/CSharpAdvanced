using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace HomeWork1
{
    class SplashScreen
    {
        private static BufferedGraphicsContext _context;
        public static BufferedGraphics Buffer;
        public static int Width { get; set; }
        public static int Height { get; set; }
        static SplashScreen()
        {
        }

        public static BaseObject[] objs;
        public static void Load()
        {
            Random rnd = new Random();
            objs = new BaseObject[60];
            for (int i = 0; i < objs.Length / 2; i++)
                objs[i] = new Planet(new Point(rnd.Next(0,600), i * 10), new Point(-i - 1, -i - 1), new Size(10, 10));
            for (int i = objs.Length / 2; i < objs.Length; i++)
                objs[i] = new Star(new Point(600, rnd.Next(0,600)), new Point(-i, 0), new Size(5, 5));
        }

        public static void Init(Form form)
        {
            Graphics g;
            _context = BufferedGraphicsManager.Current;
            g = form.CreateGraphics();
            Width = form.Width;
            Height = form.Height;
            Buffer = _context.Allocate(g, new Rectangle(0, 0, Width, Height));
        }
        public static void Draw()
        {
            Buffer.Graphics.Clear(Color.Black);
            if (objs != null)
                foreach (BaseObject obj in objs)
                    obj.Draw();
            Buffer.Render();
        }
        public static void Update()
        {
            foreach (BaseObject obj in objs)
                obj.UpdateSplash();
        }
    }
}
