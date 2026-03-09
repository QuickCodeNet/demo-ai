namespace QuickCode.DemoAi.AppointmentManagementModule.Persistence.Sql;
public static partial class SqlScripts
{
    public static partial class Holiday
    {
        public static class Query
        {
            private const string _prefix = "AppointmentManagementModule.Holiday.Query";
            private static string ResourceKey(string sqlName) => $"{_prefix}.{sqlName}";
            public static string GetAll => ResourceKey("GetAll.g.sql");
        }
    }
}