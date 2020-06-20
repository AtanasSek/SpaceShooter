using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace VizuelnoProgramiranjeGame
{
    public partial class MainMenu : Form
    {
        public MainMenu()
        {
            this.WindowState = FormWindowState.Maximized;
            this.FormBorderStyle = FormBorderStyle.None;
            InitializeComponent();
            this.DoubleBuffered = true;
            panel1.Location = new Point(Screen.PrimaryScreen.WorkingArea.Width/2 - panel1.Width/2,Screen.PrimaryScreen.WorkingArea.Height/2 - panel1.Height/2);
            panel1.BackColor = Color.FromArgb(100,0,0,0);
        }

        private void button5_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Hide();
            Form1 f1 = new Form1(300);
            f1.ShowDialog();
            this.Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Hide();
            Form1 f1 = new Form1(Int32.MaxValue);
            f1.ShowDialog();
            this.Show();
        }

        private void MainMenu_Paint(object sender, PaintEventArgs e)
        {
            
        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.Hide();
            Form instructions = new Instructions();
            instructions.ShowDialog();
        }

        private void button4_Click(object sender, EventArgs e)
        {

        }
    }
}
