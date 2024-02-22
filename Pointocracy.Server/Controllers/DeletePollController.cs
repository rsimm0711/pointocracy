using Microsoft.AspNetCore.Mvc;
using Pointocracy.Core.Actions;
using Pointocracy.Core.Models;

namespace Pointocracy.Server.Controllers;

public sealed class DeletePollController(IDeletePoll deletePoll) : Controller
{
    [HttpDelete("")]
    public IActionResult Delete(Guid id)
    {
        var pollId = new PollId(id);
        deletePoll.Delete(pollId);
        return Ok();
    }
}