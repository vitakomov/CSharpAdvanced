using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BulletAsteroid
{
    class Bullet : BaseObj
    {
        public Bullet(Point pos, Point dir, Size size) : base(pos, dir, size)
        {
        }
        public override void Draw()
        {
            Start.Buffer.Graphics.DrawLine(Pens.White, Pos.X, Pos.Y, Pos.X - Size.Width, Pos.Y);
        }

        public override void Update()
        {
            Pos.X = Pos.X + Dir.X;
        }
    }
}
