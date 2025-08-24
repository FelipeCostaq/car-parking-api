using carParkingApi.Context;
using Microsoft.AspNetCore.Mvc;

namespace carParkingApi.Controllers;

[ApiController]
[Route("[controller]")]
public class CarController : ControllerBase
{
    private readonly ParkingContext _context;

    public CarController(ParkingContext context)
    {
        _context = context;
    }

    [HttpGet("{id}")]
    public IActionResult GetCarById(int id)
    {
        var tarefa = _context.Cars.FirstOrDefault(p => p.Id == id);

        if (tarefa == null)
            return NotFound();

        return Ok(tarefa);
    }
}
