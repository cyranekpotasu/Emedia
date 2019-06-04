using System;
using System.IO;

namespace Emedia
{
    class Program
    {
        static void Main(string[] args)
        {
            Data wavheader = new Data();
            string filepath = "1ToEncrypt.wav";
            string encryptedFile = "2Encrypted.wav";
            string dencryptedFile = "3Dencrypted.wav";


            wavheader = new Reader(filepath).ReadWAVFile();
            Data cipheredFile = wavheader;

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




            RSA rsa = new RSA(cipheredFile.WavData);
            cipheredFile.RSAChange(rsa.Encrypt());
            Writer wavWriter = new Writer(encryptedFile);
            wavWriter.WriteWAVFile(cipheredFile);

            Data cipheredFile1 = new Reader(encryptedFile).ReadWAVFile();
            RSA rsa1 = new RSA(cipheredFile1.WavData);
            cipheredFile1.RSAReChange(rsa.Decrypt());           
            Writer wavWriter1 = new Writer(dencryptedFile);
            wavWriter1.WriteWAVFile(cipheredFile1);




            //Console.WriteLine("Choose number:");
            //long x = Convert.ToInt32(Console.ReadLine());
            //long y = Convert.ToInt32(Console.ReadLine());
            //cipher.primeNumerGenerator(x, y);
            //cipher.PrintPrime();



            Console.WriteLine("Finish");
            Console.ReadLine();

        }
    }
}
