using System.Net;
using OutResp.Interfaces;
using OutResp.Models;

namespace OutResp.Contracts;

public class FailureSimpleContract :
    OutRespSimpleResult,
    IFailureSimpleContract
{
    public FailureSimpleContract()
    {
        IsSuccess = false;
        StatusCode = HttpStatusCode.BadRequest;
    }

    public IFailureSimpleContract AddMessage(string message)
    {
        if (string.IsNullOrEmpty(message))
            return this;
        
        Messages.Add(message);
        return this;
    }

    public IFailureSimpleContract AddMessages(IEnumerable<string> messages)
    {
        if (messages is null)
            return this;
        
        Messages.AddRange(messages);
        return this;
    }
}