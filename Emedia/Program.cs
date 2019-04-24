using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Emedia
{
    class Program
    {
        static void Main(string[] args)
        {
            Header wavheader = new Header();
            string filepath = "C:\\Users\\48888\\Desktop\\11k16bitpcm.wav";

            

            wavheader = new Reader(filepath).ReadWAVFile();

            Header cipheredFile = wavheader;
            Console.WriteLine(wavheader.WavData.OriginalData.Length);
            //304534
            Cipher cipher = new Cipher(cipheredFile.WavData.OriginalData);
            float[] encoded = cipher.getCipheredData();
            cipheredFile.WavData.OriginalData = cipheredFile.WavData.Normalize(encoded);
            Writer wavWriter = new Writer("C:\\Users\\48888\\Desktop\\11k16bitpcm1.wav");
            wavWriter.WriteWAVFile(cipheredFile);
            
            Console.WriteLine(wavheader.Metadata());

            Header cipheredFile1 = new Reader("C:\\Users\\48888\\Desktop\\11k16bitpcm1.wav", true).ReadWAVFile();
            Cipher cipher1 = new Cipher(cipheredFile1.WavData.OriginalData);
            float[] decipheredFloats = cipheredFile1.WavData.Denormalize();
            cipheredFile1.WavData.OriginalData = cipher1.getDecipheredData(decipheredFloats);
            Writer wavWriter1 = new Writer("C:\\Users\\48888\\Desktop\\11k16bitpcm2.wav");
            wavWriter1.WriteWAVFile(cipheredFile1);
            Console.WriteLine("Finish");
            Console.Read();

        }
    }
}
