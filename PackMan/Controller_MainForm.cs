using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Threading;

[assembly: CLSCompliant(true)] //устанавливает совместимость с другими языками, поддерживаемых .NET
namespace PackMan
{

    public delegate void Invoker();

    public partial class Controller_MainForm : Form
    {

        View gameField;
        Model model;
        Thread playTank;


        public Controller_MainForm(): this(260)  { }
        public Controller_MainForm(int size): this(size, 5) { }
        public Controller_MainForm(int size, int tanksAmount): this(size, tanksAmount, 3) { }
        public Controller_MainForm(int size, int tanksAmount, int applesAmount): this(size, tanksAmount, applesAmount, 40) { }
        public Controller_MainForm(int size, int tanksAmount, int applesAmount, int speed)
        {
            InitializeComponent();

            model = new Model(size, tanksAmount, applesAmount, speed);
            gameField = new View(model);
            this.Controls.Add(gameField);
            model.statuschange += StatusChangeHandler;

        }

        private void StatusChangeHandler()
        {
            Invoke(new Invoker(InvokerHandler));
        }

        private void InvokerHandler()
        {
            toolStripStatusLabel1.Text = model.state.ToString();
            StartPausePb.Enabled = !StartPausePb.Enabled;
        }


        private void btnStart_Click(object sender, EventArgs e)
        {
            if (model.state == State.stoped)
            {
                model.state = State.commenced;
                playTank = new Thread(model.Play);
                playTank.Start();
                gameField.Invalidate();
                StartPausePb.Image = Properties.Resources.PauseBtn;
                StartPausePb.Focus();
                toolStripStatusLabel1.Text = model.state.ToString();
            }
            else
            {
                model.state = State.stoped;
                toolStripStatusLabel1.Text = model.state.ToString();
                playTank.Abort();
                StartPausePb.Image = Properties.Resources.StartBtn;
            }
        }

        private void Controller_MainForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (playTank != null)
            {
                model.state = State.stoped;
                playTank.Abort();
            }

            DialogResult dr = MessageBox.Show("Are you sure?", "Tanks", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Asterisk, MessageBoxDefaultButton.Button2, MessageBoxOptions.DefaultDesktopOnly);

            if (dr == DialogResult.Yes)
                e.Cancel = false;
            else
                e.Cancel = true;
        }

        

        private void StartPausePb_PreviewKeyDown(object sender, PreviewKeyDownEventArgs e)
        {
            switch (e.KeyData.ToString())
            { 
                case "A":
                    model.Pl.nextX = -1;
                    model.Pl.nextY = 0;
                    break;
                case "D":
                    model.Pl.nextX = 1;
                    model.Pl.nextY = 0;
                    break;
                case "S":
                    model.Pl.nextX = 0;
                    model.Pl.nextY = 1;
                    break;
                case "W":
                    model.Pl.nextX = 0;
                    model.Pl.nextY = -1;
                    break;
                case "E":
                    if (model.WeaponC > 0)
                    {
                        if (model.Pl.MoveX == 1)
                            model.Pr.Add(new Projectile(model.Pl.X + 20, model.Pl.Y + 7, model.Pl.MoveX, model.Pl.MoveY));
                        if (model.Pl.MoveX == -1)
                            model.Pr.Add(new Projectile(model.Pl.X, model.Pl.Y + 7, model.Pl.MoveX, model.Pl.MoveY));
                        if (model.Pl.MoveY == 1)
                            model.Pr.Add(new Projectile(model.Pl.X + 7, model.Pl.Y + 20, model.Pl.MoveX, model.Pl.MoveY));
                        if (model.Pl.MoveY == -1)
                            model.Pr.Add(new Projectile(model.Pl.X + 7, model.Pl.Y, model.Pl.MoveX, model.Pl.MoveY));
                        model.WeaponCounterProperty.PutCurrentImg(--model.WeaponC);
                       
                        
                    }
                    break;
            }
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void newToolStripMenuItem_Click(object sender, EventArgs e)
        {
            model.NewGame();
            StartPausePb.Enabled = true;
            StartPausePb.Image = Properties.Resources.StartBtn;
            gameField.Refresh();
        }
    }
}
