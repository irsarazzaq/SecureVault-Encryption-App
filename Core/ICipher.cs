namespace SecureVault.Core
{
    public interface ICipher
    {
        byte[] Encrypt(byte[] data, string key);
        byte[] Decrypt(byte[] data, string key);
    }
}