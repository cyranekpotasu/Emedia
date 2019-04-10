using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Controls;
using System.Drawing;




namespace Lab1
{
    class Program
    {
        static void Main(string[] args)
        {
            RSA e = new RSA();
            string workingDirectory = Environment.CurrentDirectory;
            string projectDirectory = Directory.GetParent(workingDirectory).Parent.Parent.FullName;
            string filePath = Path.Combine(projectDirectory, @"C:\Users\48888\Desktop\E-media\Lab1\11k16bitpcm.wav");
            if (File.Exists(filePath))
            {
                var parser = new WavParser(filePath);
                e.data = parser.GetWavData();
                e.header = parser.Metadata();
                //parser.WriteData(e.header);
            }
            else
            {
                Console.WriteLine("File not found.");
            }
            e.GetKeys(13, 11);
            




            Console.ReadLine();

        }


    }
}
