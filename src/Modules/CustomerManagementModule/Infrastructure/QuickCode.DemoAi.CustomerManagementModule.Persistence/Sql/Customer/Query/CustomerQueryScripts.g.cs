namespace QuickCode.DemoAi.CustomerManagementModule.Persistence.Sql;
public static partial class SqlScripts
{
    public static partial class Customer
    {
        public static class Query
        {
            private const string _prefix = "CustomerManagementModule.Customer.Query";
            private static string ResourceKey(string sqlName) => $"{_prefix}.{sqlName}";
            public static string GetActive => ResourceKey("GetActive.g.sql");
            public static string SearchByName => ResourceKey("SearchByName.g.sql");
            public static string GetCustomerAddressesForCustomers => ResourceKey("GetCustomerAddressesForCustomers.g.sql");
            public static string GetCustomerAddressesForCustomersDetails => ResourceKey("GetCustomerAddressesForCustomersDetails.g.sql");
            public static string GetCustomerNotesForCustomers => ResourceKey("GetCustomerNotesForCustomers.g.sql");
            public static string GetCustomerNotesForCustomersDetails => ResourceKey("GetCustomerNotesForCustomersDetails.g.sql");
            public static string GetCustomerPreferencesForCustomers => ResourceKey("GetCustomerPreferencesForCustomers.g.sql");
            public static string GetCustomerPreferencesForCustomersDetails => ResourceKey("GetCustomerPreferencesForCustomersDetails.g.sql");
            public static string GetCustomerLoyaltyPointsForCustomers => ResourceKey("GetCustomerLoyaltyPointsForCustomers.g.sql");
            public static string GetCustomerLoyaltyPointsForCustomersDetails => ResourceKey("GetCustomerLoyaltyPointsForCustomersDetails.g.sql");
        }
    }
}