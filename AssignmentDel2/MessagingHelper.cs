using System.Text;

namespace AssignmentDel2;

public class MessagingHelper
{
    public byte[] SendMessage(byte[] message, byte[] key)
    {
        MessageEncryptDecrypt messageEncryptorHelper = new();
        byte[] encryptedMessage = messageEncryptorHelper.Encrypt(message, key);
        
        Console.WriteLine("Encrypted message: " + Convert.ToBase64String(encryptedMessage));

        return encryptedMessage;
    }
    
    public void ReceiveMessage(byte[] encryptedMessage, byte[] key)
    {
        MessageEncryptDecrypt messageEncryptorHelper = new();
        byte[] decryptedMessage = messageEncryptorHelper.Decrypt(encryptedMessage, key);
        
        Console.WriteLine("Decrypted message: " + Encoding.UTF8.GetString(decryptedMessage));
    }
}