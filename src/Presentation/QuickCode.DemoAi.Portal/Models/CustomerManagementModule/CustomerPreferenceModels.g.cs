using QuickCode.DemoAi.Common.Nswag.Clients.CustomerManagementModuleApi.Contracts;
using System;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Collections.Generic;
using System.Linq;
using QuickCode.DemoAi.Portal.Helpers;

namespace QuickCode.DemoAi.Portal.Models.CustomerManagementModule
{
    public class CustomerPreferenceData : BaseComboBoxModel
    {
        public int TotalPage { get; set; }
        public int CurrentPage { get; set; }
        public int PageSize { get; set; }
        public int NumberOfRecord { get; set; }
        public string SelectedKey { get; set; }
        public CustomerPreferenceDto SelectedItem { get; set; }
        public List<CustomerPreferenceDto> List { get; set; }
    }

    public static partial class CustomerPreferenceExtensions
    {
        public static string GetKey(this CustomerPreferenceDto dto)
        {
            return $"{dto.Id}";
        }
    }
}