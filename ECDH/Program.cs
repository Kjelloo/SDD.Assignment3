using System.Security.Cryptography;

class DiffieHellmanExample
{
    static void Main()
    {
        using (var alice = new ECDiffieHellmanCng())
        using (var bob = new ECDiffieHellmanCng())
        {
            alice.KeyDerivationFunction = ECDiffieHellmanKeyDerivationFunction.Hash;
            alice.HashAlgorithm = CngAlgorithm.Sha256;

            bob.KeyDerivationFunction = ECDiffieHellmanKeyDerivationFunction.Hash;
            bob.HashAlgorithm = CngAlgorithm.Sha256;

            byte[] alicePublicKey = alice.PublicKey.ToByteArray();
            byte[] bobPublicKey = bob.PublicKey.ToByteArray();

            byte[] aliceKey = alice.DeriveKeyMaterial(CngKey.Import(bobPublicKey, CngKeyBlobFormat.EccPublicBlob));
            byte[] bobKey = bob.DeriveKeyMaterial(CngKey.Import(alicePublicKey, CngKeyBlobFormat.EccPublicBlob));

            Console.WriteLine("Alice's computed key: " + BitConverter.ToString(aliceKey).Replace("-", ""));
            Console.WriteLine("Bob's computed key: " + BitConverter.ToString(bobKey).Replace("-", ""));
            
            // output
            // Alice's computed key: A9129AB339D94A41D8D1DBF93F8FCF89A1361B7B1B7CB2960A3241028465D9DA
            // Bob's computed key: A9129AB339D94A41D8D1DBF93F8FCF89A1361B7B1B7CB2960A3241028465D9DA
        }
    }
}

