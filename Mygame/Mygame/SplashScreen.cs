using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing;

namespace Mygame
{
    class SplashScreen
    {
       public static  void CreateMyForm(Form a)
        {
             Form game = new Form();

            Button start = new Button();
            start.Location = new Point(10, 10);
            start.Text = "start";
            Button records = new Button();
            records.Location = new Point(start.Left, start.Height + start.Top + 10);
            records.Text = "records";
            Button exit = new Button();
            exit.Location = new Point(records.Left, records.Height + records.Top + 10);
            exit.Text = "exit";

            //game.FormBorderStyle = FormBorderStyle.FixedDialog;
            //game.MaximizeBox = false;
            //game.MinimizeBox = false;
            //game.AcceptButton = start;
            //game.CancelButton = records;
            //game.CancelButton = exit;
            //game.StartPosition = FormStartPosition.CenterScreen;

            

            game.Controls.Add(start);
            game.Controls.Add(records);
            game.Controls.Add(exit);

            start.Click += Game_Click;
            records.Click += Game_Click;
            exit.Click += Game_Click;

            game.ShowDialog();


        }

        private static void Game_Click(object sender, EventArgs e)
        {

            string text = (sender as Button).Text.ToString();

            if (text == "start") {
                Form form = new Form();
                form.Width = 800;
                form.Height = 600;
                Game.Init(form);
                form.Show();
                Game.Draw();
              

            };
            if (text == "records") MessageBox.Show("ns yjkm");
            if (text == "exit")  Application.Exit();
           


        }
    }
}
