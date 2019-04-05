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

        public void WriteData(byte[] header)
        {
            byte[] tmp = new byte[4];
            for (int i = 0; i < 4; i++)
                tmp[i] = header[i];
            Console.WriteLine("ChunkID " + System.Text.Encoding.ASCII.GetString(tmp));

            for (int i = 0; i < 4; i++)
                tmp[i] = header[i + 4];            
            Console.WriteLine("ChunkSize " + BitConverter.ToUInt16(tmp, 0));

            for (int i = 0; i < 4; i++)
                tmp[i] = header[i+8];
            Console.WriteLine("Format " + System.Text.Encoding.ASCII.GetString(tmp));

            for (int i = 0; i < 4; i++)
                tmp[i] = header[i + 12];
            Console.WriteLine("Subchunk1ID " + System.Text.Encoding.ASCII.GetString(tmp));

            for (int i = 0; i < 4; i++)
                tmp[i] = header[i + 16];
            Console.WriteLine("Subchunk1Size " + BitConverter.ToUInt16(tmp, 0));

            for (int i = 0; i < 2; i++)
                tmp[i] = header[i + 20];
            Console.WriteLine("AudioFormat " + BitConverter.ToUInt16(tmp, 0));

            for (int i = 0; i < 2; i++)
                tmp[i] = header[i + 22];
            Console.WriteLine("NumChannels " + BitConverter.ToUInt16(tmp, 0));

            for (int i = 0; i < 4; i++)
                tmp[i] = header[i + 24];
            Console.WriteLine("SampleRate " + BitConverter.ToUInt16(tmp, 0));

            for (int i = 0; i < 4; i++)
                tmp[i] = header[i + 28];
            Console.WriteLine("ByteRate " + BitConverter.ToUInt16(tmp, 0));

            for (int i = 0; i < 2; i++)
                tmp[i] = header[i + 32];
            Console.WriteLine("BlockAlign " + BitConverter.ToUInt16(tmp, 0));

            for (int i = 0; i < 2; i++)
                tmp[i] = header[i + 34];
            Console.WriteLine("BityPerSample " + BitConverter.ToUInt16(tmp, 0));

            for (int i = 0; i < 4; i++)
                tmp[i] = header[i + 36];
            Console.WriteLine("Subchunk2ID " + System.Text.Encoding.ASCII.GetString(tmp));

            for (int i = 0; i < 4; i++)
                tmp[i] = header[i + 40];
            Console.WriteLine("Subchunk2Size " + BitConverter.ToUInt16(tmp, 0));

        }

    }

}
