using Pointocracy.Core.Models;

namespace Pointocracy.Infra.Models;

internal sealed class PollDao
{
    public required Guid Id { get; init; }
    public string Name { get; init; } = null!;
    public PollState State { get; init; }

    public static PollDao Create(Poll poll)
    {
        return new PollDao
        {
            Id = poll.Id.Guid,
            Name = poll.Name.String,
            State = poll.State,
        };
    }

    public static Poll ToPoll(PollDao dao)
    {
        return new Poll(
            new PollId(dao.Id),
            new PollName(dao.Name),
            new PollDescription(),
            dao.State,
            VoteRules.Default,
            []
            );
    }
}