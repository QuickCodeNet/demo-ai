namespace QuickCode.DemoAi.AppointmentManagementModule.Persistence.Sql;
public static partial class SqlScripts
{
    public static partial class AppointmentCharge
    {
        public static class Query
        {
            private const string _prefix = "AppointmentManagementModule.AppointmentCharge.Query";
            private static string ResourceKey(string sqlName) => $"{_prefix}.{sqlName}";
            public static string GetByAppointmentId => ResourceKey("GetByAppointmentId.g.sql");
        }
    }
}