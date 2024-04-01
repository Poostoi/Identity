using System.Net.Mime;
using Api.Services;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers;
[ApiController]
[Produces(MediaTypeNames.Application.Json)]
[Route("api/[controller]")]
[EnableCors("ApiScope")]

public class BaseController: ControllerBase
{
    private readonly IBaseService _service;

    public BaseController(IBaseService service)
    {
        _service = service;
    }

    [HttpGet]
    public IActionResult Get(string row)
    {
        return Ok(_service.Print(row));
    }
}