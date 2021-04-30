using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Othello
{
    public partial class Form3 : Form
    {
        bool isClicked = false;
        public Form3()
        {
            InitializeComponent();
        }

        private void startGame_Button_Click(object sender, EventArgs e)
        {
            Form1 myForm = new Form1();
            this.Hide();
            myForm.ShowDialog();
            this.Close();
        }

        private void quitGame_Button_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        // Opens up a new form with a list of all the rules.
        private void rules_Button_Click(object sender, EventArgs e)
        {
            Form4 myForm = new Form4();
            this.Hide();
            myForm.ShowDialog();
            this.Close();
        }

        // Everything from here to the bottom of the code is all just for fun.
        // It was very fun to create.
        private void button1_Click(object sender, EventArgs e)
        {
            menuChangeButtonClick();
        }
        private void button2_Click(object sender, EventArgs e)
        {
            menuChangeButtonClick();
        }
        private void button3_Click(object sender, EventArgs e)
        {
            menuChangeButtonClick();
        }
        private void button4_Click(object sender, EventArgs e)
        {
            menuChangeButtonClick();
        }
        private void button5_Click(object sender, EventArgs e)
        {
            menuChangeButtonClick();
        }
        private void button6_Click(object sender, EventArgs e)
        {
            menuChangeButtonClick();
        }
        private void button7_Click(object sender, EventArgs e)
        {
            menuChangeButtonClick();
        }
        private void button8_Click(object sender, EventArgs e)
        {
            menuChangeButtonClick();
        }

        private void menuChangeButtonClick()
        {
            Button newButton = null;
            Random randInt = new Random();
            int buttonInt = randInt.Next(0, 11);
            if(buttonInt == 0)
            {
                newButton = button1;
            }
            else if (buttonInt == 1)
            {
                newButton = button2;
            }
            else if (buttonInt == 2)
            {
                newButton = button3;
            }
            else if (buttonInt == 3)
            {
                newButton = button4;
            }
            else if (buttonInt == 4)
            {
                newButton = button5;
            }
            else if (buttonInt == 5)
            {
                newButton = button6;
            }
            else if (buttonInt == 6)
            {
                newButton = button7;
            }
            else if (buttonInt == 7)
            {
                newButton = button8;
            }
            else if (buttonInt == 8)
            {
                newButton = startGame_Button;
            }
            else if (buttonInt == 9)
            {
                newButton = rules_Button;
            }
            else if (buttonInt == 10)
            {
                newButton = quitGame_Button;
            }

            if(newButton.BackColor == Color.White)
            {
                newButton.BackColor = Color.Black;
                newButton.ForeColor = Color.White;
            }
            else if(newButton.BackColor == Color.Black)
            {
                newButton.BackColor = Color.LightGray;
                newButton.ForeColor = Color.Black;
            }
            else if (newButton.BackColor == Color.LightGray)
            {
                newButton.BackColor = Color.White;
                newButton.ForeColor = Color.Black;
            }
        }

        private void othello_Label_Click(object sender, EventArgs e)
        {
            if(!isClicked)
            {
                MessageBox.Show("You found me!");
                isClicked = true;
            }
            if (this.BackColor == Color.White)
            {
                this.BackColor = Color.Black;
                othello_Label.ForeColor = Color.White;
            }
            else
            {
                this.BackColor = Color.White;
                othello_Label.ForeColor = Color.Black;
            }
        }
    }
}