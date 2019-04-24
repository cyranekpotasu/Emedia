using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Emedia
{
    class Data
    {
        public string ChunkId { get; set; }
        public uint ChunkSize { get; set; }
        public string Format { get; set; }
        public string Subchunk1Id { get; set; }
        public int Subchunk1Size { get; set; }
        public int AudioFormat { get; set; }
        public int NumChannels { get; set; }
        public int SampleRate { get; set; }
        public int ByteRate { get; set; }
        public int BlockAlign { get; set; }
        public int BitPerSample { get; set; }
        public string Subchunk2Id { get; set; }
        public int Subchunk2Size { get; set; }

        public byte[] SoundData { get; set; }


        public string Metadata()
        {
            return "ChunkId  " + ChunkId + " \n"
                + "ChunkSize  " + ChunkSize.ToString() + " \n"
                + "Format  " + Format + " \n"
                + "Subchunk1Id  " + Subchunk1Id + " \n"
                + "Subchunk1Size  " + Subchunk1Size.ToString() + " \n"
                + "AudioFormat  " + AudioFormat.ToString() + " \n"
                + "NumChannels  " + NumChannels.ToString() + " \n"
                + "SampleRate  " + SampleRate.ToString() + " \n"
                + "ByteRate  " + ByteRate.ToString() + " \n"
                + "BlockAlign  " + BlockAlign.ToString() + " \n"
                + "BitPerSample  " + BitPerSample.ToString() + " \n"
                + "Subchunk2Id  " + Subchunk2Id + " \n"
                + "Subchunk2Size  " + Subchunk2Size + " \n";
        }
    }
}
