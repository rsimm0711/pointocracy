using Microsoft.AspNetCore.Mvc;
using Pointocracy.Core.Actions;
using Pointocracy.Core.Models;
using System.ComponentModel.DataAnnotations;
using Pointocracy.Infra.DataCommands;

namespace Pointocracy.Server.Controllers;

public class CreatePollRequest
{
    [Required]
    public string Name { get; init; }

    [Required]
    public string Description { get; init; }
}

public sealed class CreatePollController(ICreatePoll createPoll, ISaveContext saveContext) : PollController
{
    [HttpPost("")]
    public async ValueTask<IActionResult> CreatePoll(CreatePollRequest request)
    {
        createPoll.Create(request.Name, request.Description, VoteRules.Default);
        await saveContext.SaveAsync();
        return Ok();
    }
}