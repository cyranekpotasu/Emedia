using System;
using System.Numerics;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Emedia
{
    class Prime
    {

        string prime = "prime.txt";
        List<BigInteger> primeList = new List<BigInteger>();
        public void primeNumerGenerator(BigInteger x, BigInteger y)
        {
            StreamWriter sw = new StreamWriter(prime);
            for (BigInteger i = x; i < x + y; i++)
            {

                if (test(i))
                {
                    primeList.Add(i);
                    Console.WriteLine("It's prime: " + i);
                    sw.WriteLine(i);

                }

            }
            sw.Close();
        }

        public bool test(BigInteger n)
        {
            if (n <= 1)
                return false;
            if (n == 2 || n == 3 || n == 5)
                return true;
            if (n % 2 == 0)
                return false;
            if (n % 3 == 0)
                return false;
            if (n % 5 == 0)
                return false;

            BigInteger negativeOne = n - 1;
            BigInteger s = 0;
            BigInteger d = n - 1;
            int k = 10;
            Random random = new Random();
            while (d % 2 == 0)
            {
                s++;
                d = d / 2;
            }

            for(int i = 0; i < k; i++)
            {
                BigInteger a = random.Next((int)BigInteger.Min(n - 1, int.MaxValue - 1)) + 1;
                BigInteger x = Modulo(a, d, n);
                if (1 != x)
                {
                    bool flag = true;
                    BigInteger r = d;
                    for (BigInteger j = 0; j < s; j++)
                    {
                        BigInteger y = Modulo(a, r, n);
                        flag = flag && (y != n - 1);
                        r *= 2;
                    }

                    if(flag)
                        return false;
                }


            }

            return true;
        }

        private BigInteger Modulo(BigInteger d, BigInteger e, BigInteger n)
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

        public void PrintPrime()
        {
            foreach (long a in primeList)
            {
                Console.WriteLine(a);
            }
        }

    }
}
