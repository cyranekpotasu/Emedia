using System;
using System.Numerics;
using System.IO;
using System.Windows.Forms;

namespace Emedia
{
    class Program
    {
        [STAThread]
        static void Main(string[] args)
        {
            Application.EnableVisualStyles();
            Application.Run(new Main());

            Console.WriteLine("Finish");
            Console.ReadLine();

        }
    }
}
