using System.Net;

namespace OutResp.Interfaces;

public interface IOutResp<T> : IOutResp
{
    public T Value { get; }
}

public interface IOutResp
{
    public List<string> Notifications { get; }

    public bool IsValid { get; }

    public List<string> Messages { get; }

    public HttpStatusCode StatusCode { get; }

    public bool IsSuccess { get; }
}
