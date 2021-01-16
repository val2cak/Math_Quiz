using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Math_Quiz1
{
    public partial class cover : Form
    {
        public cover()
        {
            this.BackgroundImage = Properties.Resources.im1;
            InitializeComponent();
        }
        
    private void button_easy_Click(object sender, EventArgs e)
        {
            new easy().Show();
            this.Hide();
        }

        private void button_exit_Click(object sender, EventArgs e)
        {
            var result = MessageBox.Show("Are you sure you want to quit?", "Exit?", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Stop);

            if (result == DialogResult.Yes)
            {
                Application.Exit();

            }
        }

        private void label2_Click(object sender, EventArgs e)
        {
      
        }

        private void button_medium_Click(object sender, EventArgs e)
        {
            new medium().Show();
            this.Hide();
        }

        private void button_hard_Click(object sender, EventArgs e)
        {
            new hard().Show();
            this.Hide();
        }

        private void Menu_Opening(object sender, CancelEventArgs e)
        {

        }

        private void Menu_Opening_1(object sender, CancelEventArgs e)
        {

        }

        private void menuStrip1_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {

        }

        private void newGameToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }
    }
}
