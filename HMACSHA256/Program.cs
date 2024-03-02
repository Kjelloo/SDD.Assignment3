using System.Security.Cryptography;
using HMACSHA256;

var key = RandomNumberGenerator.GetBytes(16);

var message = "Hello, world!";
var hmac = new Hmac();

var hash = Hmac.GenerateHmac(message, key);

Console.WriteLine(BitConverter.ToString(hash)); // e.g. 9F-47-0F-F3-C1-5A-31-64-35-28-24-E7-D4-2C-C0-DB

var isValid = hmac.VerifyHmac(message, key, hash);

Console.WriteLine(isValid); // True


