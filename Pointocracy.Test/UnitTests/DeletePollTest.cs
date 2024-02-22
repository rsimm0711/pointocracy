using NSubstitute;
using Pointocracy.Core.Actions;
using Pointocracy.Core.DataCommands;
using Pointocracy.Core.Models;

namespace Pointocracy.Test.UnitTests;

public sealed class DeletePollTest
{
    private DeletePoll testObj = null!;
    private IDeletePollCommand deleteCommand = null!;

    [SetUp]
    public void SetUp()
    {
        deleteCommand = Substitute.For<IDeletePollCommand>();
        testObj = new DeletePoll(deleteCommand);
    }

    [Test]
    public void DeleteExistingPoll()
    {
        var pollId = new PollId(Guid.NewGuid());

        var result = testObj.Delete(pollId);

        Assert.That(result.IsSuccess);
        deleteCommand.Received(1).Delete(pollId);
    }
}