using System.Text;
using NSec.Cryptography;

var message = Encoding.UTF8.GetBytes("Hello, World!");

var algorithm = SignatureAlgorithm.Ed25519;

// create a new key pair
using var key = Key.Create(algorithm);

// sign the data using the private key
var signature = algorithm.Sign(key, message);

// verify the data using the signature and the public key
if (algorithm.Verify(key.PublicKey, message, signature))
{
    Console.WriteLine("The signature is valid.");
}
else
{
    Console.WriteLine("The signature is invalid.");
}

