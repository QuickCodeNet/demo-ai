namespace QuickCode.DemoAi.ProductCatalogModule.Persistence.Sql;
public static partial class SqlScripts
{
    public static partial class Product
    {
        public static class Query
        {
            private const string _prefix = "ProductCatalogModule.Product.Query";
            private static string ResourceKey(string sqlName) => $"{_prefix}.{sqlName}";
            public static string GetActive => ResourceKey("GetActive.g.sql");
            public static string SearchByName => ResourceKey("SearchByName.g.sql");
            public static string GetByCategoryId => ResourceKey("GetByCategoryId.g.sql");
            public static string GetLowStock => ResourceKey("GetLowStock.g.sql");
        }
    }
}