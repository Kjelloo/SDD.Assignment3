using System.Security.Cryptography;

namespace AssignmentDel2;

public class MessageEncryptDecrypt
{
    public byte[] Encrypt(byte[] message, byte[] key)
    {
        using var aes = Aes.Create();
        aes.GenerateIV();
        var iv = aes.IV;

        aes.Key = key;

        using MemoryStream memoryStream = new();
        using CryptoStream cryptoStream = new(memoryStream, aes.CreateEncryptor(), CryptoStreamMode.Write);
        
        cryptoStream.Write(message, 0, message.Length);
        cryptoStream.FlushFinalBlock();

        var encryptedMessage = memoryStream.ToArray();
        var encryptedDataWithIV = new byte[iv.Length + encryptedMessage.Length];
        
        Buffer.BlockCopy(iv, 0, encryptedDataWithIV, 0, iv.Length);
        Buffer.BlockCopy(encryptedMessage, 0, encryptedDataWithIV, iv.Length, encryptedMessage.Length);

        return encryptedDataWithIV;
    }
    
    public byte[] Decrypt(byte[] encryptedMessageWithIV, byte[] key)
    {
        var iv = new byte[16]; // Assuming 16 bytes IV size for AES
        Buffer.BlockCopy(encryptedMessageWithIV, 0, iv, 0, iv.Length);

        var encryptedMessage = new byte[encryptedMessageWithIV.Length - iv.Length];
        Buffer.BlockCopy(encryptedMessageWithIV, iv.Length, encryptedMessage, 0, encryptedMessage.Length);

        using var aes = Aes.Create();
        aes.Key = key;
        aes.IV = iv;

        using MemoryStream memoryStream = new();
        using CryptoStream cryptoStream = new(memoryStream, aes.CreateDecryptor(), CryptoStreamMode.Write);
        
        cryptoStream.Write(encryptedMessage, 0, encryptedMessage.Length);
        cryptoStream.FlushFinalBlock();
        
        return memoryStream.ToArray();
    }
}