using QuickCode.DemoAi.Common.Nswag.Clients.HairdresserManagementModuleApi.Contracts;
using System;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Collections.Generic;
using System.Linq;
using QuickCode.DemoAi.Portal.Helpers;

namespace QuickCode.DemoAi.Portal.Models.HairdresserManagementModule
{
    public class ServicePriceData : BaseComboBoxModel
    {
        public int TotalPage { get; set; }
        public int CurrentPage { get; set; }
        public int PageSize { get; set; }
        public int NumberOfRecord { get; set; }
        public string SelectedKey { get; set; }
        public ServicePriceDto SelectedItem { get; set; }
        public List<ServicePriceDto> List { get; set; }
    }

    public static partial class ServicePriceExtensions
    {
        public static string GetKey(this ServicePriceDto dto)
        {
            return $"{dto.Id}";
        }
    }
}