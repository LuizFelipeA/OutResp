using System.Net;
using Microsoft.AspNetCore.Mvc;
using OutResp.Interfaces;

namespace OutResp.Models;

public class OutRespSimpleResult :
    ControllerBase,
    IOutResp
{
    internal OutRespSimpleResult()
    {
        Notifications = new List<string>();
        Messages = new List<string>();
    }

    public List<string> Notifications { get; protected set; }
    
    public bool IsValid { get; protected set; }

    public List<string> Messages { get; protected set; }

    public HttpStatusCode StatusCode { get; protected set; }

    public bool IsSuccess { get; protected set; }
}