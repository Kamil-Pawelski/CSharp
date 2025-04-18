using Ciphers.Cipher;
using System.Text;
using System.Text.RegularExpressions;

internal class VigenereCipher : Cipher
{
    public override void Encode()
    {
        Console.WriteLine("Enter text to encode (Only letters):");
        var input = Console.ReadLine();

        if (string.IsNullOrWhiteSpace(input) || !Regex.IsMatch(input, @"^[a-zA-Z]+$"))
        {
            Console.WriteLine("Text must contain only letters (a-z, A-Z) with no spaces or symbols.");
            return;
        }

        PlainText = input.ToUpper();

        Console.WriteLine("Enter key (only letters):");
        var key = Console.ReadLine()?.ToUpper();

        if (string.IsNullOrWhiteSpace(key) || !Regex.IsMatch(key, @"^[a-zA-Z]+$"))
        {
            Console.WriteLine("Invalid key.");
            return;
        }

        CipherText = Encrypt(PlainText, key);
        Console.WriteLine($"Encoded text: {CipherText}");
    }

    public override void Decode()
    {
        Console.WriteLine("Enter text to decode (only letters):");
        var input = Console.ReadLine();

        if (string.IsNullOrWhiteSpace(input) || !Regex.IsMatch(input, @"^[a-zA-Z]+$"))
        {
            Console.WriteLine("Text must contain only letters (a-z, A-Z) with no spaces or symbols.");
            return;
        }

        CipherText = input.ToUpper();

        Console.WriteLine("Enter key (only letters):");
        var key = Console.ReadLine()?.ToUpper();

        if (string.IsNullOrWhiteSpace(key) || !Regex.IsMatch(key, @"^[a-zA-Z]+$"))
        {
            Console.WriteLine("Invalid key.");
            return;
        }

        PlainText = Encrypt(CipherText, key);
        Console.WriteLine($"Decoded text: {PlainText}");
    }

    private string Encrypt(string text, string key)
    {
        var result = new StringBuilder();
        int keyIndex = 0;

        foreach (var letter in text)
        {
            if (char.IsLetter(letter))
            {
                var shift = key[keyIndex % key.Length] - 'A';
                var newChar = (char)((letter - 'A' + shift) % 26 + 'A');
                result.Append(newChar);
                keyIndex++;
            }
            else
            {
                result.Append(letter);
            }
        }

        return result.ToString();
    }

    private string Decrypt(string text, string key)
    {
        var result = new StringBuilder();
        int keyIndex = 0;

        foreach (var letter in text)
        {
            if (char.IsLetter(letter))
            {
                var shift = key[keyIndex % key.Length] - 'A';
                var newChar = (char)((letter - 'A' - shift + 26) % 26 + 'A');
                result.Append(newChar);
                keyIndex++;
            }
            else
            {
                result.Append(letter); 
            }
        }

        return result.ToString();
    }
}
