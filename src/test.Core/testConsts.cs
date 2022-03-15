using test.Debugging;

namespace test
{
    public class testConsts
    {
        public const string LocalizationSourceName = "test";

        public const string ConnectionStringName = "Default";

        public const bool MultiTenancyEnabled = true;


        /// <summary>
        /// Default pass phrase for SimpleStringCipher decrypt/encrypt operations
        /// </summary>
        public static readonly string DefaultPassPhrase =
            DebugHelper.IsDebug ? "gsKxGZ012HLL3MI5" : "fc045b8dd61c44d5b46593671183594b";
    }
}
