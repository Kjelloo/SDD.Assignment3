using System.Security.Cryptography;
using System.Text;

var plaintext = "Hello, World!";

var sha512 = SHA512.Create();
var hash = sha512.ComputeHash(Encoding.UTF8.GetBytes(plaintext));
Console.WriteLine(BitConverter.ToString(hash).Replace("-", ""));

// output
// 374D794A95CDCFD8B35993185FEF9BA368F160D8DAF432D08BA9F1ED1 -
// E5ABE6CC69291E0FA2FE0006A52570EF18C19DEF4E617C33CE52EF0A6E5FBE318CB0387

