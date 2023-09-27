using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace BallastLane.Infrastructure.Tools
{
    /// <summary>
    /// sample dummy class to simulate encrypt/decrypt strings
    /// </summary>
    public static class EncryptHelper
    {
        public static string EncryptString(string text, string keyString)
        {
            return $"{text}-{keyString}";
        }

        public static string DecryptString(string cipherText, string keyString)
        {
            return cipherText.Remove(cipherText.IndexOf("-" + keyString));
        }
    }
}
