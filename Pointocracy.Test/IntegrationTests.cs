using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Pointocracy.Core.Actions;
using Pointocracy.Infra;
using Pointocracy.Server.Controllers;

namespace Pointocracy.Test;

public sealed class IntegrationTests
{
    private CreatePollController testObj = null!;
    private AddPollCommand addPollCommand = null!;
    private PointocracyDb db = null!;

    [SetUp]
    public void SetUp()
    {
        var options = new DbContextOptionsBuilder<PointocracyDb>()
            .UseInMemoryDatabase("Pointocracy Test")
            .Options;
        db = new PointocracyDb(options);
        db.Database.EnsureCreated();

        addPollCommand = new AddPollCommand(db);
        var poll = new CreatePoll(addPollCommand);
        testObj = new CreatePollController(poll);
    }

    [TearDown]
    public void TearDown()
    {
        testObj.Dispose();
        db.Database.EnsureDeleted();
        db.Dispose();
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

        Assert.Multiple(() =>
        {
            Assert.That(result, Is.TypeOf<OkResult>());
            Assert.That(db.Polls.First().Id, Is.Not.EqualTo(Guid.Empty));
        });
    }
}