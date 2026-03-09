using QuickCode.DemoAi.Common.Nswag.Clients.HairdresserManagementModuleApi.Contracts;
using System;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Collections.Generic;
using System.Linq;
using QuickCode.DemoAi.Portal.Helpers;

namespace QuickCode.DemoAi.Portal.Models.HairdresserManagementModule
{
    public class SalonEquipmentData : BaseComboBoxModel
    {
        public int TotalPage { get; set; }
        public int CurrentPage { get; set; }
        public int PageSize { get; set; }
        public int NumberOfRecord { get; set; }
        public string SelectedKey { get; set; }
        public SalonEquipmentDto SelectedItem { get; set; }
        public List<SalonEquipmentDto> List { get; set; }
    }

    public static partial class SalonEquipmentExtensions
    {
        public static string GetKey(this SalonEquipmentDto dto)
        {
            return $"{dto.Id}";
        }
    }
}