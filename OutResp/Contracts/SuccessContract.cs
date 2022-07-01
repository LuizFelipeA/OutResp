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

    /// <summary>
    /// Add a single notification to the response.
    /// The notification must contain a NotificationType to represent the notification type.
    /// </summary>
    /// <param name="notification"></param>
    /// <param name="notificationType"></param>
    /// <returns></returns>
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
    
    /// <summary>
    /// Add an array of notifications to the response.
    /// The notification must contain a NotificationType to represent the notification type.
    /// </summary>
    /// <param name="notifications"></param>
    /// <param name="notificationType"></param>
    /// <returns></returns>
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
    
    /// <summary>
    /// Add a single message to the response
    /// </summary>
    /// <param name="message"></param>
    /// <returns></returns>
    public ISuccessContract<T> AddMessage(in string message)
    {
        if(string.IsNullOrEmpty(message))
            return this;

        Messages.Add(message);
        return this;
    }
    
    /// <summary>
    /// Add an array of messages to the response
    /// </summary>
    /// <param name="messages"></param>
    /// <returns></returns>
    public ISuccessContract<T> AddMessages(IEnumerable<string> messages)
    {
        if(messages is null)
            return this;

        Messages.AddRange(messages);
        return this;
    }
    
    /// <summary>
    /// Add status code to the response.
    /// The status code must be from HttpStatusCode enum.
    /// </summary>
    /// <param name="statusCode"></param>
    /// <returns></returns>
    public ISuccessContract<T> AddStatusCode(HttpStatusCode statusCode)
    {
        StatusCode = statusCode;
        return this;
    }
    
    /// <summary>
    /// Add a data value to the response
    /// </summary>
    /// <param name="value"></param>
    /// <returns></returns>
    public ISuccessContract<T> AddValue(T value)
    {
        Value = value;
        return this;
    }
    
    /// <summary>
    /// Convert the response to IActionResult.
    /// </summary>
    /// <returns></returns>
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
