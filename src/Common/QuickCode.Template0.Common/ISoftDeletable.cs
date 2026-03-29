using System.ComponentModel.DataAnnotations.Schema;

namespace QuickCode.TemplateCommon.Common;

public interface ISoftDeletable
{
    bool IsDeleted { get; set; }
    DateTime? DeletedOnUtc { get; set; }
}