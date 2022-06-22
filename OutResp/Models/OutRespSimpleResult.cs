using System.Net;
using OutResp.Interfaces;

namespace OutResp.Models;

public class OutRespSimpleResult : IOutResp
{
    public List<string> Notifications { get; protected set; }

    public List<string> Messages { get; protected set; }

    public HttpStatusCode StatusCode { get; protected set; }

    public bool IsSuccess { get; protected set; }
}