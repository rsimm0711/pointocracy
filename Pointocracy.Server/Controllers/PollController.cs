using Microsoft.AspNetCore.Mvc;

namespace Pointocracy.Server.Controllers;

[ApiController]
[Route("polls")]
[Tags("Polls")]
public abstract class PollController : ControllerBase;