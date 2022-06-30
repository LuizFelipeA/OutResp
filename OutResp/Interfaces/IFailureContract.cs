using System.Net;
using Microsoft.AspNetCore.Mvc;
using OutResponse.Enums;

namespace OutResp.Interfaces;

public interface IFailureContract<T> : IOutResp<T>
{
    IFailureContract<T> AddNotification(in string notification, ENotificationType notificationType);

    IFailureContract<T> AddNotifications(
        IEnumerable<string> notifications,
        ENotificationType notificationType);
    
    IFailureContract<T> AddMessage(in string message);

    IFailureContract<T> AddMessages(IEnumerable<string> messages);

    IFailureContract<T> AddStatusCode(HttpStatusCode statusCode);

    IFailureContract<T> AddValue(T value);

    IActionResult ToActionResult();
}