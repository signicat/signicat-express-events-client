using System;
using System.Globalization;
using System.Threading;
using System.Threading.Tasks;

namespace Idfy.Events.Client.Infastructure
{
    internal static class AsyncHelper
    {
        private static readonly TaskFactory MyTaskFactory = new TaskFactory(CancellationToken.None,
            TaskCreationOptions.None, TaskContinuationOptions.None, TaskScheduler.Default);

        // Microsoft.AspNet.Identity.AsyncHelper
        public static TResult RunSync<TResult>(this Func<Task<TResult>> func)
        {
            var cultureUi = CultureInfo.CurrentUICulture;
            var culture = CultureInfo.CurrentCulture;

            return MyTaskFactory
                .StartNew<Task<TResult>>(delegate
                {
                    Thread.CurrentThread.CurrentCulture = culture;
                    Thread.CurrentThread.CurrentUICulture = cultureUi;
                    return func();
                }).Unwrap<TResult>().GetAwaiter().GetResult();
        }

        public static void RunSync(this Func<Task> func)
        {
            MyTaskFactory
                .StartNew<Task>(func)
                .Unwrap()
                .GetAwaiter()
                .GetResult();
        }
    }
}