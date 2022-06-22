namespace OutResp.Interfaces;

public interface IFailureSimpleContract : IOutResp
{
    IFailureSimpleContract AddMessage(string message);

    IFailureSimpleContract AddMessages(IEnumerable<string> messages);
}