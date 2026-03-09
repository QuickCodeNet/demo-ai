namespace QuickCode.DemoAi.HairdresserManagementModule.Persistence.Sql;
public static partial class SqlScripts
{
    public static partial class ServicePrice
    {
        public static class Query
        {
            private const string _prefix = "HairdresserManagementModule.ServicePrice.Query";
            private static string ResourceKey(string sqlName) => $"{_prefix}.{sqlName}";
            public static string GetByServiceId => ResourceKey("GetByServiceId.g.sql");
        }
    }
}