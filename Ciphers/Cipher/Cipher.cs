namespace Ciphers.Cipher;

internal abstract class Cipher
{
    public string? PlainText { get; set; }
    public string? CipherText { get; set; }

    public abstract void Encode();
    public abstract void Decode();
}
