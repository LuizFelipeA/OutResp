using Microsoft.AspNetCore.Mvc;

namespace OutResp.Interfaces;

public interface IFailureSimpleContract : IOutResp
{
    /// <summary>
    /// Add a single message to the response
    /// </summary>
    /// <param name="message"></param>
    /// <returns></returns>
    IFailureSimpleContract AddMessage(in string message);
    
    /// <summary>
    /// Add an array of messages to the response
    /// </summary>
    /// <param name="messages"></param>
    /// <returns></returns>
    IFailureSimpleContract AddMessages(IEnumerable<string> messages);
    
    /// <summary>
    /// Convert the response to IActionResult.
    /// </summary>
    /// <returns></returns>
    IActionResult ToActionResult();
}