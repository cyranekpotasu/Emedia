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
            string filepath = "C:\\Users\\48888\\Desktop\\11k16bitpcm.wav";

            RSA cipher = new RSA();
            Parser parser = new Parser(filepath);
            Data data = parser.WavReader();
            Console.WriteLine(data.SoundData[2]);
            data.SoundData = cipher.Decode(data.SoundData);
            parser.WriteToFile(data);
            
            
            
        }
    }
}
