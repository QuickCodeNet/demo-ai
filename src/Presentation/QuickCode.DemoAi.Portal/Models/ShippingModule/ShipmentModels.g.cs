using QuickCode.DemoAi.Common.Nswag.Clients.ShippingModuleApi.Contracts;
using System;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Collections.Generic;
using System.Linq;
using QuickCode.DemoAi.Portal.Helpers;

namespace QuickCode.DemoAi.Portal.Models.ShippingModule
{
    public class ShipmentData : BaseComboBoxModel
    {
        public int TotalPage { get; set; }
        public int CurrentPage { get; set; }
        public int PageSize { get; set; }
        public int NumberOfRecord { get; set; }
        public string SelectedKey { get; set; }
        public ShipmentDto SelectedItem { get; set; }
        public List<ShipmentDto> List { get; set; }
    }

    public static partial class ShipmentExtensions
    {
        public static string GetKey(this ShipmentDto dto)
        {
            return $"{dto.Id}";
        }
    }
}