using System;
using System.Numerics;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Emedia
{
    class BigCipher
    {
        private readonly BigInteger p ;
        private readonly BigInteger q ;
        private readonly BigInteger phi;
        private readonly BigInteger e;
        private readonly BigInteger d;
        private readonly BigInteger n;
        private byte[]  key;
        private readonly string keyPath = "key.txt";

        public byte[] data { get; set; }

        public BigCipher(byte[] data, BigInteger x, BigInteger y)
        {
            p = x;
            q = y;
            this.phi = (p - 1) * (q - 1);
            this.e = GetE(phi);
            this.d = GetD(e, phi);
            n = this.GetN();
            this.data = data;
            key = System.IO.File.ReadAllBytes(keyPath);
        }

        private BigInteger GetE(BigInteger phi)
        {
            int e;
            for (e = 3; NWD(e, phi) != 1; e += 2) ;
            return e;
        }

        public static BigInteger NWD(BigInteger a, BigInteger b)
        {
            BigInteger t;

            while (b != 0)
            {
                t = b;
                b = a % b;
                a = t;
            };
            return a;
        }

        private static BigInteger GetD(BigInteger e, BigInteger phi)
        {
            BigInteger b = phi;
            BigInteger d = 0;
            BigInteger u = 1;
            while (e != 0)
            {
                if (e < phi)
                {
                    BigInteger tmp = u;
                    u = d;
                    d = tmp;
                    tmp = e;
                    e = phi;
                    phi = tmp;
                }
                BigInteger q = e / phi;
                u = u - q * d;
                e = e - q * phi;
            }
            if (phi != 1) return -1;
            if (d < 0) d += b;
            return d;
        }

        private BigInteger GetN()
        {
            return this.p * this.q;
        }

        public byte[] Encryp()
        {
            BigInteger[] key1 = new BigInteger[this.key.Length];
            BigInteger[] bigKey = new BigInteger[this.key.Length];
            for (int i = 0; i < this.key.Length; i++)
            {
                key1[i] = (this.key[i]);
            }

            for (int i = 0; i < key.Length; i++)
            {
                bigKey[i] = GetEncryption(key1[i]);
            }
            string keyString = "";
            for (int i = 0; i < bigKey.Length; i++)
            {
                keyString += (bigKey[i]).ToString();
            }

            int j = 0;
            for(int i = 0; i < this.data.Length; i++)
            {
                data[i] ^= (byte)keyString[j];
                j++;
                if(j == keyString.Length - 1)
                {
                    j = 0;
                }
            }
            return data;
        }

        private BigInteger Modulo(BigInteger e, BigInteger d, BigInteger n)
        {
            BigInteger tmp = 1;
            for (BigInteger i = e; i > 0; i /= 2)
            {
                if (i % 2 == 1)
                {
                    tmp = (d * tmp) % n;
                }
                d = (d * d) % n;
            }
            return tmp;
        }



        public BigInteger GetEncryption(BigInteger x)
        {
            BigInteger value = x % this.n;
            return this.Modulo(this.e, value, this.n);

        }

      
    }
}
