using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;



namespace Mygame
{
    class Bullet : BaseObject
    {
        Image bullet;
        public int Power { get; set; } = 1;

        
       
        public Bullet(Point pos, Point dir, Size size) : base(pos, dir, size)
        {
            bullet = Image.FromFile("bullet.png");
            Power = 1;
        }
        public override void Draw()
        {
            Game.Buffer.Graphics.DrawImage(bullet, Pos.X, Pos.Y, Size.Width+10, Size.Height+10);
        }
        public override void Update()
        {
            Pos.X = Pos.X + 40;
           

        }
    }
}
