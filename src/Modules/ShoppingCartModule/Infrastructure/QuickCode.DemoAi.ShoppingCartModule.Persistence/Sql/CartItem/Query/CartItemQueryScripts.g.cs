namespace QuickCode.DemoAi.ShoppingCartModule.Persistence.Sql;
public static partial class SqlScripts
{
    public static partial class CartItem
    {
        public static class Query
        {
            private const string _prefix = "ShoppingCartModule.CartItem.Query";
            private static string ResourceKey(string sqlName) => $"{_prefix}.{sqlName}";
            public static string GetByCartId => ResourceKey("GetByCartId.g.sql");
        }
    }
}