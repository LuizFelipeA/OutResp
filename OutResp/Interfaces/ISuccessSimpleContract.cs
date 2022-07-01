using Microsoft.AspNetCore.Mvc;

namespace OutResp.Interfaces;

public interface ISuccessSimpleContract : IOutResp
{
    /// <summary>
    /// Add a single message to the response
    /// </summary>
    /// <param name="message"></param>
    /// <returns></returns>
    ISuccessSimpleContract AddMessage(string message);
    
    /// <summary>
    /// Add an array of messages to the response
    /// </summary>
    /// <param name="messages"></param>
    /// <returns></returns>
    ISuccessSimpleContract AddMessages(IEnumerable<string> messages);
    
    /// <summary>
    /// Convert the response to IActionResult.
    /// </summary>
    /// <returns></returns>
    IActionResult ToActionResult();
}