namespace QuickCode.DemoAi.AppointmentManagementModule.Persistence.Sql;
public static partial class SqlScripts
{
    public static partial class WaitingList
    {
        public static class Query
        {
            private const string _prefix = "AppointmentManagementModule.WaitingList.Query";
            private static string ResourceKey(string sqlName) => $"{_prefix}.{sqlName}";
            public static string GetByServiceId => ResourceKey("GetByServiceId.g.sql");
        }
    }
}