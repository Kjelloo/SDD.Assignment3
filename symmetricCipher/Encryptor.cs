using System.Security.Cryptography;

namespace symmetricCipher;

public class Encryptor
{
    private readonly Aes _aes;

    public Encryptor(Aes aes)
    {
        _aes = aes;
    }

    public byte[] Encrypt(byte[] data, byte[] iv)
    {
        _aes.IV = iv;

        using MemoryStream memoryStream = new();
        using CryptoStream cryptoStream = new(memoryStream, _aes.CreateEncryptor(), CryptoStreamMode.Write);
        cryptoStream.Write(data, 0, data.Length);
        cryptoStream.FlushFinalBlock();

        return memoryStream.ToArray();
    }
}

