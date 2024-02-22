using Pointocracy.Core.Models;

namespace Pointocracy.Core.DataCommands;

public interface IDeletePollCommand
{
    void Delete(PollId pollId);
}