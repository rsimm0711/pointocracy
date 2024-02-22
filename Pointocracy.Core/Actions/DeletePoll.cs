using Pointocracy.Core.DataCommands;
using Pointocracy.Core.Models;
using Pointocracy.Core.Results;

namespace Pointocracy.Core.Actions;

public interface IDeletePoll
{
    Result Delete(PollId pollId);
}

internal sealed class DeletePoll(IDeletePollCommand deleteCommand) : IDeletePoll
{
    public Result Delete(PollId pollId)
    {
        deleteCommand.Delete(pollId);
        return Result.Success();
    }
}