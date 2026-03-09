namespace QuickCode.DemoAi.CustomerManagementModule.Persistence.Sql;
public static partial class SqlScripts
{
    public static partial class CustomerAddress
    {
        public static class Query
        {
            private const string _prefix = "CustomerManagementModule.CustomerAddress.Query";
            private static string ResourceKey(string sqlName) => $"{_prefix}.{sqlName}";
            public static string GetByCustomerId => ResourceKey("GetByCustomerId.g.sql");
            public static string GetDefaultByCustomer => ResourceKey("GetDefaultByCustomer.g.sql");
        }
    }
}