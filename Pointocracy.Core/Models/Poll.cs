namespace Pointocracy.Core.Models;

public record struct PollId(Guid Guid);
public record struct PollName(string String);
public record struct PollDescription(string? String);

public class Poll(
    PollId id,
    PollName name,
    PollDescription description,
    PollState state,
    VoteRules voteRules,
    IEnumerable<Option> options,
    PollResult? result = null);
