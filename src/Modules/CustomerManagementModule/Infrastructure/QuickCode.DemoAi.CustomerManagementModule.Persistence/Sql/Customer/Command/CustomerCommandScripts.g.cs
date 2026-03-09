namespace QuickCode.DemoAi.CustomerManagementModule.Persistence.Sql;
public static partial class SqlScripts
{
    public static partial class Customer
    {
        public static class Command
        {
            private const string _prefix = "CustomerManagementModule.Customer.Command";
            private static string ResourceKey(string sqlName) => $"{_prefix}.{sqlName}";
            public static string Activate => ResourceKey("Activate.g.sql");
            public static string Deactivate => ResourceKey("Deactivate.g.sql");
        }
    }
}