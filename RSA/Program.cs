using System.Security.Cryptography;
using System.Text;

byte[] message = Encoding.UTF8.GetBytes("Hello, World!");

byte[] encryptedMessage;
byte[] decryptedMessage;

using (var rsa = new RSACryptoServiceProvider(2048))
{

    var publicKey = rsa.ExportParameters(false);
    var privateKey = rsa.ExportParameters(true);
    
    encryptedMessage = rsa.Encrypt(message, true);
    
    Console.WriteLine("Public key: " + BitConverter.ToString(publicKey.Modulus).Replace("-", ""));
    Console.WriteLine("Private key: " + BitConverter.ToString(privateKey.Modulus).Replace("-", ""));
    
    Console.WriteLine("Encrypted message: " + BitConverter.ToString(encryptedMessage).Replace("-", ""));
    
    decryptedMessage = rsa.Decrypt(encryptedMessage, true);
    
    Console.WriteLine("Decrypted message: " + Encoding.UTF8.GetString(decryptedMessage));
}

