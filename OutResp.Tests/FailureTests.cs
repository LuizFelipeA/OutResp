using System.Net;
using Microsoft.AspNetCore.Mvc;
using OutResponse;
using OutResponse.Enums;

namespace OutResp.Tests;

[TestClass]
public class FailureTests
{
    private readonly List<string> _listMessages = new();

    private readonly List<string> _listNotifications = new();
    
    internal FailureTests()
    {
        _listMessages.Add("message number one.");
        _listMessages.Add("message number two.");
        
        _listNotifications.Add("notification number one.");
        _listNotifications.Add("notification number two.");
    }

    [TestMethod]
    [TestCategory("OutRespFailureResponse")]
    public void FailureShouldReturnStatusCodeBadRequestByDefault()
    {
        var outResp = OutRespContract.Failure<object>();

        Assert.AreEqual(HttpStatusCode.BadRequest, outResp.StatusCode);
    }

    [TestMethod]
    [TestCategory("OutRespFailureResponse")]
    public void FailureShouldReturnStatusCodeSpecified()
    {
        var outResp = OutRespContract
            .Failure<object>()
            .AddStatusCode(HttpStatusCode.NotFound);
        
        Assert.AreEqual(HttpStatusCode.NotFound, outResp.StatusCode);
    }
    
    [TestMethod]
    [TestCategory("OutRespFailureResponse")]
    public void FailureShouldReturnSuccessEqualsToFalseByDefault()
    {
        var outResp = OutRespContract.Failure<object>();
        
        Assert.IsFalse(outResp.IsSuccess);
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
        var outResp = OutRespContract
            .Failure<object>()
            .AddMessages(_listMessages);

        var areEquals = outResp.Messages
            .OrderBy(x => x)
            .SequenceEqual(_listMessages.OrderBy(x => x));
            
        Assert.IsNotNull(outResp.Messages);
        Assert.IsTrue(areEquals);
    }

    [TestMethod]
    [TestCategory("OutRespFailureResponse")]
    public void FailureShouldReturnNotificationsEmptyListIfNotSpecified()
    {
        var outResp = OutRespContract.Failure<object>();
        
        Assert.AreEqual(0, outResp.Notifications.Count);
    }

    [TestMethod]
    [TestCategory("OutRespFailureResponse")]
    public void FailureShouldReturnIsValidTrueByDefault()
    {
        var outResp = OutRespContract.Failure<object>();
        
        Assert.IsTrue(outResp.IsValid);
    }

    [TestMethod]
    [TestCategory("OutRespFailureResponse")]
    public void FailureShouldReturnIsValidTrueWhenNotificationTypeIsEqualsToWarning()
    {
        var outResp = OutRespContract
            .Failure<object>()
            .AddNotification("notification message", ENotificationType.Warning);
        
        Assert.IsTrue(outResp.IsValid);
    }

    [TestMethod]
    [TestCategory("OutRespFailureResponse")]
    public void FailureShouldReturnIsValidFalseWhenNotificationTypeIsEqualsToError()
    {
        var outResp = OutRespContract
            .Failure<object>()
            .AddNotification("notification message", ENotificationType.Error);
        
        Assert.IsFalse(outResp.IsValid);
    }

    [TestMethod]
    [TestCategory("OutRespFailureResponse")]
    public void FailureShouldReturnNotificationsSpecified()
    {
        var outResp = OutRespContract
            .Failure<object>()
            .AddNotifications(_listNotifications, ENotificationType.Warning);

        var areEquals = outResp.Notifications
            .OrderBy(x => x)
            .SequenceEqual(_listNotifications.OrderBy(x => x));
        
        Assert.IsNotNull(outResp.Notifications);
        Assert.IsTrue(areEquals);
    }

    [TestMethod]
    [TestCategory("OutRespFailureResponse")]
    public void FailureShouldReturnValueNullIfNotSpecified()
    {
        var outResp = OutRespContract.Failure<object>();
        
        Assert.IsNull(outResp.Value);
    }

    [TestMethod]
    [TestCategory("OutRespFailureResponse")]
    public void FailureShouldReturnValueSpecified()
    {
        var outResp = OutRespContract
            .Failure<string>()
            .AddValue("string");
        
        Assert.AreEqual("string", outResp.Value);
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
        var outResp = OutRespContract.Failure();
        
        Assert.AreEqual(0, outResp.Messages);
    }
    
    [TestMethod]
    [TestCategory("OutRespSimpleFailureResponse")]
    public void SimpleFailureShouldReturnMessageSpecified()
    {
        var simpleOutResp = OutRespContract
            .Failure()
            .AddMessages(_listMessages);

        var areEquals = simpleOutResp.Messages
            .OrderBy(x => x)
            .SequenceEqual(_listMessages.OrderBy(x => x));
        
        Assert.IsNotNull(simpleOutResp.Messages);
        Assert.IsTrue(areEquals);
    }
    
    [TestMethod]
    [TestCategory("OutRespSimpleFailureResponse")]
    public void SimpleFailureShouldReturnStatusCodeBadRequestByDefault()
    {
        var simpleOutResp = OutRespContract.Failure();
        
        Assert.AreEqual(HttpStatusCode.BadRequest, simpleOutResp.StatusCode);
    }

    [TestMethod]
    [TestCategory("OutRespSimpleFailureResponse")]
    public void SimpleFailureShouldReturnIsSuccessAsFalseByDefault()
    {
        var simpleOutResp = OutRespContract.Failure();
        
        Assert.IsFalse(simpleOutResp.IsSuccess);
    }

    [TestMethod]
    [TestCategory("OutRespSimpleFailureResponse")]
    public void SimpleFailureShouldReturnAsIActionResult()
    {
        var simpleOutResp = OutRespContract
            .Failure().ToActionResult();

        Assert.IsTrue(simpleOutResp is IActionResult);
    }

    [TestMethod]
    [TestCategory("OutRespSimpleFailureResponse")]
    public void SimpleFailureShouldReturnIsValidTrueByDefault()
    {
        var outResp = OutRespContract.Failure();
        
        Assert.IsTrue(outResp.IsValid);
    }
}
