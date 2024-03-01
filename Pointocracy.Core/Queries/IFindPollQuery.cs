using Pointocracy.Core.Models;

namespace Pointocracy.Core.Queries;

public interface IFindPollQuery
{
    ValueTask<Poll> FindAsync(PollId id);
}