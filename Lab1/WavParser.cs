using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;


namespace Lab1
{
    public class WavParser
    {
        private readonly string wavFilePath;
        public const int WavHeaderOffset = 44;

        public WavParser(string wavFilePath) => this.wavFilePath = wavFilePath;

        public byte[] GetWavData()
        {
            using (var reader = new BinaryReader(File.OpenRead(wavFilePath)))
            {
                reader.BaseStream.Seek(WavHeaderOffset, SeekOrigin.Begin);
                return reader.ReadBytes((int)reader.BaseStream.Length - WavHeaderOffset);
            }
        }

        public byte[] Metadata()
        {
            var reader = new BinaryReader(File.OpenRead(wavFilePath));
            byte[] header = reader.ReadBytes(WavHeaderOffset);
            return header;
        }

    }

}
