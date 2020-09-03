using System;

namespace ConsoleApp3
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello! This console application is a C # implementation of the Caesar cipher.");
            Console.WriteLine("Please select:\n1. Encrypt message.\n2. Decrypt message.");

            string result = "";
            int number = Convert.ToInt32(Console.ReadLine());
            int cnt = 0;
            while(cnt == 0)
            {
                if (number == 1 || number == 2)
                    break;
                else
                {
                    Console.WriteLine("Input error!");
                    number = Convert.ToInt32(Console.ReadLine());
                }     
            }

            Console.WriteLine("Please enter your message:");
            string message = Console.ReadLine().ToLower();
            char[] secretMessage = message.ToCharArray();

            if(number == 1)
                result = String.Join("", Encrypt(secretMessage));
            else
                result = String.Join("", Decrypt(secretMessage));

            Console.WriteLine($"Result:\n{result}");

        }

        static char[] Alphabet = new char[] { 'a', 'b', 'c', 'd', 'e', 'f', 'g', 'h', 'i',
            'j', 'k', 'l', 'm', 'n', 'o', 'p', 'q', 'r', 's', 't', 'u', 'v', 'w', 'x', 'y', 'z', ' ' };

        static char[] Encrypt(char[] secretMessage, int key = 3)
        {
            char[] encryptedMessage = new char[secretMessage.Length];

            for (int i = 0; i < secretMessage.Length; i++)
            {
                char symbol = secretMessage[i];
                int indexAlphabet = Array.IndexOf(Alphabet, symbol);
                indexAlphabet = (indexAlphabet + key) % Alphabet.Length;
                symbol = Alphabet[indexAlphabet];
                encryptedMessage[i] = symbol;
            }
            return encryptedMessage;
        }

        static char[] Decrypt(char[] secretMessage, int key = 3)
        {
            char[] decryptedMessage = new char[secretMessage.Length];

            for (int i = 0; i < secretMessage.Length; i++)
            {
                char symbol = secretMessage[i];
                int indexAlphabet = Array.IndexOf(Alphabet, symbol);
                indexAlphabet -= key;

                if (indexAlphabet < 0)
                    indexAlphabet += Alphabet.Length;

                symbol = Alphabet[indexAlphabet];
                decryptedMessage[i] = symbol;
            }
            return decryptedMessage;

        }
    }
}