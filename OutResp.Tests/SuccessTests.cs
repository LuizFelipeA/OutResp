using System.Net;

namespace OutResp.Tests;

[TestClass]
public class SuccessTests
{
    [TestMethod]
    [TestCategory("OutRespSuccess")]
    public void SuccessShouldReturn200StatusCodeByDefault()
    {
        var outResp = OutResp.Success<object>();
        
        Assert.AreEqual(HttpStatusCode.OK, outResp.StatusCode);
    }

    [TestMethod]
    [TestCategory("OutRespSuccess")]
    public void SuccessShouldReturnStatusCodeSpecified()
    {
        var outResp = OutResp
            .Success<object>()
            .AddStatusCode(HttpStatusCode.Created);
        
        Assert.AreEqual(HttpStatusCode.Created, outResp.StatusCode);
    }

    [TestMethod]
    [TestCategory("OutRespSuccess")]
    public void SuccessShouldReturnIsSuccessEqualsTrueByDefault()
    {
        var outResp = OutResp.Success<object>();
        
        Assert.IsTrue(outResp.IsSuccess);
    }

    [TestMethod]
    [TestCategory("OutRespSuccess")]
    public void SuccessShouldReturnMessagesEmptyListIfNotSpecified()
    {
        var outResp = OutResp.Success<object>();

        Assert.AreEqual(0, outResp.Messages.Count);
    }

    [TestMethod]
    [TestCategory("OutRespSuccess")]
    public void SuccessShouldReturnMessagesSpecified()
    {
        var messages = new[] { "message number one", "message number two" };

        var outResp = OutResp
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
    public void SuccessShouldReturnNotificationsEmptyListIfNotSpecified()
    {
        var outResp = OutResp.Success<object>();
        
        Assert.AreEqual(0, outResp.Notifications.Count);
    }

    [TestMethod]
    [TestCategory("OutRespSuccess")]
    public void SuccessShouldReturnNotificationsSpecified()
    {
        var notifications = new[] { "notification number one", "notification number two" };

        var outResp = OutResp
            .Success<object>()
            .AddNotifications(notifications);

        var areEquals = outResp.Notifications
            .OrderBy(x => x)
            .SequenceEqual(notifications.OrderBy(x => x));
        
        Assert.IsNotNull(outResp.Messages);
        Assert.IsTrue(areEquals);
    }

    [TestMethod]
    [TestCategory("OutRespSuccess")]
    public void SuccessShouldReturnValueNullIfNotSpecified()
    {
        var outResp = OutResp.Success<object>();
        
        Assert.IsNull(outResp.Value);
    }

    [TestMethod]
    [TestCategory("OutRespSuccess")]
    public void SuccessShouldReturnValueSpecified()
    {
        var outResp = OutResp
            .Success<string>()
            .AddValue("1q2w3e$##");
        
        Assert.AreEqual("1q2w3e$##", outResp.Value);
    }
}