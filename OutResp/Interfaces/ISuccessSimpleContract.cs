using Microsoft.AspNetCore.Mvc;

namespace OutResp.Interfaces;

public interface ISuccessSimpleContract : IOutResp
{
    ISuccessSimpleContract AddMessage(string message);

    ISuccessSimpleContract AddMessages(IEnumerable<string> messages);

    IActionResult ToActionResult();
}