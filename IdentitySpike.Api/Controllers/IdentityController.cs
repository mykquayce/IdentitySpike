using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace IdentitySpike.Api.Controllers;

[ApiController]
[Authorize]
[Route("[controller]")]
public class IdentityController : ControllerBase
{
	private readonly ILogger<IdentityController> _logger;

	public IdentityController(ILogger<IdentityController> logger)
	{
		_logger = logger;
	}

	[HttpGet]
	public IActionResult Get()
	{
		var results = (from claim in User.Claims
					   select new { claim.Type, claim.Value, })
					  .ToList();

		_logger.LogDebug("{results}", results);

		return Ok(results);
	}
}
