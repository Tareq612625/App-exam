using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace App_Service
{
    [AttributeUsage(AttributeTargets.Class | AttributeTargets.Method)]
    public class UrlEncryptionMiddleware : ActionFilterAttribute
    {
        private readonly RequestDelegate _next;

        public UrlEncryptionMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task Invoke(HttpContext context)
        {
            string originalPath = "https://localhost:7176"+context.Request.Path.Value;
            string encryptedPath = UrlEncryptor.Encrypt(originalPath);
            string encodedPath = Uri.EscapeDataString(encryptedPath);

            //// Ensure the encoded path starts with a forward slash
            if (!encodedPath.StartsWith('/'))
            {
                encodedPath = '/' + encodedPath;
            }

            // Modify the request path with the encoded and encrypted URL
            context.Request.Path = new PathString(encodedPath);

            await _next(context);
        }
    }
    public static class UrlEncryptor
    {
        private static readonly byte[] Key = new byte[32]; // 256-bit key

        public static string Encrypt(string input)
        {
            byte[] inputBytes = Encoding.UTF8.GetBytes(input);

            using (Aes aes = Aes.Create())
            {
                aes.Key = Key;
                aes.GenerateIV();

                ICryptoTransform encryptor = aes.CreateEncryptor(aes.Key, aes.IV);

                using (var encryptedStream = new MemoryStream())
                {
                    using (var cryptoStream = new CryptoStream(encryptedStream, encryptor, CryptoStreamMode.Write))
                    {
                        cryptoStream.Write(inputBytes, 0, inputBytes.Length);
                        cryptoStream.FlushFinalBlock();
                    }

                    byte[] encryptedBytes = encryptedStream.ToArray();

                    // Combine IV and encrypted data into a single string
                    byte[] result = new byte[aes.IV.Length + encryptedBytes.Length];
                    Buffer.BlockCopy(aes.IV, 0, result, 0, aes.IV.Length);
                    Buffer.BlockCopy(encryptedBytes, 0, result, aes.IV.Length, encryptedBytes.Length);

                    return Convert.ToBase64String(result);
                }
            }
        }

        public static string Decrypt(string input)
        {
            byte[] inputBytes = Convert.FromBase64String(input);

            using (Aes aes = Aes.Create())
            {
                aes.Key = Key;

                byte[] iv = new byte[aes.IV.Length];
                Buffer.BlockCopy(inputBytes, 0, iv, 0, aes.IV.Length);
                aes.IV = iv;

                byte[] encryptedBytes = new byte[inputBytes.Length - aes.IV.Length];
                Buffer.BlockCopy(inputBytes, aes.IV.Length, encryptedBytes, 0, encryptedBytes.Length);

                ICryptoTransform decryptor = aes.CreateDecryptor(aes.Key, aes.IV);

                using (var decryptedStream = new MemoryStream())
                {
                    using (var cryptoStream = new CryptoStream(decryptedStream, decryptor, CryptoStreamMode.Write))
                    {
                        cryptoStream.Write(encryptedBytes, 0, encryptedBytes.Length);
                        cryptoStream.FlushFinalBlock();
                    }

                    byte[] decryptedBytes = decryptedStream.ToArray();
                    return Encoding.UTF8.GetString(decryptedBytes);
                }
            }
        }

    }

}
