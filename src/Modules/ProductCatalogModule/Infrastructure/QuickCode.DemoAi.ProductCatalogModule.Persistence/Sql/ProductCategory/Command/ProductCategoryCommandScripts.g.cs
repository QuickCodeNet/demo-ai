namespace QuickCode.DemoAi.ProductCatalogModule.Persistence.Sql;
public static partial class SqlScripts
{
    public static partial class ProductCategory
    {
        public static class Command
        {
            private const string _prefix = "ProductCatalogModule.ProductCategory.Command";
            private static string ResourceKey(string sqlName) => $"{_prefix}.{sqlName}";
            public static string RemoveCategory => ResourceKey("RemoveCategory.g.sql");
        }
    }
}