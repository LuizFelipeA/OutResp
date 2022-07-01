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
        IsValid = true;
        IsSuccess = true;
        StatusCode = HttpStatusCode.OK;
    }
    
    /// <summary>
    /// Add a single message to the response
    /// </summary>
    /// <param name="message"></param>
    /// <returns></returns>
    public ISuccessSimpleContract AddMessage(string message)
    {
        if (string.IsNullOrEmpty(message))
            return this;
        
        Messages.Add(message);
        return this;
    }
    
    /// <summary>
    /// Add an array of messages to the response
    /// </summary>
    /// <param name="messages"></param>
    /// <returns></returns>
    public ISuccessSimpleContract AddMessages(IEnumerable<string> messages)
    {
        if (messages is null)
            return this;
        
        Messages.AddRange(messages);
        return this;
    }
    
    /// <summary>
    /// Convert the response to IActionResult.
    /// </summary>
    /// <returns></returns>
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