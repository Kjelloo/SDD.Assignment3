using System.Security.Cryptography;
using System.Text;
using symmetricCipher;

var plaintexts = new[]
{
    "Hello, world!",
    "This is a secret message.",
    "Don't tell anyone!"
};

var aes = Aes.Create();
aes.Mode = CipherMode.CBC;
aes.Key = RandomNumberGenerator.GetBytes(32);

var encryptor = new Encryptor(aes);
var decryptor = new Decryptor(aes);

foreach (var messages in plaintexts)
{
    var iv = RandomNumberGenerator.GetBytes(16);
    
    Console.WriteLine("_".PadLeft(40, '_') + "\n");
    // Original message
    Console.WriteLine("Original message: " + messages);
    
    // Encrypt
    var encrypted = encryptor.Encrypt(Encoding.UTF8.GetBytes(messages), iv);
    Console.WriteLine("Encrypted message: " + BitConverter.ToString(encrypted).Replace("-", ""));
    
    // Decrypt
    var decrypted = decryptor.Decrypt(encrypted, iv);
    Console.WriteLine("Decrypted message: " + Encoding.UTF8.GetString(decrypted));
    Console.WriteLine("_".PadLeft(40, '_') + "\n");
}

