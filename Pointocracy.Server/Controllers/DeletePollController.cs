using Microsoft.AspNetCore.Mvc;
using Pointocracy.Core.Actions;
using Pointocracy.Core.Models;
using Pointocracy.Infra.DataCommands;

namespace Pointocracy.Server.Controllers;

public sealed class DeletePollController(IDeletePoll deletePoll, ISaveContext saveContext) : PollController
{
    [HttpDelete("")]
    public async ValueTask<IActionResult> Delete(Guid id)
    {
        var pollId = new PollId(id);
        deletePoll.Delete(pollId);
        await saveContext.SaveAsync();
        return Ok();
    }
}