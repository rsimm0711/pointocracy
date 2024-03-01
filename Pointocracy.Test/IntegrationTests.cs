using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Pointocracy.Core.Actions;
using Pointocracy.Infra;
using Pointocracy.Infra.DataCommands;
using Pointocracy.Server.Controllers;

namespace Pointocracy.Test;

public sealed class IntegrationTests
{
    private CreatePollController testObj = null!;
    private PointocracyDb database = null!;

    [SetUp]
    public void SetUp()
    {
        var options = new DbContextOptionsBuilder<PointocracyDb>()
            .UseInMemoryDatabase("Pointocracy Test")
            .Options;
        database = new PointocracyDb(options);
        database.Database.EnsureCreated();

        var addPollCommand = new AddPollCommand(database);
        var createPoll = new CreatePoll(addPollCommand);
        var saveContext = new SaveContext(database);

        testObj = new CreatePollController(createPoll, saveContext);
    }

    [TearDown]
    public void TearDown()
    {
        database.Database.EnsureDeleted();
        database.Dispose();
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
            Assert.That(database.Polls.First().Id, Is.Not.EqualTo(Guid.Empty));
        });
    }
}