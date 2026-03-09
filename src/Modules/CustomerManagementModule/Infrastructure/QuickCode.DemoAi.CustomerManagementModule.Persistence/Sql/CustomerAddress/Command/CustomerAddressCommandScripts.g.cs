namespace QuickCode.DemoAi.CustomerManagementModule.Persistence.Sql;
public static partial class SqlScripts
{
    public static partial class CustomerAddress
    {
        public static class Command
        {
            private const string _prefix = "CustomerManagementModule.CustomerAddress.Command";
            private static string ResourceKey(string sqlName) => $"{_prefix}.{sqlName}";
            public static string SetDefault => ResourceKey("SetDefault.g.sql");
        }
    }
}