namespace QuickCode.DemoAi.HairdresserManagementModule.Persistence.Sql;
public static partial class SqlScripts
{
    public static partial class HairdresserNote
    {
        public static class Query
        {
            private const string _prefix = "HairdresserManagementModule.HairdresserNote.Query";
            private static string ResourceKey(string sqlName) => $"{_prefix}.{sqlName}";
            public static string GetByHairdresserId => ResourceKey("GetByHairdresserId.g.sql");
        }
    }
}