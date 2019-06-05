using System;
using System.Numerics;
using System.IO;
using System.Windows.Forms;

namespace Emedia
{
    class Program
    {
        [STAThread]
        static void Main(string[] args)
        {
            Application.EnableVisualStyles();
            Application.Run(new Main());


            //Main main = new Main();

            //Data wavheader = new Data();
            //string filepath = "1ToEncrypt.wav";
            //string encryptedFile = "2Encrypted.wav";
            //string dencryptedFile = "3Dencrypted.wav";
            //string prime = "prime.txt";

            //wavheader = new Reader(filepath).ReadWAVFile();
            //Data cipheredFile = wavheader;


            //// XOR
            //Cipher cipher = new Cipher(cipheredFile.WavData);
            //cipher.Xor();
            //Writer wavWriter = new Writer(encryptedFile);
            //wavWriter.WriteWAVFile(cipheredFile);
            //Console.WriteLine(cipheredFile.Metadata());
            //Data cipheredFile1 = new Reader(encryptedFile).ReadWAVFile();
            //Cipher cipher1 = new Cipher(cipheredFile1.WavData);
            //cipher1.Xor();
            //Writer wavWriter1 = new Writer(dencryptedFile);
            //wavWriter1.WriteWAVFile(cipheredFile1);



            //Small RSA
            //RSA rsa = new RSA(cipheredFile.WavData);
            //cipheredFile.RSAChange(rsa.Encrypt());
            //Writer wavWriter = new Writer(encryptedFile);
            //wavWriter.WriteWAVFile(cipheredFile);

            //Data cipheredFile1 = new Reader(encryptedFile).ReadWAVFile();
            //RSA rsa1 = new RSA(cipheredFile1.WavData);
            //cipheredFile1.RSAReChange(rsa.Decrypt());
            //Writer wavWriter1 = new Writer(dencryptedFile);
            //wavWriter1.WriteWAVFile(cipheredFile1);


            //// Big RSA
            //StreamReader sr = new StreamReader(prime);
            //BigInteger x = BigInteger.Parse(sr.ReadLine());
            //BigInteger y = BigInteger.Parse(sr.ReadLine());
            //BigCipher bigCipher = new BigCipher(cipheredFile.WavData, x, y);
            //Writer wavWriter = new Writer(encryptedFile);
            //cipheredFile.WavData = bigCipher.Encryp();
            //wavWriter.WriteWAVFile(cipheredFile);

            //Data cipheredFile1 = new Reader(encryptedFile).ReadWAVFile();
            //BigCipher bigCipher1 = new BigCipher(cipheredFile1.WavData, x, y);
            //cipheredFile1.WavData = bigCipher1.Encryp();
            //Writer wavWriter1 = new Writer(dencryptedFile);
            //wavWriter1.WriteWAVFile(cipheredFile1);
            //sr.Close();


            //Prime primeNumbers = new Prime();
            //Console.WriteLine("Choose number:");

            ////BigInteger x = BigInteger.Parse(Console.ReadLine());
            ////BigInteger y = Convert.ToInt64(Console.ReadLine());

            //BigInteger x = BigInteger.Pow(2,1024);
            //BigInteger y = 2000;
            //primeNumbers.primeNumerGenerator(x, y);




            Console.WriteLine("Finish");
            Console.ReadLine();

        }
    }
}
