using QuickCode.DemoAi.Common.Nswag.Clients.AppointmentManagementModuleApi.Contracts;
using System;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Collections.Generic;
using System.Linq;
using QuickCode.DemoAi.Portal.Helpers;

namespace QuickCode.DemoAi.Portal.Models.AppointmentManagementModule
{
    public class AppointmentChargeData : BaseComboBoxModel
    {
        public int TotalPage { get; set; }
        public int CurrentPage { get; set; }
        public int PageSize { get; set; }
        public int NumberOfRecord { get; set; }
        public string SelectedKey { get; set; }
        public AppointmentChargeDto SelectedItem { get; set; }
        public List<AppointmentChargeDto> List { get; set; }
    }

    public static partial class AppointmentChargeExtensions
    {
        public static string GetKey(this AppointmentChargeDto dto)
        {
            return $"{dto.Id}";
        }
    }
}