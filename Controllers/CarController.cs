using carParkingApi.Context;
using carParkingApi.Models;
using Microsoft.AspNetCore.Mvc;

namespace carParkingApi.Controllers;

[ApiController]
[Route("api/[controller]")]
public class CarController : ControllerBase
{
    private readonly ParkingContext _context;

    public CarController(ParkingContext context)
    {
        _context = context;
    }

    #region Get

    [HttpGet("{id}")]
    public IActionResult GetCarById(int id)
    {
        var car = _context.Cars.FirstOrDefault(p => p.Id == id);

        if (car == null)
            return NotFound();

        return Ok(car);
    }

    [HttpGet("all")]
    public IActionResult GetAllCars()
    {
        var cars = _context.Cars.ToList();

        return Ok(cars);
    }

    [HttpGet("plate")]
    public IActionResult GetByPlate(string plate)
    {
        var cars = _context.Cars.Where(x => x.Plate != null && x.Plate.Contains(plate)).ToList();

        return Ok(cars);
    }

    [HttpGet("model")]
    public IActionResult GetByModel(string model)
    {
        var cars = _context.Cars.Where(x => x.Model != null && x.Model.Contains(model)).ToList();

        return Ok(cars);
    }

    [HttpGet("owner")]
    public IActionResult GetByOwner(string owner)
    {
        var cars = _context.Cars.Where(x => x.Owner != null && x.Owner.Contains(owner)).ToList();

        return Ok(cars);
    }

    [HttpGet("apartment")]
    public IActionResult GetByApartment(int apartment)
    {
        var cars = _context.Cars.Where(x => x.Apartment == apartment).ToList();

        return Ok(cars);
    }

    #endregion

    [HttpPost]
    public IActionResult Create([FromBody]Car car)
    {
        if (!ModelState.IsValid)
            return BadRequest(ModelState);

        _context.Cars.Add(car);
        _context.SaveChanges();
        return CreatedAtAction(nameof(GetCarById), new { id = car.Id }, car);
    }

    [HttpPut("{id}")]
    public IActionResult Update(int id, Car car)
    {
        var oldestCar = _context.Cars.Find(id);

        if (oldestCar == null)
            return NotFound();

        oldestCar.Plate = car.Plate;
        oldestCar.Model = car.Model;
        oldestCar.Owner = car.Owner;
        oldestCar.Apartment = car.Apartment;

        _context.SaveChanges();

        return Ok(car);
    }

    [HttpDelete("{id}")]
    public IActionResult Delete(int id)
    {
        var car = _context.Cars.Find(id);

        if (car == null)
            return NotFound();

        _context.Remove(car);
        _context.SaveChanges();

        return NoContent();
    }
}
