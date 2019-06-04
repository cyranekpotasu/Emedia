﻿using System;
using System.IO;
using System.Text;

namespace Emedia
{
    class Writer
    {
        private readonly string filename;

        public Writer(string filename)
        {
            this.filename = filename;
        }


        private Int32 FormatValue(string value)
        {
            byte[] bytes = Encoding.GetEncoding(65001).GetBytes(value);
            return BitConverter.ToInt32(bytes, 0);
        }

        public void WriteWAVFile(Data header)
        {
            using (FileStream fs = File.Open(this.filename, FileMode.OpenOrCreate))
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
                binaryWriter.Write(header.WavData);
            }
        }
    }
}

