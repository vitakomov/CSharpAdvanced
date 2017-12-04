using System;
using System.Windows.Forms;
using System.Drawing;

namespace HomeWork1
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

        public static BaseObject[] objs;
        public static void Load()
        {
            Random rnd = new Random();
            int s = 0;
            objs = new BaseObject[31];
            for (int i = 0; i < objs.Length / 2; i++)
            { s = rnd.Next(10, 30);  objs[i] = new Planet(new Point(rnd.Next(20, 800), rnd.Next(20, 600)), new Point(rnd.Next(3, 10), rnd.Next(3, 10)), new Size(s, s)); }
            for (int i = objs.Length / 2; i < objs.Length; i++)
                objs[i] = new Star(new Point(rnd.Next(20, 800), rnd.Next(250, 600)), new Point(-i, 0), new Size(5, 5));
            objs[30] = new Ship(new Point(20, 200), new Point(0, 0), new Size(30, 15));
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
            //Buffer.Graphics.DrawRectangle(Pens.White, new Rectangle(100, 100, 200, 200));
            //Buffer.Graphics.FillEllipse(Brushes.Wheat, new Rectangle(100, 100, 200, 200));
            if (objs!=null)
            foreach (BaseObject obj in objs)
                obj.Draw();
            Buffer.Render();
        }
        public static void Update()
        {
            foreach (BaseObject obj in objs)
                obj.Update();
        }
        public static void Move(string key)
        {
            objs[30].Move(key);
        }
    }
}
