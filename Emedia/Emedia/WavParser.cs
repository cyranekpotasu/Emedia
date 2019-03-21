using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace Emedia
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
    }
}
