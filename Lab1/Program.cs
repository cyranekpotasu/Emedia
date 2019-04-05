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

            string workingDirectory = Environment.CurrentDirectory;
            string projectDirectory = Directory.GetParent(workingDirectory).Parent.Parent.FullName;
            string filePath = Path.Combine(projectDirectory, @"C:\Users\48888\Desktop\E-media\Lab1\11k16bitpcm.wav");
            if (File.Exists(filePath))
            {
                var parser = new WavParser(filePath);
                byte[] wavData = parser.GetWavData();
                //Console.WriteLine(BitConverter.ToString(wavData));


                Console.WriteLine(wavData.Length);
                var header = parser.Metadata();
                parser.WriteData(header);
                

            }
            else
            {
                Console.WriteLine("File not found.");
            }
    Console.ReadLine();
        }


    }
}
