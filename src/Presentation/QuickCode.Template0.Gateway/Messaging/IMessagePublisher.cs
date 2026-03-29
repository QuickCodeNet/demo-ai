namespace QuickCode.Template0.Gateway.Messaging;

public interface IMessagePublisher
{
    Task PublishAsync<T>(string topic, T message) where T : class, IMessage;
}