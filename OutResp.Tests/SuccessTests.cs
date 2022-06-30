using System.Net;
using Microsoft.AspNetCore.Mvc;
using OutResponse;
using OutResponse.Enums;

namespace OutResp.Tests;

[TestClass]
public class SuccessTests
{
    private readonly List<string> _listMessages = new();

    private readonly List<string> _listNotifications = new();
    
    public SuccessTests()
    {
        _listMessages.Add("message number one.");
        _listMessages.Add("message number two.");
        
        _listNotifications.Add("notification number one.");
        _listNotifications.Add("notification number two.");
    }

    [TestMethod]
    [TestCategory("OutRespSuccess")]
    public void SuccessShouldReturnStatusCodeOkByDefault()
    {
        var outResp = OutRespContract.Success<object>();

        Assert.AreEqual(HttpStatusCode.OK, outResp.StatusCode);
    }

    [TestMethod]
    [TestCategory("OutRespSuccess")]
    public void SuccessShouldReturnStatusCodeSpecified()
    {
        var outResp = OutRespContract
            .Success<object>()
            .AddStatusCode(HttpStatusCode.Created);
        
        Assert.AreEqual(HttpStatusCode.Created, outResp.StatusCode);
    }

    [TestMethod]
    [TestCategory("OutRespSuccess")]
    public void SuccessShouldReturnIsSuccessEqualsTrueByDefault()
    {
        var outResp = OutRespContract.Success<object>();
        
        Assert.IsTrue(outResp.IsSuccess);
    }

    [TestMethod]
    [TestCategory("OutRespSuccess")]
    public void SuccessShouldReturnMessagesEmptyListIfNotSpecified()
    {
        var outResp = OutRespContract.Success<object>();

        Assert.AreEqual(0, outResp.Messages.Count);
    }

    [TestMethod]
    [TestCategory("OutRespSuccess")]
    public void SuccessShouldReturnMessagesSpecified()
    {
        var messages = new[] { "message number one", "message number two" };

        var outResp = OutRespContract
            .Success<object>()
            .AddMessages(messages);

        var areEquals = outResp.Messages
            .OrderBy(x => x)
            .SequenceEqual(messages.OrderBy(x => x));

        Assert.IsNotNull(outResp.Messages);
        Assert.IsTrue(areEquals);
    }
    
    [TestMethod]
    [TestCategory("OutRespSuccess")]
    public void SuccessShouldReturnIsValidTrueByDefault()
    {
        var outResp = OutRespContract.Success<object>();
        
        Assert.IsTrue(outResp.IsValid);
    }

    [TestMethod]
    [TestCategory("OutRespSuccess")]
    public void SuccessShouldReturnIsValidTrueWhenNotificationTypeIsEqualsToWarning()
    {
        var outResp = OutRespContract
            .Success<object>()
            .AddNotification("notification message", ENotificationType.Warning);
        
        Assert.IsTrue(outResp.IsValid);
    }

    [TestMethod]
    [TestCategory("OutRespSuccess")]
    public void SuccessShouldReturnIgnoreAndSetIsValidTrueWhenNotificationTypeIsEqualsToError()
    {
        var outResp = OutRespContract
            .Success<object>()
            .AddNotification("notification message", ENotificationType.Error);
        
        Assert.IsTrue(outResp.IsValid);
    }

    [TestMethod]
    [TestCategory("OutRespSuccess")]
    public void SuccessShouldReturnNotificationsEmptyListIfNotSpecified()
    {
        var outResp = OutRespContract.Success<object>();
        
        Assert.AreEqual(0, outResp.Notifications.Count);
    }

    [TestMethod]
    [TestCategory("OutRespSuccess")]
    public void SuccessShouldReturnNotificationsSpecified()
    {
        var notifications = new[] { "notification number one", "notification number two" };

        var outResp = OutRespContract
            .Success<object>()
            .AddNotifications(notifications, ENotificationType.Warning);

        var areEquals = outResp.Notifications
            .OrderBy(x => x)
            .SequenceEqual(notifications.OrderBy(x => x));
        
        Assert.IsNotNull(outResp.Notifications);
        Assert.IsTrue(areEquals);
    }

    [TestMethod]
    [TestCategory("OutRespSuccess")]
    public void SuccessShouldReturnValueNullIfNotSpecified()
    {
        var outResp = OutRespContract.Success<object>();
        
        Assert.IsNull(outResp.Value);
    }

    [TestMethod]
    [TestCategory("OutRespSuccess")]
    public void SuccessShouldReturnValueSpecified()
    {
        var outResp = OutRespContract
            .Success<string>()
            .AddValue("1q2w3e$##");
        
        Assert.AreEqual("1q2w3e$##", outResp.Value);
    }

    [TestMethod]
    [TestCategory("OutRespSuccess")]
    public void SuccessShouldReturnIActionResultWhenUseToActionResult()
    {
        var outResp = OutRespContract
            .Success<object>()
            .ToActionResult();

        Assert.IsTrue(outResp is IActionResult);
    }

    [TestMethod]
    [TestCategory("OutRespSimpleSuccess")]
    public void SimpleSuccessShouldReturnNoMessageIfAnyMessageBeSpecified()
    {
        var outResp = OutRespContract.Success();
        
        Assert.AreEqual(0, outResp.Messages.Count);
    }

    [TestMethod]
    [TestCategory("OutRespSimpleSuccess")]
    public void SimpleSuccessShouldReturnMessagesSpecified()
    {
        var messages = new[] { "message number one", "message number two" };

        var outResp = OutRespContract.Success().AddMessages(messages);
        
        var areEquals = outResp.Messages
            .OrderBy(x => x)
            .SequenceEqual(messages.OrderBy(x => x));

        Assert.IsNotNull(outResp.Messages);
        Assert.IsTrue(areEquals);
    }

    [TestMethod]
    [TestCategory("OutRespSimpleSuccess")]
    public void SimpleSuccessShouldReturnStatusCodeOkByDefault()
    {
        var outResp = OutRespContract.Success();
        
        Assert.AreEqual(HttpStatusCode.OK, outResp.StatusCode);
    }

    [TestMethod]
    [TestCategory("OutRespSimpleSuccess")]
    public void SimpleSuccessShouldReturnIsSuccessTrueByDefault()
    {
        var outResp = OutRespContract.Success();
        
        Assert.IsTrue(outResp.IsSuccess);
    }

    [TestMethod]
    [TestCategory("OutRespSimpleSuccess")]
    public void SimpleSuccessShouldReturnIActionResult()
    {
        var simpleOutResp = OutRespContract.Success().ToActionResult();
        
        Assert.IsTrue(simpleOutResp is IActionResult);
    }
    
    [TestMethod]
    [TestCategory("OutRespSimpleSuccess")]
    public void SimpleSuccessShouldReturnIsValidTrueByDefault()
    {
        var outResp = OutRespContract.Success();
        
        Assert.IsTrue(outResp.IsValid);
    }
}