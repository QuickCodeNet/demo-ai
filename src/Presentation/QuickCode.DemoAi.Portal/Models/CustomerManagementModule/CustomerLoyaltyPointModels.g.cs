using QuickCode.DemoAi.Common.Nswag.Clients.CustomerManagementModuleApi.Contracts;
using System;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Collections.Generic;
using System.Linq;
using QuickCode.DemoAi.Portal.Helpers;

namespace QuickCode.DemoAi.Portal.Models.CustomerManagementModule
{
    public class CustomerLoyaltyPointData : BaseComboBoxModel
    {
        public int TotalPage { get; set; }
        public int CurrentPage { get; set; }
        public int PageSize { get; set; }
        public int NumberOfRecord { get; set; }
        public string SelectedKey { get; set; }
        public CustomerLoyaltyPointDto SelectedItem { get; set; }
        public List<CustomerLoyaltyPointDto> List { get; set; }
    }

    public static partial class CustomerLoyaltyPointExtensions
    {
        public static string GetKey(this CustomerLoyaltyPointDto dto)
        {
            return $"{dto.Id}";
        }
    }
}