namespace QuickCode.DemoAi.ShippingModule.Persistence.Sql;
public static partial class SqlScripts
{
    public static partial class Shipment
    {
        public static class Query
        {
            private const string _prefix = "ShippingModule.Shipment.Query";
            private static string ResourceKey(string sqlName) => $"{_prefix}.{sqlName}";
            public static string GetByOrderId => ResourceKey("GetByOrderId.g.sql");
            public static string GetByStatus => ResourceKey("GetByStatus.g.sql");
        }
    }
}