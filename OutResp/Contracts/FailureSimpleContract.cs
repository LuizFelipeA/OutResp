using System.Net;
using Microsoft.AspNetCore.Mvc;
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
        IsValid = true;
        StatusCode = HttpStatusCode.BadRequest;
    }

    public IFailureSimpleContract AddMessage(in string message)
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

    public IActionResult ToActionResult()
        => StatusCode(
            (int)StatusCode,
            new
            {
                Success = IsSuccess,
                StatusCode = StatusCode,
                Messages = Messages
            });
}