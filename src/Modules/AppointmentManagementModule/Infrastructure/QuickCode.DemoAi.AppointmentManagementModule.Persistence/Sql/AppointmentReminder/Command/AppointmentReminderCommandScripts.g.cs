namespace QuickCode.DemoAi.AppointmentManagementModule.Persistence.Sql;
public static partial class SqlScripts
{
    public static partial class AppointmentReminder
    {
        public static class Command
        {
            private const string _prefix = "AppointmentManagementModule.AppointmentReminder.Command";
            private static string ResourceKey(string sqlName) => $"{_prefix}.{sqlName}";
            public static string MarkSent => ResourceKey("MarkSent.g.sql");
        }
    }
}