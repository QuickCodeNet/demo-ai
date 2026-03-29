namespace QuickCode.DemoAi.ProductCatalogModule.Persistence.Sql;
public static partial class SqlScripts
{
    public static partial class ProductCategory
    {
        public static class Query
        {
            private const string _prefix = "ProductCatalogModule.ProductCategory.Query";
            private static string ResourceKey(string sqlName) => $"{_prefix}.{sqlName}";
            public static string GetByProductId => ResourceKey("GetByProductId.g.sql");
            public static string GetByCategoryId => ResourceKey("GetByCategoryId.g.sql");
        }
    }
}