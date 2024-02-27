using Microsoft.AspNetCore.Mvc;

namespace Pointocracy.Server.Controllers;

[ApiController]
[Route("polls")]
public abstract class PollController : ControllerBase;