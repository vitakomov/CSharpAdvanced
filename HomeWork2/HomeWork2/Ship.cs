using System;
using System.Drawing;

namespace HomeWork1
{
    class Ship : BaseObject
    {
        Bitmap Plane = new Bitmap("Plane.jpg");
        public Ship(Point pos, Point dir, Size size) : base(pos, dir, size)
        {
        }
        public override void Draw()
        {
            Plane.MakeTransparent(Color.FromArgb(0, 0, 0));
            Game.Buffer.Graphics.DrawImage(Plane, Pos.X, Pos.Y);
        }        
    }
}