using System;
using System.Globalization;
using System.Runtime.InteropServices;
using System.Security;
using System.Threading;
using System.Threading.Tasks;
using System.Web.Script.Serialization;

namespace Idfy.Events.Client
{
    public static class Extensions
    {
        private static readonly JavaScriptSerializer Serializer;
        private static readonly TaskFactory _myTaskFactory = new TaskFactory(CancellationToken.None, TaskCreationOptions.None,
            TaskContinuationOptions.None, TaskScheduler.Default);

        static Extensions()
        {
            Serializer = new JavaScriptSerializer
            {
                MaxJsonLength = int.MaxValue
            };
        }

        // Microsoft.AspNet.Identity.AsyncHelper
        public static TResult RunSync<TResult>(this Func<Task<TResult>> func)
        {
            CultureInfo cultureUi = CultureInfo.CurrentUICulture;
            CultureInfo culture = CultureInfo.CurrentCulture;
            return Extensions._myTaskFactory.StartNew<Task<TResult>>(delegate
            {
                Thread.CurrentThread.CurrentCulture = culture;
                Thread.CurrentThread.CurrentUICulture = cultureUi;
                return func();
            }).Unwrap<TResult>().GetAwaiter().GetResult();
        }

        public static void RunSync(this Func<Task> func)
        {
            Extensions._myTaskFactory
                .StartNew<Task>(func)
                .Unwrap()
                .GetAwaiter()
                .GetResult();
        }

        

        public static T Deserialize<T>(string json)
        {
            var obj = Serializer.Deserialize<T>(json);
            return obj;
        }

        internal static SecureString ToSecureString(string value)
        {
            var secure = new SecureString();
            foreach (var c in value)
            {
                secure.AppendChar(c);
            }
            return secure;
        }

        internal static string SecureStringToString(SecureString value)
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
    }
}