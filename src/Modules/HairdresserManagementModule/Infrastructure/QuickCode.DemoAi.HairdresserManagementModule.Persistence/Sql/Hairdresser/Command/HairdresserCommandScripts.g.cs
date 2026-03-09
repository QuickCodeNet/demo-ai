namespace QuickCode.DemoAi.HairdresserManagementModule.Persistence.Sql;
public static partial class SqlScripts
{
    public static partial class Hairdresser
    {
        public static class Command
        {
            private const string _prefix = "HairdresserManagementModule.Hairdresser.Command";
            private static string ResourceKey(string sqlName) => $"{_prefix}.{sqlName}";
            public static string Activate => ResourceKey("Activate.g.sql");
            public static string Deactivate => ResourceKey("Deactivate.g.sql");
        }
    }
}