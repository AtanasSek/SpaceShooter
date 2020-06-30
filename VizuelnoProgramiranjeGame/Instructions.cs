using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace VizuelnoProgramiranjeGame
{
    public partial class Instructions : Form
    {
        public Instructions()
        {
            this.WindowState = FormWindowState.Maximized;
            this.FormBorderStyle = FormBorderStyle.None;
            InitializeComponent();
            this.DoubleBuffered = true;

            tableLayoutPanel1.BackColor = Color.FromArgb(100, 0, 0, 0);
            //tableLayoutPanel1.Width = Screen.PrimaryScreen.WorkingArea.Width / 2;
            //tableLayoutPanel1.Height = Screen.PrimaryScreen.WorkingArea.Height / 2;
            tableLayoutPanel1.Location = new Point(Screen.PrimaryScreen.WorkingArea.Width / 2 - tableLayoutPanel1.Width / 2, Screen.PrimaryScreen.WorkingArea.Height / 2 - tableLayoutPanel1.Height/2);

        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Hide();
            Form mainMenu = new MainMenu();
            mainMenu.ShowDialog();
        }

    }
}
