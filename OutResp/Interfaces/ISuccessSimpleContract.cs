using Microsoft.AspNetCore.Mvc;

namespace OutResp.Interfaces;

public interface ISuccessSimpleContract
{
    ISuccessSimpleContract AddMessage(string message);

    ISuccessSimpleContract AddMessages(IEnumerable<string> messages);

    IActionResult ToActionResult();
}