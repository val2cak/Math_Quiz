using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace Math_Quiz1
{
    public partial class medium : Form
    {
        public medium()
        {
            this.BackgroundImage = Properties.Resources.im;
            InitializeComponent();
        }
        Random randomizer = new Random();
        
        int addend1;
        int addend2;

        int minuend;
        int subtrahend;

        int multiplicand;
        int multiplier;

        int dividend;
        int divisor;

        int timeLeft;
        List<int> score_list = new List<int>();
        public void StartTheQuiz()
        {
            addend1 = randomizer.Next(11, 101);
            addend2 = randomizer.Next(11, 101);

            plusLeftLabel.Text = addend1.ToString();
            plusRightLabel.Text = addend2.ToString();

            sum.Value = 0;

            minuend = randomizer.Next(11, 101);
            subtrahend = randomizer.Next(1, minuend);
            minusLeftLabel.Text = minuend.ToString();
            minusRightLabel.Text = subtrahend.ToString();
            difference.Value = 0;

            multiplicand = randomizer.Next(11, 101);
            multiplier = randomizer.Next(11, 101);
            timesLeftLabel.Text = multiplicand.ToString();
            timesRightLabel.Text = multiplier.ToString();
            product.Value = 0;

            divisor = randomizer.Next(11, 101);
            int temporaryQuotient = randomizer.Next(1, 11);
            dividend = divisor * temporaryQuotient;
            dividedLeftLabel.Text = dividend.ToString();
            dividedRightLabel.Text = divisor.ToString();
            quotient.Value = 0;

            timeLeft = 30;
            timeLabel.Text = "30 seconds";
            timer1.Start();


        }

        private void startButton_Click(object sender, EventArgs e)
        {
            StartTheQuiz();
            startButton.Enabled = false;
        }

        public void timer1_Tick(object sender, EventArgs e)
        {
            
            if (CheckTheAnswer())
            {
                int score;
                timer1.Stop();
                MessageBox.Show("You got all the answers right!", "Congratulations!");
                startButton.Enabled = true;
                score = 30 - timeLeft;
                score_list.Add(score);
                lbl_score.Text = string.Join(System.Environment.NewLine, score_list);
                double highscore = score_list.Min();
                lbl_highscore.Text = highscore.ToString() + " seconds";
            }
            else if(timeLeft > 0)
            {
                timeLeft = timeLeft - 1;
                timeLabel.Text = timeLeft + " seconds";
            }
            else
            {
                timer1.Stop();
                timeLabel.Text = "Time's up!";
                MessageBox.Show("You didn't finish in time.", "Sorry!");
                sum.Value = addend1 + addend2;
                difference.Value = minuend - subtrahend;
                product.Value = multiplicand * multiplier;
                quotient.Value = dividend / divisor;
                startButton.Enabled = true;
            }
            if(timeLeft <= 5)
                timeLabel.BackColor = Color.Red;

        }

        private bool CheckTheAnswer()
        {
            if ((addend1 + addend2 == sum.Value)
                && (minuend - subtrahend == difference.Value)
                && (multiplicand * multiplier == product.Value)
                && (dividend / divisor == quotient.Value))
                return true;
            else
                return false;
        }

        private void answer_Enter(object sender, EventArgs e)
        {
            NumericUpDown answerBox = sender as NumericUpDown;

            if(answerBox != null)
            {
                int lenghtOfAnswer = answerBox.Value.ToString().Length;
                answerBox.Select(0, lenghtOfAnswer);
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void Exit_Click(object sender, EventArgs e)
        {
            var result = MessageBox.Show("Are you sure you want to quit?", "Exit?", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Stop);
           
            if (result == DialogResult.Yes)
            {
                Application.Exit();

            }
        }

        private void timeLabel_Click(object sender, EventArgs e)
        {

        }

        private void lbl_highscore_Click(object sender, EventArgs e)
        {
            

        }

        private void lbl_score_Click(object sender, EventArgs e)
        {
           
        }

        private void button_return_Click(object sender, EventArgs e)
        {
            timer1.Stop();
            new cover().Show();
            this.Hide();
        }

        private void plusRightLabel_Click(object sender, EventArgs e)
        {

        }

        private void highscore_Click(object sender, EventArgs e)
        {

        }

        private void newGameToolStripMenuItem_Click(object sender, EventArgs e)
        {
            StartTheQuiz();
            startButton.Enabled = false;
        }

        private void scoreToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show(string.Join(System.Environment.NewLine, score_list), "Score");
        }

        private void returnToolStripMenuItem_Click(object sender, EventArgs e)
        {
            timer1.Stop();
            new cover().Show();
            this.Hide();
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var result = MessageBox.Show("Are you sure you want to quit?", "Exit?", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Stop);

            if (result == DialogResult.Yes)
            {
                Application.Exit();

            }
        }
    }

}
