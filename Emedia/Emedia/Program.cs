using System;
using System.IO;

namespace Emedia
{
    class Program
    {
        static void Main(string[] args)
        {
            string workingDirectory = Environment.CurrentDirectory;
            string projectDirectory = Directory.GetParent(workingDirectory).Parent.Parent.FullName;
            string filePath = Path.Combine(projectDirectory, "11k16bitpcm.wav");
            if (File.Exists(filePath))
            {
                var parser = new WavParser(filePath);
                byte[] wavData = parser.GetWavData();
                Console.WriteLine(BitConverter.ToString(wavData));
            }
            else
            {
                Console.WriteLine("File not found.");
            }
            Console.ReadLine();
        }
    }
}
