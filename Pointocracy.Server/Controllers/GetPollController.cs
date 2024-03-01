using Microsoft.AspNetCore.Mvc;
using Pointocracy.Core.Models;
using Pointocracy.Server.Dtos;
using System.Net;
using Pointocracy.Core.Queries;

namespace Pointocracy.Server.Controllers;

public sealed class GetPollController(IFindPollQuery pollQuery) : PollController
{
    [HttpGet("")]
    [ProducesResponseType<PollDto>((int)HttpStatusCode.OK)]
    public async ValueTask<ActionResult<PollDto>> GetPoll(Guid id)
    {
        var pollId = new PollId(id);
        var poll = await pollQuery.FindAsync(pollId);
        var dto = PollDto.Create(poll);
        return Ok(dto);
    }
}