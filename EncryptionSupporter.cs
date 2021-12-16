using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace GersangClientStation {
    public class EncryptionSupporter {
        public static string Protect(string origin) {
            string PasswordProtect = Convert.ToBase64String(ProtectedData.Protect(Encoding.UTF8.GetBytes(origin), null, DataProtectionScope.CurrentUser));
            return PasswordProtect;
        }
        public static string Unprotect(string origin) {
            var PasswordUnprotect = Encoding.UTF8.GetString(ProtectedData.Unprotect(Convert.FromBase64String(origin), null, DataProtectionScope.CurrentUser));
            return PasswordUnprotect; 
        }
    }
}
