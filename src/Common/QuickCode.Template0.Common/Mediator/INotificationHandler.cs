using System.Threading;
using System.Threading.Tasks;

namespace QuickCode.Template0.Common.Mediator
{
    public interface INotificationHandler<TNotification>
        where TNotification : INotification
    {
        Task Handle(TNotification notification, CancellationToken cancellationToken);
    }
} 