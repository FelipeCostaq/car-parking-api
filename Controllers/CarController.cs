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
        var car = _context.Cars.FirstOrDefault(p => p.Id == id);

        if (car == null)
            return NotFound();

        return Ok(car);
    }

    [HttpGet("GetAllCars")]
    public IActionResult GetAlCars()
    {
        var cars = _context.Cars.ToList();

        return Ok(cars);
    }

    [HttpGet("GetByPlate")]
    public IActionResult GetByPlate(string plate)
    {
        var cars = _context.Cars.Where(x => x.Plate != null && x.Plate.Contains(plate)).ToList();

        return Ok(cars);
    }

    [HttpGet("GetByModel")]
    public IActionResult GetByModel(string model)
    {
        var cars = _context.Cars.Where(x => x.Model != null && x.Model.Contains(model)).ToList();

        return Ok(cars);
    }

    [HttpGet("GetByOwner")]
    public IActionResult GetByOwner(string owner)
    {
        var cars = _context.Cars.Where(x => x.Owner != null && x.Owner.Contains(owner)).ToList();

        return Ok(cars);
    }

    [HttpGet("GetByApartment")]
    public IActionResult GetByApartment(int apartment)
    {
        var cars = _context.Cars.Where(x => x.Apartment == apartment).ToList();

        return Ok(cars);
    }
}
