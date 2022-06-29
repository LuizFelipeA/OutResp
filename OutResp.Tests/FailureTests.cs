using Microsoft.AspNetCore.Mvc;
using OutResponse;

namespace OutResp.Tests;

[TestClass]
public class FailureTests
{
    [TestMethod]
    [TestCategory("OutRespFailureResponse")]
    public void FailureShouldReturnStatusCodeBadRequestByDefault()
    {
        Assert.Fail();
    }

    [TestMethod]
    [TestCategory("OutRespFailureResponse")]
    public void FailureShouldReturnStatusCodeSpecified()
    {
        Assert.Fail();
    }
    
    [TestMethod]
    [TestCategory("OutRespFailureResponse")]
    public void FailureShouldReturnSuccessEqualsToFalseByDefault()
    {
        Assert.Fail();
    }

    [TestMethod]
    [TestCategory("OutRespFailureResponse")]
    public void FailureShouldReturnMessageEmptyListIfNotSpecified()
    {
        var outResp = OutRespContract.Failure<object>();

        Assert.Equals(0, outResp.Messages.Count);
    }

    [TestMethod]
    [TestCategory("OutRespFailureResponse")]
    public void FailureShouldReturnMessageSpecified()
    {
        Assert.Fail();
    }

    [TestMethod]
    [TestCategory("OutRespFailureResponse")]
    public void FailureShouldReturnNotificationsEmptyListIfNotSpecified()
    {
        Assert.Fail();
    }

    [TestMethod]
    [TestCategory("OutRespFailureResponse")]
    public void FailureShouldReturnNotificationsSpecified()
    {
        Assert.Fail();
    }

    [TestMethod]
    [TestCategory("OutRespFailureResponse")]
    public void FailureShouldReturnValueNullIfNotSpecified()
    {
        Assert.Fail();
    }

    [TestMethod]
    [TestCategory("OutRespFailureResponse")]
    public void FailureShouldReturnValueSpecified()
    {
        Assert.Fail();
    }

    [TestMethod]
    [TestCategory("OutRespFailureResponse")]
    public void FailureShouldReturnIActionResultWhenUseToActionResult()
    {
        var outResp = OutRespContract
            .Failure<object>().ToActionResult();

        Assert.IsTrue(outResp is IActionResult);
    }

    [TestMethod]
    [TestCategory("OutRespSimpleFailureResponse")]
    public void SimpleFailureShouldReturnNoMessageIfAnyMessageBeSpecified()
    {
        Assert.Fail();
    }
    
    [TestMethod]
    [TestCategory("OutRespSimpleFailureResponse")]
    public void SimpleFailureShouldReturnMessageSpecified()
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
    public void SimpleFailureShouldReturnIsSuccessAsFalseByDefault()
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
}
