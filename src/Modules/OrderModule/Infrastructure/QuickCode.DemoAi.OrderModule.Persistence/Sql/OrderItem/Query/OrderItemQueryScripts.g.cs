namespace QuickCode.DemoAi.OrderModule.Persistence.Sql;
public static partial class SqlScripts
{
    public static partial class OrderItem
    {
        public static class Query
        {
            private const string _prefix = "OrderModule.OrderItem.Query";
            private static string ResourceKey(string sqlName) => $"{_prefix}.{sqlName}";
            public static string GetByOrder => ResourceKey("GetByOrder.g.sql");
            public static string GetByProduct => ResourceKey("GetByProduct.g.sql");
            public static string GetTotalQuantityByProduct => ResourceKey("GetTotalQuantityByProduct.g.sql");
        }
    }
}