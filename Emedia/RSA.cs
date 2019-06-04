using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;


namespace Emedia
{
    class RSA
    {
        private readonly int p = 1123;
        private readonly int q = 1237;
        private readonly int phi;
        private readonly int e;
        private readonly int d;
        private readonly int n;
        public byte[] data { get; set; }


        public RSA(byte[] data)
        {
            phi = (p - 1) * (q - 1);
            e = GetE(phi);
            d = GetD(e, phi);
            this.data = data;
            this.n = GetN();
        }

        private int GetN()
        {
            return this.p * this.q;
        }

        private int GetE(int phi)
        {
            int e;
            for (e = 3; NWD(e, phi) != 1; e += 2) ;
            return e;
        }

        public static int NWD(int a, int b)
        {
            int t;

            while (b != 0)
            {
                t = b;
                b = a % b;
                a = t;
            };
            return a;
        }

        private static int GetD(int e, int phi)
        {
            int b = phi;
            int d = 0;
            int u = 1;
            while (e != 0)
            {
                if (e < phi)
                {
                    int tmp = u;
                    u = d;
                    d = tmp;
                    tmp = e;
                    e = phi;
                    phi = tmp;
                }
                int q = e / phi;
                u = u - q * d;
                e = e - q * phi;
            }
            if (phi != 1) return -1;
            if (d < 0) d += b;
            return d;
        }

        private long Modulo(long exponent, long originalValue, long modulo)
        {
            long cipheredValue = 1;
            for (long i = exponent; i > 0; i /= 2)
            {
                if (i % 2 == 1)
                {
                    cipheredValue = (originalValue * cipheredValue) % modulo;
                }
                originalValue = (originalValue * originalValue) % modulo;
            }
            return cipheredValue;
        }

        public float[] GetEncrypt(byte[] toEncode)
        {
            float[] rsaData = new float[toEncode.Length];
            for (int i = 0; i < toEncode.Length; i++)
            {
                long value = toEncode[i] % this.n;
                rsaData[i] = this.Modulo(this.e, value, this.n);
            }
            return rsaData;
        }

        public byte[] GetDecrypt(float[] toDecode)
        {
            byte[] rsaData = new byte[toDecode.Length];
            for (int i = 0; i < toDecode.Length; i++)
            {
                long value = (long)toDecode[i] % this.n;
                rsaData[i] = (byte)this.Modulo(this.d, value, this.n);
            }
            return rsaData;
        }


        public byte[] ToByteFile(float[] floatData)
        {
            List<byte> bytes = new List<byte>();

            for (int i = 0; i < floatData.Length; ++i)
            {
                byte[] after = new byte[4];
                byte[] beforer = this.GetBytes(floatData[i].ToString());

                for (int j = 0; j < beforer.Length; ++j)
                {
                    after[j] = beforer[j];
                }

                foreach(byte b in after)
                {
                    bytes.Add(b);
                }
            }
            return bytes.ToArray();

        }

        public byte[] GetBytes(string str)
        {
            BigInteger number;
            return BigInteger.TryParse(str, out number) ? number.ToByteArray() : null;
        }

        public byte[] Encrypt()
        {
            float[] tmp;
            tmp = GetEncrypt(this.data);
            byte[] bytes = ToByteFile(tmp);
            data = bytes;
            return bytes;

        }

        public float[] ToFloat(byte[] tmp)
        {
            List<byte[]> cipheredBytes = new List<byte[]>();

            for (int i = 0; i + 3 < tmp.Length; i += 4)
            {
                byte[] bytes = new byte[]
                {
                    tmp[i + 0],
                    tmp[i + 1],
                    tmp[i + 2],
                    tmp[i + 3],
                };

                cipheredBytes.Add(bytes);
            }

            List<float> floats = new List<float>();

            foreach (byte[] chunk in cipheredBytes)
            {
                floats.Add(BitConverter.ToUInt32(chunk, 0));
            }

            return floats.ToArray();
        }

        public byte[] Decrypt()
        {
            float[] tmp;
            byte[] bytes;
            tmp = ToFloat(this.data);
            bytes = GetDecrypt(tmp);
            data = bytes;
            
            return bytes;

        }


    }
}
