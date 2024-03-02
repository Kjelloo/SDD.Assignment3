using System.Security.Cryptography;

var crng = RandomNumberGenerator.GetBytes(16); // 16 bytes = 128 bits

var crngAsHex = BitConverter.ToString(crng); // Convert to hex

Console.WriteLine(crngAsHex); // e.g. 9F-47-0F-F3-C1-5A-31-64-35-28-24-E7-D4-2C-C0-DB


