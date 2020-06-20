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
            panel1.Location = new Point(Screen.PrimaryScreen.WorkingArea.Width / 2 - panel1.Width / 2, Screen.PrimaryScreen.WorkingArea.Height / 2 - panel1.Height);
            panel1.BackColor = Color.FromArgb(100, 0, 0, 0);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Hide();
            Form mainMenu = new MainMenu();
            mainMenu.ShowDialog();
        }
    }
}
