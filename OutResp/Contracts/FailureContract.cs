using System.Net;
using Microsoft.AspNetCore.Mvc;
using OutResp.Interfaces;
using OutResp.Models;
using OutResponse.Enums;

namespace OutResp.Contracts;

public class FailureContract<T> :
    OutRespResult<T>,
    IFailureContract<T>
{
    internal FailureContract()
    {
        IsValid = true;
        IsSuccess = false;
        StatusCode = HttpStatusCode.BadRequest;
    }

    public IFailureContract<T> AddNotification(
        in string notification,
        ENotificationType notificationType)
    {
        if (string.IsNullOrEmpty(notification))
            return this;

        switch (notificationType)
        {
            case ENotificationType.Error:
                Notifications.Add($"ERROR: {notification}");
                IsValid = false;
                return this;
            
            case ENotificationType.Warning:
                Notifications.Add($"WARNING: {notification}");
                return this;
            
            default:
                return this;
        }
    }

    public IFailureContract<T> AddNotifications(
        IEnumerable<string> notifications,
        ENotificationType notificationType)
    {
        if (notifications is null)
            return this;

        if (notificationType == ENotificationType.Error)
            IsValid = false;
        
        Notifications.AddRange(notifications);
        
        return this;
    }

    public IFailureContract<T> AddMessage(in string message)
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
