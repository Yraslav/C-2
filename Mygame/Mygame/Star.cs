using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace Mygame
{

    class Star : BaseObject
    {
        static Random r = new Random();
        static int s = r.Next(40, 80);
        Image star;
        public Star(Point pos, Point dir, Size size) : base(pos, dir, size)
        {
            star = Image.FromFile("star2.png");
        }
    
        
    public override void Draw()
    {
            Game.Buffer.Graphics.DrawImage(star, Pos.X, Pos.Y, Pos.X +  Size.Width, Pos.Y +   Size.Height);
            Game.Buffer.Graphics.DrawImage(star, Pos.X + Size.Width, Pos.Y, Pos.X, Pos.Y + Size.Height);
            //Game.Buffer.Render();
            //Game.Buffer.Graphics.DrawLine(Pens.White, Pos.X, Pos.Y, Pos.X + Size.Width, Pos.Y + Size.Height);
            //Game.Buffer.Graphics.DrawLine(Pens.White, Pos.X + Size.Width, Pos.Y, Pos.X, Pos.Y + Size.Height);
        }


    public override void Update()
    {
            Pos.X = Pos.X - Dir.X;
            if (Pos.X < 0) Pos.X = Game.Width + Size.Width;



            //Pos.X = Pos.X - Dir.X;
            //Pos.Y = Pos.Y - Dir.Y;
            //if (Pos.X < 0) Pos.X = Game.Width + Size.Width ;
            //if (Pos.Y < 0) Pos.Y = Game.Width + Size.Width ;
        }



}
}
    
