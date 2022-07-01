using System.Net;
using Microsoft.AspNetCore.Mvc;
using OutResponse.Enums;

namespace OutResp.Interfaces;

public interface IFailureContract<T> : IOutResp<T>
{
    /// <summary>
    /// Add a single notification to the response.
    /// The notification must contain a NotificationType to represent the notification type.
    /// </summary>
    /// <param name="notification"></param>
    /// <param name="notificationType"></param>
    /// <returns></returns>
    IFailureContract<T> AddNotification(in string notification, ENotificationType notificationType);
    
    /// <summary>
    /// Add an array of notifications to the response.
    /// The notification must contain a NotificationType to represent the notification type.
    /// </summary>
    /// <param name="notifications"></param>
    /// <param name="notificationType"></param>
    /// <returns></returns>
    IFailureContract<T> AddNotifications(
        IEnumerable<string> notifications,
        ENotificationType notificationType);
    
    /// <summary>
    /// Add a single message to the response
    /// </summary>
    /// <param name="message"></param>
    /// <returns></returns>
    IFailureContract<T> AddMessage(in string message);
    
    /// <summary>
    /// Add an array of messages to the response
    /// </summary>
    /// <param name="messages"></param>
    /// <returns></returns>
    IFailureContract<T> AddMessages(IEnumerable<string> messages);
    
    /// <summary>
    /// Add status code to the response.
    /// The status code must be from HttpStatusCode enum.
    /// </summary>
    /// <param name="statusCode"></param>
    /// <returns></returns>
    IFailureContract<T> AddStatusCode(HttpStatusCode statusCode);
    
    /// <summary>
    /// Add a data value to the response
    /// </summary>
    /// <param name="value"></param>
    /// <returns></returns>
    IFailureContract<T> AddValue(T value);
    
    /// <summary>
    /// Convert the response to IActionResult.
    /// </summary>
    /// <returns></returns>
    IActionResult ToActionResult();
}