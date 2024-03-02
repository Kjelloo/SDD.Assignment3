using System.Text;

namespace HMACSHA256;

public class Hmac
{
    public static byte[] GenerateHmac(string message, byte[] key)
    {
        using var hmac = new System.Security.Cryptography.HMACSHA256(key);
        return hmac.ComputeHash(Encoding.UTF8.GetBytes(message));
    }
    
    public bool VerifyHmac(string message, byte[] key, byte[] hash)
    {
        var newHash = GenerateHmac(message, key);
        return newHash.SequenceEqual(hash);
    }
}

