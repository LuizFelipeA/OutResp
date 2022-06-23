using System.Net;
using Microsoft.AspNetCore.Mvc;

namespace OutResp.Interfaces;

public interface ISuccessContract<T> : IOutResp<T>
{
    ISuccessContract<T> AddNotification(string notification);

    ISuccessContract<T> AddNotifications(IEnumerable<string> notifications);

    ISuccessContract<T> AddMessage(string message);

    ISuccessContract<T> AddMessages(IEnumerable<string> messages);

    ISuccessContract<T> AddStatusCode(HttpStatusCode statusCode);

    ISuccessContract<T> AddValue(T value);

    IActionResult ToActionResult();
}
