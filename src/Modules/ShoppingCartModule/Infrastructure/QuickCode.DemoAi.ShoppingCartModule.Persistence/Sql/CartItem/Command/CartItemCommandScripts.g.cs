namespace QuickCode.DemoAi.ShoppingCartModule.Persistence.Sql;
public static partial class SqlScripts
{
    public static partial class CartItem
    {
        public static class Command
        {
            private const string _prefix = "ShoppingCartModule.CartItem.Command";
            private static string ResourceKey(string sqlName) => $"{_prefix}.{sqlName}";
            public static string AdjustQuantity => ResourceKey("AdjustQuantity.g.sql");
            public static string RemoveItem => ResourceKey("RemoveItem.g.sql");
        }
    }
}