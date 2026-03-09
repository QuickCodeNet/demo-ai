namespace QuickCode.DemoAi.AppointmentManagementModule.Persistence.Sql;
public static partial class SqlScripts
{
    public static partial class AppointmentReminder
    {
        public static class Query
        {
            private const string _prefix = "AppointmentManagementModule.AppointmentReminder.Query";
            private static string ResourceKey(string sqlName) => $"{_prefix}.{sqlName}";
            public static string GetUnsentReminders => ResourceKey("GetUnsentReminders.g.sql");
        }
    }
}