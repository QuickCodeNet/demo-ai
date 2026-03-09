using System;
using System.ComponentModel.DataAnnotations.Schema;
using QuickCode.DemoAi.Common;

namespace QuickCode.DemoAi.CustomerManagementModule.Domain;

public class BaseSoftDeletable : ISoftDeletable
{
    [Column("IsDeleted")]
    public bool IsDeleted { get; set; }
    
    [Column("DeletedOnUtc")]
    public DateTime? DeletedOnUtc { get; set; }
}