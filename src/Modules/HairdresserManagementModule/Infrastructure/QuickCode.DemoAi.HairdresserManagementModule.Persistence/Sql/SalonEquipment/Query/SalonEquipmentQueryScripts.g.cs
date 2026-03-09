namespace QuickCode.DemoAi.HairdresserManagementModule.Persistence.Sql;
public static partial class SqlScripts
{
    public static partial class SalonEquipment
    {
        public static class Query
        {
            private const string _prefix = "HairdresserManagementModule.SalonEquipment.Query";
            private static string ResourceKey(string sqlName) => $"{_prefix}.{sqlName}";
            public static string GetAll => ResourceKey("GetAll.g.sql");
        }
    }
}