using System;
using System.ComponentModel.DataAnnotations.Schema;
using QuickCode.TemplateCommon.Common;

namespace QuickCode.Template0.Domain;

public class BaseSoftDeletable : ISoftDeletable
{
    [Column("IsDeleted")]
    public bool IsDeleted { get; set; }
    
    [Column("DeletedOnUtc")]
    public DateTime? DeletedOnUtc { get; set; }
}