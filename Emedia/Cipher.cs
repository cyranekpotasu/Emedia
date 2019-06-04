using System;
using System.IO;
using System.Collections.Generic;

namespace Emedia
{
    class Cipher
    {

        private readonly long p = 32416190071;
        private readonly long q = 32416189381;
        private readonly long e = 834781;
        private readonly long d = 1087477;
        private readonly long n;
        List<long> primeList = new List<long>();
        public byte[] data { get; set; }
        private readonly String key1;
        private readonly String key2;


        public Cipher(byte[] data)
        {
            using (StreamReader sr = new StreamReader("key1.txt"))
            {

                key1 = sr.ReadToEnd();

            }
            using (StreamReader sr = new StreamReader("key2.txt"))
            {

                key2 = sr.ReadToEnd();

            }
            n = this.GetN();
            this.data = data;
        }

        public void PrintPrime()
        {
            foreach (long a in primeList)
            {
                Console.WriteLine(a);
            }
        }

        private long GetN()
        {
            return this.p * this.q;
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

        
        public void primeNumerGenerator(long x, long y)
        {   
            for(long i = x; i < x+y; i++)
            {

                
                if(test(i))
                {
                    primeList.Add(i);
                    
                }
                
            }
        }

        public bool test(long n)
        {
            if (n <= 1)
                return false;
            if (n == 2)
                return true;
            if (n % 2 == 0)
                return false;
            

            long negativeOne = n - 1;
            long s = 0;
            long m = n - 1;

            while (m % 2 == 0)
            {
                s++;
                m = m / 2;
            }

            Random r = new Random();
            long a = r.Next( (int)n - 1) + 1;
            long temp = m;
            long mod = 1;
            for (int j = 0; j < temp; ++j)
            {
                mod = (mod * a) % n;
            }
            while (temp != n - 1 && mod != 1 && mod != n - 1)
            {
                mod = (mod * mod) % n;
                temp *= 2;
            }

            if (mod != n - 1 && temp % 2 == 0) return false;
            return true;
        }
        
    }
}
