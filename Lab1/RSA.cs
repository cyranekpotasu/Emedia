using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab1
{
    public class RSA
    {
        public byte[] header;
        public byte[] data;

        public int[] publicKey = new int[2];
        public int[] privateKey = new int[2];

        public void GetKeys(int Prime1, int Prime2)
        {
            int e; 
            int phi = (Prime1 - 1) * (Prime2 - 1);
            int n = Prime2 * Prime1;
            for (e = 7 ; Nwd(e, phi) != 1; e += 2);
            int d = Odwr_mod(e, phi);

            this.privateKey[0] = d;
            this.privateKey[1] = n;
            this.publicKey[0] = e;
            this.publicKey[1] = n;

        }

        public int Nwd(int a, int b)
        {
            int t;
            while (b != 0)
            {
                t = b;
                b = a % b;
                a = t;
            }
            return a;
        }

        int Odwr_mod(int a, int n)
        {
            int a0, n0, p0, p1, q, r, t;

            p0 = 0; p1 = 1; a0 = a; n0 = n;
            q = n0 / a0;
            r = n0 % a0;
            while (r > 0)
            {
                t = p0 - q * p1;
                if (t >= 0)
                    t = t % n;
                else
                    t = n - ((-t) % n);
                p0 = p1; p1 = t;
                n0 = a0; a0 = r;
                q = n0 / a0;
                r = n0 % a0;
            }
            return p1;
        }

    }
}
