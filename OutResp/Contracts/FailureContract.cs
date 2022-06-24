using System.Net;
using Microsoft.AspNetCore.Mvc;
using OutResp.Interfaces;
using OutResp.Models;

namespace OutResp.Contracts;

public class FailureContract<T> :
    OutRespResult<T>,
    IFailureContract<T>
{
    internal FailureContract() { IsSuccess = false; StatusCode = HttpStatusCode.BadRequest; }

    public IFailureContract<T> AddNotification(string notification)
    {
        if (string.IsNullOrEmpty(notification))
            return this;
        
        Notifications.Add(notification);
        return this;
    }

    public IFailureContract<T> AddNotifications(IEnumerable<string> notifications)
    {
        if (notifications is null)
            return this;
        
        Notifications.AddRange(notifications);
        return this;
    }

    public IFailureContract<T> AddMessage(string message)
    {
        if (string.IsNullOrEmpty(message))
            return this;
        
        Messages.Add(message);
        return this;
    }

    public IFailureContract<T> AddMessages(IEnumerable<string> messages)
    {
        if (messages is null)
            return this;
        
        Messages.AddRange(messages);
        return this;
    }

    public IFailureContract<T> AddStatusCode(HttpStatusCode statusCode)
    {
        StatusCode = statusCode;
        return this;
    }

    public IFailureContract<T> AddValue(T value)
    {
        if (value is null)
            return this;

        Value = value;
        return this;
    }

    public IActionResult ToActionResult()
        => StatusCode(
            (int)StatusCode,
            new
            {
                Success = IsSuccess,
                StatusCode = StatusCode,
                Messages = Messages
            });
}
