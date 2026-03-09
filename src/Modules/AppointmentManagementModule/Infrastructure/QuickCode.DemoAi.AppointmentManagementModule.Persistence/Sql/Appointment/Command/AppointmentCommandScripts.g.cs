namespace QuickCode.DemoAi.AppointmentManagementModule.Persistence.Sql;
public static partial class SqlScripts
{
    public static partial class Appointment
    {
        public static class Command
        {
            private const string _prefix = "AppointmentManagementModule.Appointment.Command";
            private static string ResourceKey(string sqlName) => $"{_prefix}.{sqlName}";
            public static string Confirm => ResourceKey("Confirm.g.sql");
            public static string Cancel => ResourceKey("Cancel.g.sql");
        }
    }
}