using Pointocracy.Core.Models;
using Pointocracy.Core.Queries;
using Pointocracy.Infra.Models;

namespace Pointocracy.Infra.Queries;

internal sealed class FindPollQuery(PointocracyDb database) : IFindPollQuery
{
    public async ValueTask<Poll> FindAsync(PollId id)
    {
        var dao = await database.FindAsync<PollDao>(id.Guid);
        var poll = PollDao.ToPoll(dao);
        return poll;
    }
}