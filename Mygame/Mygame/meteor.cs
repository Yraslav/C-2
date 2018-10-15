using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace Mygame
{
    class meteor : BaseObject
    {
        static Random r = new Random();
        static int s = r.Next(40, 80);
        Image star;
        public meteor(Point pos, Point dir, Size size) : base(pos, dir, size)
        {
            star = Image.FromFile("meteor.png");
        }


        public override void Draw()
        {
            Game.Buffer.Graphics.DrawImage(star, Pos.X, Pos.Y,  Size.Width,  Size.Height);
       
            //Game.Buffer.Render();
            //Game.Buffer.Graphics.DrawLine(Pens.White, Pos.X, Pos.Y, Pos.X + Size.Width, Pos.Y + Size.Height);
            //Game.Buffer.Graphics.DrawLine(Pens.White, Pos.X + Size.Width, Pos.Y, Pos.X, Pos.Y + Size.Height);
        }


        public override void Update()
        {
            Pos.X = Pos.X + Dir.X;
            Pos.Y = Pos.Y + Dir.Y;
            if (Pos.X < 0) Dir.X = -Dir.X;
            if (Pos.X > Game.Width) Dir.X = -Dir.X;
            if (Pos.Y < 0) Dir.Y = -Dir.Y;
            if (Pos.Y > Game.Height) Dir.Y = -Dir.Y;
        }
    }
}
