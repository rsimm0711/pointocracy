using Pointocracy.Core.DataCommands;
using Pointocracy.Core.Models;
using Pointocracy.Infra.Models;

namespace Pointocracy.Infra.DataCommands;

internal sealed class DeletePollCommand(PointocracyDb database) : IDeletePollCommand
{
    public void Delete(PollId pollId)
    {
        var dao = new PollDao
        {
            Id = pollId.Guid
        };
        database.Polls.Remove(dao);
    }
}