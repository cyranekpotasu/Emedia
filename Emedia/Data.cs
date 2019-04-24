using System;
using System.Linq;
using System.Collections.Generic;
using System.Numerics;

namespace Emedia
{
    class Data
    {

        public byte[] OriginalData { get; set; }
        public float[] ChannelData { get; set; }

        
        public Data(byte[] data, int size)
        {
            const int maxSize = 1024; //first 1024 samples
            OriginalData = data;
            data = data.Take(maxSize).ToArray();
            float[] frqData = new float[maxSize];
            Int16[] shortFormatCpy = new Int16[maxSize];
            Buffer.BlockCopy(data, 0, shortFormatCpy, 0, maxSize);
            for (int i = 0; i < shortFormatCpy.Length; i++)
            {
                frqData[i] = shortFormatCpy[i];
            }

            ChannelData = frqData;
        }

        
        public byte[] GetBytes(string str)
        {
            BigInteger number;
            return BigInteger.TryParse(str, out number) ? number.ToByteArray() : null;
        }

       
        public byte[] Normalize(float[] cipheredData)
        {
            List<byte[]> byteList = new List<byte[]>();
            for (int i = 0; i < cipheredData.Length; i++)
            {
                byte[] result = new byte[4];
                byte[] r = this.GetBytes(cipheredData[i].ToString());

                for (int j = 0; j < r.Length; j++)
                {
                    result[j] = r[j];
                }
                byteList.Add(result);
            }
            byte[] bytes = byteList.SelectMany(a => a).ToArray();
            return bytes;
        }

      
        public float[] Denormalize()
        {
            List<byte[]> listCipher = new List<byte[]>();
            for (int i = 0; i + 3 < OriginalData.Length; i += 4)
            {
                byte[] b = new byte[]
                {
                    OriginalData[i],
                    OriginalData[i+1],
                    OriginalData[i+2],
                    OriginalData[i+3]
                };
                listCipher.Add(b);
            }

            List<float> floats = new List<float>();
            foreach (byte[] b in listCipher)
            {
                floats.Add(BitConverter.ToUInt32(b, 0));
            }
            return floats.ToArray();
        }
    }
}
