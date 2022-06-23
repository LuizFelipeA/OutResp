using System.Net;
using Microsoft.AspNetCore.Mvc;
using OutResp.Interfaces;

namespace OutResp.Models;

public class OutRespResult<T> : 
    ControllerBase,
    IOutResp<T>
{
    internal OutRespResult()
    {
        Notifications = new List<string>();
        Messages = new List<string>();
    }

    public List<string> Notifications { get; }

    public List<string> Messages { get; }

    public HttpStatusCode StatusCode { get; protected set; }

    public bool IsSuccess { get; protected set; }

    public T Value { get; protected set; }
}