using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Emedia
{
    class Cipher
    {
        public byte[] Data { get; set; }

        public Cipher(byte[] data)
        {
            this.Data = data;
        }

        public void xor()
        {
            RSA rsa = new RSA();

            for (int i = 0; i < Data.Length; i++)
            {
                int value = rsa.getEncryption(i);
                Data[i] = (byte)(value ^ Data[i]);
            }

        }

        public float[] getCipheredData()
        {
            RSA rsa = new RSA();
            return rsa.GetCipheredValue(Data);
        }

        public byte[] getDecipheredData(float[] cipheredData)
        {
            RSA rsa = new RSA();
            return rsa.getDecipheredValue(cipheredData);
        }
    }
}
