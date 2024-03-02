using System.Security.Cryptography;
using AssignmentDel2;

// Local
var localKeyExchange = new ECDiffieHellmanCng();
byte[] localPublicKey;
byte[] localSharedKey;

// Remote
var remoteKeyExchange = new ECDiffieHellmanCng();
byte[] remotePublicKey;
byte[] remoteSharedKey;

var encryptDecrypt = new MessageEncryptDecrypt();
var messageHelper = new MessagingHelper();

localPublicKey = localKeyExchange.PublicKey.ToByteArray();
remotePublicKey = remoteKeyExchange.PublicKey.ToByteArray();

// Exchange shared keys
void ExchangeKeys()
{
    // Send public key to remote
    Console.WriteLine("Local: Sending public key to remote...");
    localSharedKey = KeyExchanger.DeriveKey(localKeyExchange, remotePublicKey);
    Thread.Sleep(500);
    
    // Receive public key from remote
    Console.WriteLine("Remote: Sending public key to local...");
    remoteSharedKey = KeyExchanger.DeriveKey(remoteKeyExchange, localPublicKey);
    Thread.Sleep(500);
    
    // Create session key
    using var aes = Aes.Create();
    aes.GenerateKey();
    byte[] sesKey = aes.Key;
    
    // Encrypt session key with derived key
    byte[] encryptedSessionKey = encryptDecrypt.Encrypt(sesKey, localSharedKey);
    
    // Set session key for local
    localSharedKey = sesKey;
    
    // Send encrypted session key to remote
    Console.WriteLine("Local: Sending encrypted session key to remote...");
    Thread.Sleep(500);
    
    // Decrypt session key with derived key
    byte[] decryptedSessionKey = encryptDecrypt.Decrypt(encryptedSessionKey, remoteSharedKey);
    Console.WriteLine("Remote: Received encrypted session key from local...");
    // Set session key for remote
    remoteSharedKey = decryptedSessionKey;
}

// Send message
void SendMessage()
{
    var messageLocal = "Local: Hello, World!"u8.ToArray();
    var encryptedMessageLocal = messageHelper.SendMessage(messageLocal, localSharedKey);
    Thread.Sleep(500);
    
    messageHelper.ReceiveMessage(encryptedMessageLocal, remoteSharedKey);
    
    var messageRemote = "Remote: World, Hello!"u8.ToArray();
    var encryptedMessageRemote = messageHelper.SendMessage(messageRemote, localSharedKey);
    
    messageHelper.ReceiveMessage(encryptedMessageRemote, remoteSharedKey);
}

ExchangeKeys();
SendMessage();