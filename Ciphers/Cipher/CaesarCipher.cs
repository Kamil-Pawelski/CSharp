namespace Ciphers.Cipher;

internal class CaesarCipher : Cipher
{
    private int Shift { get; set; }
    public override void Encode()
    {
        var (isValid, resultText) = GetTextAndShift("encode");

        if (!isValid)
            return;

        PlainText = resultText;
        CipherText = ShiftText(PlainText, Shift);

        Console.WriteLine($"\nEncoded result: {CipherText}");
    }

    public override void Decode()
    {
        var (isValid, resultText) = GetTextAndShift("decode");

        if (!isValid)
            return;

        CipherText = resultText;
        PlainText = ShiftText(CipherText, -Shift);

        Console.WriteLine($"\nDecoded result: {PlainText}");
    }

    private (bool, string) GetTextAndShift(string action)
    {
        Console.WriteLine($"Enter text to {action}:");
        var input = Console.ReadLine();

        if (string.IsNullOrWhiteSpace(input))
        {
            Console.WriteLine($"There is no text to {action}.");
            return (false, string.Empty);
        }

        Console.WriteLine("Enter shift (1–25):");
        if (!int.TryParse(Console.ReadLine(), out int shift))
        {
            Console.WriteLine("Invalid number format.");
            return (false, string.Empty);
        }

        if (shift is < 1 or > 25)
        {
            Console.WriteLine("Shift must be between 1 and 25.");
            return (false, string.Empty);
        }

        Shift = shift;
        return (true, input);
    }

    private string ShiftText(string plainText, int shift)
    {
        var result = new char[plainText.Length];

        for (int i = 0; i < plainText.Length; i++)
        {
            char character = plainText[i];

            if (char.IsLetter(character))
            {
                bool isUpper = char.IsUpper(character);
                char offset = isUpper ? 'A' : 'a';
                int shifted = ((character - offset + shift) % 26 + 26) % 26;
                result[i] = (char)(offset + shifted);
            }
            else
            {
                result[i] = character;
            }
        }

        return new string(result);
    }
}
