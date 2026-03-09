using QuickCode.DemoAi.Common.Nswag.Clients.HairdresserManagementModuleApi.Contracts;
using System;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Collections.Generic;
using System.Linq;
using QuickCode.DemoAi.Portal.Helpers;

namespace QuickCode.DemoAi.Portal.Models.HairdresserManagementModule
{
    public class HairdresserData : BaseComboBoxModel
    {
        public int TotalPage { get; set; }
        public int CurrentPage { get; set; }
        public int PageSize { get; set; }
        public int NumberOfRecord { get; set; }
        public string SelectedKey { get; set; }
        public HairdresserDto SelectedItem { get; set; }
        public List<HairdresserDto> List { get; set; }
    }

    public static partial class HairdresserExtensions
    {
        public static string GetKey(this HairdresserDto dto)
        {
            return $"{dto.Id}";
        }
    }
}