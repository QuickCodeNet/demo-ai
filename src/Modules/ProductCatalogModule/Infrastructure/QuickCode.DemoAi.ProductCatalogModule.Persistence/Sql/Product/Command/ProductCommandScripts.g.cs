namespace QuickCode.DemoAi.ProductCatalogModule.Persistence.Sql;
public static partial class SqlScripts
{
    public static partial class Product
    {
        public static class Command
        {
            private const string _prefix = "ProductCatalogModule.Product.Command";
            private static string ResourceKey(string sqlName) => $"{_prefix}.{sqlName}";
            public static string AdjustStock => ResourceKey("AdjustStock.g.sql");
            public static string SetPrice => ResourceKey("SetPrice.g.sql");
            public static string Activate => ResourceKey("Activate.g.sql");
            public static string Deactivate => ResourceKey("Deactivate.g.sql");
        }
    }
}