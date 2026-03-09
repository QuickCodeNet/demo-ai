namespace QuickCode.DemoAi.HairdresserManagementModule.Persistence.Sql;
public static partial class SqlScripts
{
    public static partial class SalonEquipment
    {
        public static class Command
        {
            private const string _prefix = "HairdresserManagementModule.SalonEquipment.Command";
            private static string ResourceKey(string sqlName) => $"{_prefix}.{sqlName}";
            public static string UpdateQuantity => ResourceKey("UpdateQuantity.g.sql");
        }
    }
}