using System.Net;
using Microsoft.AspNetCore.Mvc;
using OutResponse.Enums;

namespace OutResp.Interfaces;

public interface ISuccessContract<T> : IOutResp<T>
{
    ISuccessContract<T> AddNotification(in string notification,
        ENotificationType notificationType);

    ISuccessContract<T> AddNotifications(
        IEnumerable<string> notifications,
        ENotificationType notificationType);

    ISuccessContract<T> AddMessage(in string message);

    ISuccessContract<T> AddMessages(IEnumerable<string> messages);

    ISuccessContract<T> AddStatusCode(HttpStatusCode statusCode);

    ISuccessContract<T> AddValue(T value);

    IActionResult ToActionResult();
}
