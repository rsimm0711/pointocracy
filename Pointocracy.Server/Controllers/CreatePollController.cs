using Microsoft.AspNetCore.Mvc;
using Pointocracy.Core.Actions;
using Pointocracy.Core.Models;
using System.ComponentModel.DataAnnotations;
using System.Net;
using Pointocracy.Infra.DataCommands;
using Pointocracy.Server.Dtos;

namespace Pointocracy.Server.Controllers;

public class CreatePollRequest
{
    [Required]
    public required string Name { get; init; }

    public string? Description { get; init; }
}

public sealed class CreatePollController(ICreatePoll createPoll, ISaveContext saveContext) : PollController
{
    [HttpPost("")]
    [ProducesResponseType<PollDto>((int)HttpStatusCode.Created)]
    public async ValueTask<ActionResult<PollDto>> CreatePoll(CreatePollRequest request)
    {
        var poll = createPoll.Create(request.Name, request.Description, VoteRules.Default);
        var dto = PollDto.Create(poll);
        await saveContext.SaveAsync();
        return new CreatedResult(dto.Id.ToString(), dto);
    }
}