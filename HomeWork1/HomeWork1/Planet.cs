using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HomeWork1
{
    class Planet : BaseObject
    {
        Bitmap planet = new Bitmap("Planet.jpg");
        public Planet(Point pos, Point dir, Size size) : base(pos, dir, size)
        {
        }
        public override void Draw()
        {
            planet.MakeTransparent(Color.FromArgb(0, 0, 0));
            Game.Buffer.Graphics.DrawImage(planet, Pos.X, Pos.Y, Size.Width, Size.Height);
        }
    }
}