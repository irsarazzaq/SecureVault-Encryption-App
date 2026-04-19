using System;

namespace SecureVault.Core
{
    public abstract class CipherBase : ICipher
    {
        public abstract byte[] Encrypt(byte[] data, string key);
        public abstract byte[] Decrypt(byte[] data, string key);

        protected void Validate(byte[] data)
        {
            if (data == null || data.Length == 0)
                throw new Exception("File data is empty!");
        }
    }
}