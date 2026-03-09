using System.ComponentModel.DataAnnotations.Schema;

namespace QuickCode.DemoAi.Common;

public interface ISoftDeletable
{
    bool IsDeleted { get; set; }
    DateTime? DeletedOnUtc { get; set; }
}