namespace QuickCode.DemoAi.HairdresserManagementModule.Persistence.Sql;
public static partial class SqlScripts
{
    public static partial class HairdresserAvailability
    {
        public static class Query
        {
            private const string _prefix = "HairdresserManagementModule.HairdresserAvailability.Query";
            private static string ResourceKey(string sqlName) => $"{_prefix}.{sqlName}";
            public static string GetByHairdresserId => ResourceKey("GetByHairdresserId.g.sql");
        }
    }
}