namespace Pointocracy.Core.Models;

public class Poll(
    Guid id,
    string name,
    string? description,
    PollState state,
    VoteRules voteRules,
    IEnumerable<Option> options,
    PollResult? result = null);
