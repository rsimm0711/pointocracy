using Microsoft.AspNetCore.Mvc;
using Pointocracy.Core.Actions;
using Pointocracy.Core.Models;
using System.ComponentModel.DataAnnotations;

namespace Pointocracy.Server.Controllers;

public class CreatePollRequest
{
    [Required]
    public string Name { get; init; }

    [Required]
    public string Description { get; init; }
}

public sealed class CreatePollController(ICreatePoll createPoll) : Controller
{
    [HttpPost("")]
    public IActionResult CreatePoll(CreatePollRequest request)
    {
        createPoll.Create(request.Name, request.Description, VoteRules.Default);
        return Ok();
    }
}