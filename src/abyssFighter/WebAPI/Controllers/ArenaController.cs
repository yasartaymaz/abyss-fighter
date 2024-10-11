using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers;

[Route("api/[controller]")]
[ApiController]
public class ArenaController : BaseController
{
	public IActionResult Fight(/*requestobject*/)
	{
		return Ok();
	}
}
