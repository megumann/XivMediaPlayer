using Sentry;
using System;

namespace MediaPlayerCore.Helpers
{
    public static class ErrorLogger
    {
        static ErrorLogger()
        {
            SentrySdk.Init(options =>
            {
                // A Sentry Data Source Name (DSN) is required.
                // See https://docs.sentry.io/product/sentry-basics/dsn-explainer/
                // You can set it in the SENTRY_DSN environment variable, or you can set it in code here.
                options.Dsn = "https://7e62dc456716d70187038d999710c80e@o4511271181287424.ingest.us.sentry.io/4511928344444928";

                // When debug is enabled, the Sentry client will emit detailed debugging information to the console.
                // This might be helpful, or might interfere with the normal operation of your application.
                // We enable it here for demonstration purposes when first trying Sentry.
                // You shouldn't do this in your applications unless you're troubleshooting issues with Sentry.
#if DEBUG
                options.Debug = true;
#endif

                // This option is recommended. It enables Sentry's "Release Health" feature.
                options.AutoSessionTracking = true;
            });
        }

        public static void CaptureException(Exception ex) => SentrySdk.CaptureException(ex);

        public static void CaptureMessage(string message, SentryLevel level = SentryLevel.Info) => SentrySdk.CaptureMessage(message, level);
    }
}