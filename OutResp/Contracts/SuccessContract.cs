using System.Net;
using Microsoft.AspNetCore.Mvc;
using OutResp.Interfaces;
using OutResp.Models;
using OutResponse.Enums;

namespace OutResp.Contracts;

public class SuccessContract<T> : 
    OutRespResult<T>,
    ISuccessContract<T>
{
    internal SuccessContract()
    {
        IsValid = true;
        IsSuccess = true;
        StatusCode = HttpStatusCode.OK;
    }

    public ISuccessContract<T> AddNotification(
        in string notification,
        ENotificationType notificationType)
    {
        if(string.IsNullOrEmpty(notification))
            return this;
        
        if(notificationType == ENotificationType.Warning)
            Notifications.Add($"WARNING: {notification}");

        return this;
    }

    public ISuccessContract<T> AddNotifications(
        IEnumerable<string> notifications,
        ENotificationType notificationType)
    {
        if(notifications is null)
            return this;
        
        if (notificationType == ENotificationType.Error)
            IsValid = false;
        
        Notifications.AddRange(notifications);
        
        return this;
    }

    public ISuccessContract<T> AddMessage(in string message)
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

    public IActionResult ToActionResult()
        => StatusCode(
            (int)StatusCode, 
            new
            {
                Success = IsSuccess,
                Messages,
                StatusCode,
                Data = Value
            });
}
