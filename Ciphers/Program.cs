using System;
using Ciphers.Cipher;

class Program
{
    static void Main()
    {
        bool exit = false;

        while (!exit)
        {
            Console.Clear();
            Console.WriteLine("=== Cipher Menu ===");
            Console.WriteLine("1. Caesar Cipher");
            Console.WriteLine("2. Vigenère Cipher");
            Console.WriteLine("3. Exit");

            var choice = Console.ReadLine();
            Cipher cipher = null;

            switch (choice)
            {
                case "1":
                    cipher = new CaesarCipher();
                    break;

                case "2":
                    cipher = new VigenereCipher();
                    break;

                case "3":
                    exit = true;
                    break;

                default:
                    Console.WriteLine("Invalid option. Please choose 1, 2, or 3.");
                    continue;
            }

            if (cipher != null)
            {
                HandleCipherMenu(cipher);
            }
        }

        Console.WriteLine("Thank you for using the Cipher program. Goodbye!");
    }

    static void HandleCipherMenu(Cipher cipher)
    {
        bool exit = false;

        while (!exit)
        {
            Console.Clear();
            Console.WriteLine($"=== Cipher Menu ===");
            Console.WriteLine("1. Encode Text");
            Console.WriteLine("2. Decode Text");
            Console.WriteLine("3. Return to Main Menu");

            var choice = Console.ReadLine();

            switch (choice)
            {
                case "1":
                    cipher.Encode();
                    break;

                case "2":
                    cipher.Decode();
                    break;

                case "3":
                    exit = true;
                    break;

                default:
                    Console.WriteLine("Invalid option. Please choose 1, 2, or 3.");
                    break;
            }

            if (!exit)
            {
                Console.WriteLine("\nPress any key to return to the menu...");
                Console.ReadKey();
            }
        }
    }
}
