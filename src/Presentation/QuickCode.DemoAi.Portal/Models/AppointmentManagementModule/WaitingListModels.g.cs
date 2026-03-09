using QuickCode.DemoAi.Common.Nswag.Clients.AppointmentManagementModuleApi.Contracts;
using System;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Collections.Generic;
using System.Linq;
using QuickCode.DemoAi.Portal.Helpers;

namespace QuickCode.DemoAi.Portal.Models.AppointmentManagementModule
{
    public class WaitingListData : BaseComboBoxModel
    {
        public int TotalPage { get; set; }
        public int CurrentPage { get; set; }
        public int PageSize { get; set; }
        public int NumberOfRecord { get; set; }
        public string SelectedKey { get; set; }
        public WaitingListDto SelectedItem { get; set; }
        public List<WaitingListDto> List { get; set; }
    }

    public static partial class WaitingListExtensions
    {
        public static string GetKey(this WaitingListDto dto)
        {
            return $"{dto.Id}";
        }
    }
}