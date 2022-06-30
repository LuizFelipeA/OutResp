using Microsoft.AspNetCore.Mvc;

namespace OutResp.Interfaces;

public interface IFailureSimpleContract : IOutResp
{
    IFailureSimpleContract AddMessage(in string message);

    IFailureSimpleContract AddMessages(IEnumerable<string> messages);

    IActionResult ToActionResult();
}