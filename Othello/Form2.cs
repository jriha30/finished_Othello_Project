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
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
        }

        private void Form2_Load(object sender, EventArgs e)
        {
            label1.Text = Variables.question_array[Variables.choice];
        }

        private void button_correct_Click(object sender, EventArgs e)
        {
            Variables.questionCorrect = true;
            this.Close();
        }

        private void button_incorrect_Click(object sender, EventArgs e)
        {
            Variables.questionCorrect = false;
            this.Close();
        }
    }
}
