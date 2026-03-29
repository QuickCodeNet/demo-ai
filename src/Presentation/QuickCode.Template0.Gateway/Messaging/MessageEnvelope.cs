namespace QuickCode.Template0.Gateway.Messaging;

public record MessageEnvelope<T>(T Message, string CorrelationId) where T : IMessage;
