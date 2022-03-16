using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Security.Cryptography;

namespace OmegaBakery.Domain.Admin
{
    internal static class LoginService
    {
        public static bool Validate(string username, string password)
        {
            var loginConfig = AppService.InitOptions<LoginConfig>("Login");
            if(loginConfig.Username.Length != 0)
            {
                //var uid = Unprotect(loginConfig.Username);
                var uid = loginConfig.Username;
                if(uid.Equals(username))
                {
                    var pwd = loginConfig.Password;
                    //var pwd = Unprotect(loginConfig.Password);
                    if(password.Length > 0 && !uid.Equals(password))
                    {
                        return false;
                    }
                    return true;
                }
            }
            return false;
        }

        public static bool SetCredentials(string username, string password)
        {
            //var loginConfig = new LoginConfig(Protect(username), Protect(password));
            var loginConfig = new LoginConfig(username, password);
            return AppService.AddOrUpdateAppSetting("Login", loginConfig);
        }

        // Create byte array for additional entropy when using Protect method.
        static byte[] s_additionalEntropy = { 9, 8, 7, 6, 5 };

        public static string? Protect(string data)
        {
            try
            {
                var byteData = Encoding.ASCII.GetBytes(data);
                // Encrypt the data using DataProtectionScope.CurrentUser. The result can be decrypted
                // only by the same current user.
#pragma warning disable CA1416 // Validate platform compatibility
                var encryptedData = ProtectedData.Protect(byteData, s_additionalEntropy, DataProtectionScope.LocalMachine);
#pragma warning restore CA1416 // Validate platform compatibility
                return Encoding.ASCII.GetString(encryptedData);
            }
            catch (CryptographicException e)
            {
                Console.WriteLine("Data was not encrypted. An error occurred.");
                Console.WriteLine(e.ToString());
                return null;
            }
        }

        public static string? Unprotect(string data)
        {
            try
            {
                var byteData = Encoding.ASCII.GetBytes(data);
                if (byteData.Length != 0)
                {
                    // Decrypt the data using DataProtectionScope.CurrentUser.
#pragma warning disable CA1416 // Validate platform compatibility
                    var encryptedData = ProtectedData.Unprotect(byteData, s_additionalEntropy, DataProtectionScope.LocalMachine);
#pragma warning restore CA1416 // Validate platform compatibility
                    return Encoding.ASCII.GetString(encryptedData);
                }
                return String.Empty;
            }
            catch (CryptographicException e)
            {
                Console.WriteLine("Data was not decrypted. An error occurred.");
                Console.WriteLine(e.ToString());
                return null;
            }
        }
    }
}
