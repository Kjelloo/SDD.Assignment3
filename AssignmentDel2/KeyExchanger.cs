using System.Security.Cryptography;

namespace AssignmentDel2;

public class KeyExchanger
{
    public static byte[] DeriveKey(ECDiffieHellmanCng keyExchange, byte[] publicKey)
    {
        return keyExchange.DeriveKeyMaterial(CngKey.Import(publicKey, CngKeyBlobFormat.EccPublicBlob));
    }
}