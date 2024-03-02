using System.Security.Cryptography;

namespace symmetricCipher;

public class Decryptor
{
    private readonly Aes _aes;

    public Decryptor(Aes aes)
    {
        _aes = aes;
    }

    public byte[] Decrypt(byte[] data, byte[] iv)
    {
        _aes.IV = iv;

        using MemoryStream memoryStream = new();
        using CryptoStream cryptoStream = new(memoryStream, _aes.CreateDecryptor(), CryptoStreamMode.Write);
        cryptoStream.Write(data, 0, data.Length);
        cryptoStream.FlushFinalBlock();

        return memoryStream.ToArray();
    }
}

