namespace QuickCode.DemoAi.CustomerManagementModule.Persistence.Sql;
public static partial class SqlScripts
{
    public static partial class CustomerPreference
    {
        public static class Query
        {
            private const string _prefix = "CustomerManagementModule.CustomerPreference.Query";
            private static string ResourceKey(string sqlName) => $"{_prefix}.{sqlName}";
            public static string GetByCustomerId => ResourceKey("GetByCustomerId.g.sql");
        }
    }
}