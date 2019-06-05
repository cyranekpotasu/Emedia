using System;
using System.IO;
using System.Numerics;
using System.Collections.Generic;

namespace Emedia
{
    class Cipher
    {

        private readonly long p = 373641053;
        private readonly long q = 373641071;
        private readonly long phi;
        private readonly long e;
        private readonly long d;
        private readonly long n;
        public byte[] data { get; set; }
       


        public Cipher(byte[] data)
        {
            this.phi = (p - 1) * (q - 1);
            this.e = GetE(phi);
            this.d = GetD(e, phi);
            n = this.GetN();
            this.data = data;
        }

        private long GetE(long phi)
        {
            int e;
            for (e = 3; NWD(e, phi) != 1; e += 2) ;
            return e;
        }

        public static long NWD(long a, long b)
        {
            long t;

            while (b != 0)
            {
                t = b;
                b = a % b;
                a = t;
            };
            return a;
        }

        private static long GetD(long e, long phi)
        {
            long b = phi;
            long d = 0;
            long u = 1;
            while (e != 0)
            {
                if (e < phi)
                {
                    long tmp = u;
                    u = d;
                    d = tmp;
                    tmp = e;
                    e = phi;
                    phi = tmp;
                }
                long q = e / phi;
                u = u - q * d;
                e = e - q * phi;
            }
            if (phi != 1) return -1;
            if (d < 0) d += b;
            return d;
        }

        private long GetN()
        {
            return this.p * this.q;
        }

        private long Modulo(long e, long d, long n)
        {
            long tmp = 1;
            for (long i = e; i > 0; i /= 2)
            {
                if (i % 2 == 1)
                {
                    tmp = (d * tmp) % n;
                }
                d = (d * d) % n;
            }
            return tmp;
        }



        public int GetEncryption(int x)
        {
            long value = (long)x % this.n;
            return (int)this.Modulo(this.e, value, this.n);

        }

        public void Xor()
        {
            for(int i = 0; i < data.Length; i++)
            {
                data[i] ^= (byte)GetEncryption(i);
            }
        }

        public void XorWithKey()
        {
            for (int i = 0; i < data.Length; i++)
            {                
                data[i] ^= (byte)i;
            }
        }

        

        
    }
}
