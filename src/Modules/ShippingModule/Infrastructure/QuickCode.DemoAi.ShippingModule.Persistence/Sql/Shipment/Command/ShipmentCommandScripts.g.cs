namespace QuickCode.DemoAi.ShippingModule.Persistence.Sql;
public static partial class SqlScripts
{
    public static partial class Shipment
    {
        public static class Command
        {
            private const string _prefix = "ShippingModule.Shipment.Command";
            private static string ResourceKey(string sqlName) => $"{_prefix}.{sqlName}";
            public static string UpdateStatus => ResourceKey("UpdateStatus.g.sql");
        }
    }
}