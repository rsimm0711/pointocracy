using Microsoft.AspNetCore.Mvc;
using Pointocracy.Core.Actions;
using Pointocracy.Server.Controllers;

namespace Pointocracy.Test;

public sealed class IntegrationTests
{
    private CreatePollController testObj = null!;

    [SetUp]
    public void SetUp()
    {
        var poll = new CreatePoll();
        testObj = new CreatePollController(poll);
    }

    [TearDown]
    public void TearDown()
    {
        testObj.Dispose();
    }

    [Test]
    public void CreateNewPoll()
    {
        var request = new CreatePollRequest
        {
            Name = "test poll",
            Description = "this is a test"
        };

        var result = testObj.CreatePoll(request);

        Assert.That(result, Is.TypeOf<OkResult>());
    }
}