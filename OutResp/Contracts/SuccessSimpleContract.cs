using System.Net;
using Microsoft.AspNetCore.Mvc;
using OutResp.Interfaces;
using OutResp.Models;

namespace OutResp.Contracts;

public class SuccessSimpleContract : 
    OutRespSimpleResult,
    ISuccessSimpleContract
{
    public SuccessSimpleContract()
    {
        StatusCode = HttpStatusCode.OK;
        IsSuccess = true;
    }

    public ISuccessSimpleContract AddMessage(string message)
    {
        if (string.IsNullOrEmpty(message))
            return this;
        
        Messages.Add(message);
        return this;
    }

    public ISuccessSimpleContract AddMessages(IEnumerable<string> messages)
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
                StatusCode,
                Messages
            });
}