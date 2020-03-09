using ConsoleAppFramework;
using Gaspra.Signing.Interfaces;
using System;

namespace Gaspra.Encryption
{
    public class EncryptionService : ConsoleAppBase
    {
        private readonly SigningService signingService;

        public EncryptionService(SigningService signingService)
        {
            this.signingService = signingService;
        }

        public void Run(
            [Option("e", "text to be encrypted")] string encrypt = "",
            [Option("d", "text to be decrypted")] string decrypt = "")
        {
            if(!string.IsNullOrWhiteSpace(encrypt))
            {
                Console.WriteLine(signingService.Encrypt(encrypt));
            }

            if(!string.IsNullOrWhiteSpace(decrypt))
            {
                Console.WriteLine(signingService.Decrypt(decrypt));
            }
        }
    }
}
