namespace QuickCode.DemoAi.PaymentProcessingModule.Persistence.Sql;
public static partial class SqlScripts
{
    public static partial class Payment
    {
        public static class Command
        {
            private const string _prefix = "PaymentProcessingModule.Payment.Command";
            private static string ResourceKey(string sqlName) => $"{_prefix}.{sqlName}";
            public static string UpdateStatus => ResourceKey("UpdateStatus.g.sql");
        }
    }
}