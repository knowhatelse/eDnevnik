using eDnevnik___backend.Helpers;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace eDnevnik___backend.Controllers;

[Route("api/[controller]")]
[ApiController]
[AllowAnonymous]
public class DataSeederController(IDataSeeder dataSeeder) : ControllerBase
{
    private readonly IDataSeeder _dataSeeder = dataSeeder;

    [HttpPost("SeedData")]
    public ActionResult SeedData()
    {
        if (_dataSeeder.SeedData() == true)
        {
            return Ok("The data has been seeded");
        }

        return NotFound("There data has not been seeded");
    }
}