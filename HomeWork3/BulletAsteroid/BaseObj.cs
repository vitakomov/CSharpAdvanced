using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BulletAsteroid
{
    abstract class BaseObj
    {
        protected Point Pos;
        protected Point Dir;
        protected Size Size;
        public BaseObj(Point pos, Point dir, Size size)
        {
            Pos = pos;
            Dir = dir;
            Size = size;
        }
        public abstract void Update();
        public abstract void Draw();
    }
}
