namespace QuickCode.DemoAi.OrderManagementModule.Persistence.Sql;
public static partial class SqlScripts
{
    public static partial class Order
    {
        public static class Query
        {
            private const string _prefix = "OrderManagementModule.Order.Query";
            private static string ResourceKey(string sqlName) => $"{_prefix}.{sqlName}";
            public static string GetByUserId => ResourceKey("GetByUserId.g.sql");
            public static string GetByStatus => ResourceKey("GetByStatus.g.sql");
            public static string GetPendingOrders => ResourceKey("GetPendingOrders.g.sql");
            public static string GetOrdersByDateRange => ResourceKey("GetOrdersByDateRange.g.sql");
            public static string GetHighValueOrders => ResourceKey("GetHighValueOrders.g.sql");
        }
    }
}