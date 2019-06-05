using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Media;
using System.Windows.Forms;
using System.Numerics;
using System.IO;

namespace Emedia
{
    public partial class Main : Form
    {
        public Main()
        {
            InitializeComponent();
        }

        Data wavheader = new Data();
        string filepath = "1ToEncrypt.wav";
        string encryptedFile = "2Encrypted.wav";
        string dencryptedFile = "3Dencrypted.wav";
        string prime = "prime.txt";
        


        private void Button1_Click(object sender, EventArgs e)
        {
            wavheader = new Reader(filepath).ReadWAVFile();
            Data cipheredFile = wavheader;

            ////// Xor
            Cipher cipher = new Cipher(cipheredFile.WavData);
            cipher.Xor();
            Writer wavWriter = new Writer(encryptedFile);
            wavWriter.WriteWAVFile(cipheredFile);
            //Console.WriteLine(cipheredFile.Metadata());
            Data cipheredFile1 = new Reader(encryptedFile).ReadWAVFile();
            Cipher cipher1 = new Cipher(cipheredFile1.WavData);
            cipher1.Xor();
            Writer wavWriter1 = new Writer(dencryptedFile);
            wavWriter1.WriteWAVFile(cipheredFile1);
            Console.WriteLine("Finish Xor");
        }

        private void Button2_Click(object sender, EventArgs e)
        {
            wavheader = new Reader(filepath).ReadWAVFile();
            Data cipheredFile = wavheader;

            RSA rsa = new RSA(cipheredFile.WavData);
            cipheredFile.RSAChange(rsa.Encrypt());
            Writer wavWriter = new Writer(encryptedFile);
            wavWriter.WriteWAVFile(cipheredFile);

            Data cipheredFile1 = new Reader(encryptedFile).ReadWAVFile();
            RSA rsa1 = new RSA(cipheredFile1.WavData);
            cipheredFile1.RSAReChange(rsa.Decrypt());
            Writer wavWriter1 = new Writer(dencryptedFile);
            wavWriter1.WriteWAVFile(cipheredFile1);
            Console.WriteLine("Finish Small RSA");
        }

        private void Button4_Click(object sender, EventArgs e)
        {
            Prime primeNumbers = new Prime();
            BigInteger x = BigInteger.Pow(2, 1024);
            BigInteger y = 2000;
            primeNumbers.primeNumerGenerator(x, y);
            Console.WriteLine("Finish Prime");
        }



        private void Button3_Click(object sender, EventArgs e)
        {
            //// Big RSA
            wavheader = new Reader(filepath).ReadWAVFile();
            Data cipheredFile = wavheader;
            StreamReader sr = new StreamReader(prime);
            BigInteger x = BigInteger.Parse(sr.ReadLine());
            BigInteger y = BigInteger.Parse(sr.ReadLine());
            BigCipher bigCipher = new BigCipher(cipheredFile.WavData, x, y);
            Writer wavWriter = new Writer(encryptedFile);
            cipheredFile.WavData = bigCipher.Encryp();
            wavWriter.WriteWAVFile(cipheredFile);

            Data cipheredFile1 = new Reader(encryptedFile).ReadWAVFile();
            BigCipher bigCipher1 = new BigCipher(cipheredFile1.WavData, x, y);
            cipheredFile1.WavData = bigCipher1.Encryp();
            Writer wavWriter1 = new Writer(dencryptedFile);
            wavWriter1.WriteWAVFile(cipheredFile1);
            sr.Close();
            Console.WriteLine("Finish BigRSA");
        }

        
    }
}
