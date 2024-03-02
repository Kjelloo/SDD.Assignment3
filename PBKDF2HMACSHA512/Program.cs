using System.Security.Cryptography;
using System.Text;


static byte[] DeriveKey(string password, byte[] salt, int derivedKeyLength, int iterations)
{
    using (var pbkdf2 = new Rfc2898DeriveBytes(password, salt, iterations, HashAlgorithmName.SHA512))
    {
        return pbkdf2.GetBytes(derivedKeyLength);
    }
}

string password = "VerySecurePassword123!";
byte[] salt = Encoding.UTF8.GetBytes("SomeSalt123");

// Derive key using PBKDF2-HMAC-SHA512
int derivedKeyLength = 64; // 64 bytes = 512 bits
int iterations = 10000; // Number of iterations

byte[] derivedKey = DeriveKey(password, salt, derivedKeyLength, iterations);

// Print the derived key
Console.WriteLine("Derived Key (Base64): " + Convert.ToBase64String(derivedKey));
// Derived Key (Base64): JFbr50BRvj9onmmWN+WqZ29+fEkS3W8bne2tLClLTMGEvVXad0+OndVSDqQKLKhfwYpe+WUF9+ptK49vDx9kPg==

