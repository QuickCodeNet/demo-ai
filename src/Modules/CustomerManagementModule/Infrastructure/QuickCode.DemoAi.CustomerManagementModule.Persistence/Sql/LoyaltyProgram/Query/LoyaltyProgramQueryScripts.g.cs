namespace QuickCode.DemoAi.CustomerManagementModule.Persistence.Sql;
public static partial class SqlScripts
{
    public static partial class LoyaltyProgram
    {
        public static class Query
        {
            private const string _prefix = "CustomerManagementModule.LoyaltyProgram.Query";
            private static string ResourceKey(string sqlName) => $"{_prefix}.{sqlName}";
            public static string GetAll => ResourceKey("GetAll.g.sql");
            public static string GetCustomerLoyaltyPointsForLoyaltyPrograms => ResourceKey("GetCustomerLoyaltyPointsForLoyaltyPrograms.g.sql");
            public static string GetCustomerLoyaltyPointsForLoyaltyProgramsDetails => ResourceKey("GetCustomerLoyaltyPointsForLoyaltyProgramsDetails.g.sql");
        }
    }
}