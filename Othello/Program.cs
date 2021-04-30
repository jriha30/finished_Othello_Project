using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Othello
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new Form3());
        }
    }
    public class Variables
    {
        public static bool questionCorrect;
        //public static string[,] questionArr;
        public static string[] question_array;
        public static int choice;
        public static int questionArrLength;
        //public static var path = Environment.CurrentDirectory;
    }
    public class Question
    {
        string question;
        public Question(string question)
        {
            this.question = question;
        }
    }
}