using System;
using System.Collections.Specialized;
using System.Linq;
using System.Runtime.InteropServices;
using System.Security;

namespace Idfy.Events.Client.Infastructure
{
    internal static class Extensions
    {
        public static SecureString ToSecureString(string value)
        {
            var secure = new SecureString();
            foreach (var c in value)
            {
                secure.AppendChar(c);
            }
            return secure;
        }

        public static string SecureStringToString(SecureString value)
        {
            IntPtr valuePtr = IntPtr.Zero;
            try
            {
                valuePtr = Marshal.SecureStringToGlobalAllocUnicode(value);
                return Marshal.PtrToStringUni(valuePtr);
            }
            finally
            {
                Marshal.ZeroFreeGlobalAllocUnicode(valuePtr);
            }
        }
        
        public static string ToQueryString(this NameValueCollection nvc)
        {
            var array = (from key in nvc.AllKeys
                from value in nvc.GetValues(key)
                select $"{key}={value}").ToArray();
            return "?" + string.Join("&", array);
        }
    }
}