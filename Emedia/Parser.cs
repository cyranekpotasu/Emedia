using System;
using System.IO;
using System.Text;

namespace Emedia
{
    class Parser
    {
        private string filepath; 

        public Parser(string filepath)
        {
            this.filepath = filepath;
        }

        public byte[] ReadData(BinaryReader binaryReader)
        {
            int WavHeaderOffset = 44;

            binaryReader.BaseStream.Seek(WavHeaderOffset, SeekOrigin.Begin);
            return binaryReader.ReadBytes((int)binaryReader.BaseStream.Length - WavHeaderOffset);
            
        }

        public Data WavReader()
        {
            Data data = new Data();
            using (FileStream tmp = File.Open(this.filepath, FileMode.Open))
            {
                BinaryReader binaryReader = new BinaryReader(tmp);

                data.ChunkId = System.Text.Encoding.ASCII.GetString(binaryReader.ReadBytes(4));
                data.ChunkSize = binaryReader.ReadUInt32();
                data.Format = System.Text.Encoding.ASCII.GetString(binaryReader.ReadBytes(4));
                data.Subchunk1Id = System.Text.Encoding.ASCII.GetString(binaryReader.ReadBytes(4));
                data.Subchunk1Size = binaryReader.ReadInt32();
                data.AudioFormat = binaryReader.ReadInt16();
                data.NumChannels = binaryReader.ReadInt16();
                data.SampleRate = binaryReader.ReadInt32();
                data.ByteRate = binaryReader.ReadInt32() * 8;
                data.BlockAlign = binaryReader.ReadInt16();
                data.BitPerSample = binaryReader.ReadInt16();
                data.Subchunk2Id = System.Text.Encoding.ASCII.GetString(binaryReader.ReadBytes(4));
                data.Subchunk2Size = binaryReader.ReadInt32();
                data.SoundData = this.ReadData(binaryReader);
            }
            return data;
        }

        private Int32 FormatValue(string value)
        {
            byte[] bytes = Encoding.GetEncoding(65001).GetBytes(value);
            return BitConverter.ToInt32(bytes, 0);
        }

        public void WriteToFile(Data header)
        {
            using (FileStream fs = File.Open(this.filepath, FileMode.OpenOrCreate))
            {
                BinaryWriter binaryWriter = new BinaryWriter(fs);
                binaryWriter.Write(this.FormatValue(header.ChunkId));
                binaryWriter.Write(header.ChunkSize);
                binaryWriter.Write(this.FormatValue(header.Format));
                binaryWriter.Write(this.FormatValue(header.Subchunk1Id));
                binaryWriter.Write(header.Subchunk1Size);
                binaryWriter.Write((Int16)header.AudioFormat);
                binaryWriter.Write((Int16)header.NumChannels);
                binaryWriter.Write(header.SampleRate);
                binaryWriter.Write(header.ByteRate / 8);
                binaryWriter.Write((Int16)header.BlockAlign);
                binaryWriter.Write((Int16)header.BitPerSample);
                binaryWriter.Write(this.FormatValue(header.Subchunk2Id));
                binaryWriter.Write(header.Subchunk2Size);
                binaryWriter.Write(header.SoundData);
            }
        }

    }

    
}
