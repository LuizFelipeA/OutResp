using System.Net;
using OutResp.Interfaces;
using OutResp.Models;

namespace OutResp.Contracts;

public class SuccessContract<T> : 
    OutRespResult<T>,
    ISuccessContract<T>
{
    internal SuccessContract() { IsSuccess = true; StatusCode = HttpStatusCode.OK; }

    public ISuccessContract<T> AddNotification(string notification)
    {
        if(string.IsNullOrEmpty(notification))
            return this;

        Notifications.Add(notification);
        return this;
    }

    public ISuccessContract<T> AddNotifications(IEnumerable<string> notifications)
    {
        if(notifications is null)
            return this;
        
        Notifications.AddRange(notifications);
        return this;
    }

    public ISuccessContract<T> AddMessage(string message)
    {
        if(string.IsNullOrEmpty(message))
            return this;

        Messages.Add(message);
        return this;
    }

    public ISuccessContract<T> AddMessages(IEnumerable<string> messages)
    {
        if(messages is null)
            return this;

        Messages.AddRange(messages);
        return this;
    }

    public ISuccessContract<T> AddStatusCode(HttpStatusCode statusCode)
    {
        StatusCode = statusCode;
        return this;
    }

    public ISuccessContract<T> AddValue(T value)
    {
        Value = value;
        return this;
    }
}
