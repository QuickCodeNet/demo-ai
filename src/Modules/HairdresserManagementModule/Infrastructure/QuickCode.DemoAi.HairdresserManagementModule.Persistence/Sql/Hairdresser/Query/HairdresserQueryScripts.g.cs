namespace QuickCode.DemoAi.HairdresserManagementModule.Persistence.Sql;
public static partial class SqlScripts
{
    public static partial class Hairdresser
    {
        public static class Query
        {
            private const string _prefix = "HairdresserManagementModule.Hairdresser.Query";
            private static string ResourceKey(string sqlName) => $"{_prefix}.{sqlName}";
            public static string GetActive => ResourceKey("GetActive.g.sql");
            public static string SearchByName => ResourceKey("SearchByName.g.sql");
            public static string GetServicesForHairdressers => ResourceKey("GetServicesForHairdressers.g.sql");
            public static string GetServicesForHairdressersDetails => ResourceKey("GetServicesForHairdressersDetails.g.sql");
            public static string GetHairdresserAvailabilitiesForHairdressers => ResourceKey("GetHairdresserAvailabilitiesForHairdressers.g.sql");
            public static string GetHairdresserAvailabilitiesForHairdressersDetails => ResourceKey("GetHairdresserAvailabilitiesForHairdressersDetails.g.sql");
            public static string GetHairdresserNotesForHairdressers => ResourceKey("GetHairdresserNotesForHairdressers.g.sql");
            public static string GetHairdresserNotesForHairdressersDetails => ResourceKey("GetHairdresserNotesForHairdressersDetails.g.sql");
        }
    }
}