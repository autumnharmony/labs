using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace SelfLearning
{
    static class Program
    {
        /// <summary>
        /// Главная точка входа для приложения.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            //m
            Application.Run(new MainForm());
            //th
        }

        static string s = "";

        //MainForm mf;

        public static void Message(string s1){
            s = s1;
        }
    }
}
