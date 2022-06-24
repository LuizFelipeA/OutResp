using Microsoft.AspNetCore.Mvc;
using OutResponse;

namespace OutResp.Tests;

[TestClass]
public class FailureTests
{
    [TestMethod]
    [TestCategory("OutRespSimpleFailureResponse")]
    public void SimpleFailureShouldReturnMessagesEmptyByDefault()
    {
        Assert.Fail();
    }

    [TestMethod]
    [TestCategory("OutRespSimpleFailureResponse")]
    public void SimpleFailureShouldReturnStatusCodeBadRequestByDefault()
    {
        Assert.Fail();
    }

    [TestMethod]
    [TestCategory("OutRespSimpleFailureResponse")]
    public void SimpleFailureShouldReturnSuccessFalse()
    {
        Assert.Fail();
    }

    [TestMethod]
    [TestCategory("OutRespSimpleFailureResponse")]
    public void SimpleFailureShouldReturnAsIActionResult()
    {
        var outResp = OutRespContract
            .Failure().ToActionResult();

        Assert.IsTrue(outResp is IActionResult);
    }

    [TestMethod]
    [TestCategory("OutRespFailureResponse")]
    public void FailureShouldReturnMessagesEmptyByDefault()
    {
        Assert.Fail();
    }

    [TestMethod]
    [TestCategory("OutRespFailureResponse")]
    public void FailureShouldReturnStatusCodeBadRequestByDefault()
    {
        Assert.Fail();
    }

    [TestMethod]
    [TestCategory("OutRespFailureResponse")]
    public void FailureShouldReturnSuccessFalse()
    {
        Assert.Fail();
    }

    [TestMethod]
    [TestCategory("OutRespFailureResponse")]
    public void FailureShouldReturnAsIActionResult()
    {
        var outResp = OutRespContract
            .Failure<object>().ToActionResult();

        Assert.IsTrue(outResp is IActionResult);
    }
}
