namespace QuickCode.DemoAi.AppointmentManagementModule.Persistence.Sql;
public static partial class SqlScripts
{
    public static partial class Appointment
    {
        public static class Query
        {
            private const string _prefix = "AppointmentManagementModule.Appointment.Query";
            private static string ResourceKey(string sqlName) => $"{_prefix}.{sqlName}";
            public static string GetByCustomerId => ResourceKey("GetByCustomerId.g.sql");
            public static string GetByServiceId => ResourceKey("GetByServiceId.g.sql");
            public static string GetByDateRange => ResourceKey("GetByDateRange.g.sql");
            public static string GetAppointmentFeedbacksForAppointments => ResourceKey("GetAppointmentFeedbacksForAppointments.g.sql");
            public static string GetAppointmentFeedbacksForAppointmentsDetails => ResourceKey("GetAppointmentFeedbacksForAppointmentsDetails.g.sql");
            public static string GetAppointmentRemindersForAppointments => ResourceKey("GetAppointmentRemindersForAppointments.g.sql");
            public static string GetAppointmentRemindersForAppointmentsDetails => ResourceKey("GetAppointmentRemindersForAppointmentsDetails.g.sql");
            public static string GetAppointmentChargesForAppointments => ResourceKey("GetAppointmentChargesForAppointments.g.sql");
            public static string GetAppointmentChargesForAppointmentsDetails => ResourceKey("GetAppointmentChargesForAppointmentsDetails.g.sql");
        }
    }
}