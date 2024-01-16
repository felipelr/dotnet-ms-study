using MediatR;

namespace Common.Core.Events
{
    public interface IEvent : INotification
    {
        Guid Id { get; }
        DateTime CreationDate { get; }
        IDictionary<string, object> MetaData { get; }
    }
}
