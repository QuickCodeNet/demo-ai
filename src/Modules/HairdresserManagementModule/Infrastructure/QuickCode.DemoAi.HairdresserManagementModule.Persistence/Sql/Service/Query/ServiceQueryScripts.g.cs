namespace QuickCode.DemoAi.HairdresserManagementModule.Persistence.Sql;
public static partial class SqlScripts
{
    public static partial class Service
    {
        public static class Query
        {
            private const string _prefix = "HairdresserManagementModule.Service.Query";
            private static string ResourceKey(string sqlName) => $"{_prefix}.{sqlName}";
            public static string GetByHairdresserId => ResourceKey("GetByHairdresserId.g.sql");
            public static string GetByCategory => ResourceKey("GetByCategory.g.sql");
            public static string GetServicePricesForServices => ResourceKey("GetServicePricesForServices.g.sql");
            public static string GetServicePricesForServicesDetails => ResourceKey("GetServicePricesForServicesDetails.g.sql");
        }
    }
}