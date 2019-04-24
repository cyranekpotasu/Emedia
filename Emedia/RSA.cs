using System;
using System.Linq;
using System.Collections.Generic;
using System.Numerics;


namespace Emedia
{
    class RSA
    {

        private readonly int p = 1123;
        private readonly int q = 1237;
        private long e = 834781;
        private long d = 1087477;
        private int n;

        public RSA()
        {
            this.n = this.getN();
        }

        private int getN()
        {
            return this.p * this.q;
        }


        public byte[] Encode(byte[] data)
        {
            float[] encoded = this.GetCipheredValue(data);
            return data = this.Normalize(encoded);
        }

        public byte[] Decode(byte[] data)
        {
            float[] decode = this.Denormalize(data);
            return data = this.getDecipheredValue(decode);
        }


        public byte[] GetBytes(string str)
        {
            BigInteger number;
            return BigInteger.TryParse(str, out number) ? number.ToByteArray() : null;
        }


        public float[] Denormalize(byte[] data)
        {
            List<byte[]> byteList = new List<byte[]>();
            for (int i = 0; i + 3 < data.Length; i += 4)
            {
                byte[] b = new byte[]
                {
                    data[i],
                    data[i+1],
                    data[i+2],
                    data[i+3]
                };
                byteList.Add(b);
            }

            List<float> toFloat = new List<float>();
            foreach (byte[] b in byteList)
            {
                toFloat.Add(BitConverter.ToUInt32(b, 0));
            }
            return toFloat.ToArray();
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

        private long CipherLoop(long exponent, long originalValue)
        {
            long cipheredValue = 1;
            for (long i = exponent; i > 0; i /= 2)
            {
                if (i % 2 == 1)
                {
                    cipheredValue = (originalValue * cipheredValue) % this.n;
                }
                originalValue = (originalValue * originalValue) % this.n;
            }
            return cipheredValue;
        }

        public float[] GetCipheredValue(byte[] normalSample)
        {
            float[] rsaData = new float[normalSample.Length];
            for (int i = 0; i < normalSample.Length; i++)
            {
                long value = normalSample[i] % this.n;
                rsaData[i] = this.CipherLoop(this.e, value);
            }
            return rsaData;
        }

        public byte[] getDecipheredValue(float[] cipheredSample)
        {
            byte[] rsaData = new byte[cipheredSample.Length];
            for (int i = 0; i < cipheredSample.Length; i++)
            {
                long value = (long)cipheredSample[i] % this.n;
                rsaData[i] = (byte)this.CipherLoop(this.d, value);
            }
            return rsaData;
        }
    }
}

