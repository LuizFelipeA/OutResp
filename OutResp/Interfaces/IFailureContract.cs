using System.Net;

namespace OutResp.Interfaces;

public interface IFailureContract<T> : IOutResp<T>
{
    IFailureContract<T> AddNotification(string notification);

    IFailureContract<T> AddNotifications(IEnumerable<string> notifications);
    
    IFailureContract<T> AddMessage(string message);

    IFailureContract<T> AddMessages(IEnumerable<string> messages);

    IFailureContract<T> AddStatusCode(HttpStatusCode statusCode);

    IFailureContract<T> AddValue(T value);

}