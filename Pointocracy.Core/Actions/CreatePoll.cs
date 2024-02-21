using Pointocracy.Core.Models;

namespace Pointocracy.Core.Actions;

public interface ICreatePoll
{
    Poll Create(string name, string description, VoteRules voteRules);
}

internal sealed class CreatePoll(IAddPollCommand addPollCommand) : ICreatePoll
{
    public Poll Create(string name, string description, VoteRules voteRules)
    {
        var pollId = new PollId(Guid.NewGuid());
        var pollName = new PollName(name);
        var pollDescription = new PollDescription(description);

        var poll = new Poll(pollId, pollName, pollDescription, PollState.Draft, voteRules, []);
        addPollCommand.Add(poll);
        return poll;
    }
}