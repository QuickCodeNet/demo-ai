using System.Threading;
using System.Threading.Tasks;

namespace QuickCode.Template0.Common.Mediator
{
    public interface IRequestHandler<TRequest, TResponse>
        where TRequest : IRequest<TResponse>
    {
        Task<TResponse> Handle(TRequest request, CancellationToken cancellationToken);
    }
} 