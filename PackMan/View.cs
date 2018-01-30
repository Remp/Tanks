using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Threading;

namespace PackMan
{
    partial class View : UserControl
    {
        Model model;

        public View(Model model)
        {
            InitializeComponent();

            this.model = model;
        }

        void Draw(PaintEventArgs e)
        {
            DrawWall(e);
            DrawWeapons(e);
            DrawTank(e);
            DrawPlayer(e);
            DrawProjectile(e);
            DrawGainedWeapons(e);
            if (model.state != State.commenced)
                return;
            Thread.Sleep(model.speed);
                
            Invalidate();          
        }

        private void DrawProjectile(PaintEventArgs e)
        {
            for (int i = 0; i < model.Pr.Count; i++)
            {
                e.Graphics.DrawImage(model.Pr[i].CurrentImage, new Point(model.Pr[i].X, model.Pr[i].Y)); 
            }
        }

        private void DrawWeapons(PaintEventArgs e)
        {
            for (int i = 0; i < model.Weapons.Count; i++)
                e.Graphics.DrawImage(model.Weapons[i].Img, new Point(model.Weapons[i].X, model.Weapons[i].Y));
        }

        
        private void DrawWall(PaintEventArgs e)
        {
            foreach (Wall w in model.Walls)
                e.Graphics.DrawImage(w.Img, new Point(w.X, w.Y));
        }

       
        private void DrawTank(PaintEventArgs e)
        {
            for (int i = 0; i < model.Tanks.Count; i++)
                e.Graphics.DrawImage(model.Tanks[i].CurrentImage, new Point(model.Tanks[i].X, model.Tanks[i].Y));
        }

        
        private void DrawGainedWeapons(PaintEventArgs e)
        {
            e.Graphics.DrawImage(model.WeaponCounterProperty.CurrentImg, model.WeaponCounterProperty.X, model.WeaponCounterProperty.Y);
        }
        
        private void DrawPlayer(PaintEventArgs e)
        {
            e.Graphics.DrawImage(model.Pl.CurrentImage, new Point(model.Pl.X, model.Pl.Y));
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            Draw(e);
        }

        
    }
}
