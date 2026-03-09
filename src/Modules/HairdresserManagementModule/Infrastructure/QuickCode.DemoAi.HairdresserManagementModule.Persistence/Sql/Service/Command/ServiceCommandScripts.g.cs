namespace QuickCode.DemoAi.HairdresserManagementModule.Persistence.Sql;
public static partial class SqlScripts
{
    public static partial class Service
    {
        public static class Command
        {
            private const string _prefix = "HairdresserManagementModule.Service.Command";
            private static string ResourceKey(string sqlName) => $"{_prefix}.{sqlName}";
            public static string UpdatePrice => ResourceKey("UpdatePrice.g.sql");
        }
    }
}