using carParkingApi.Context;
using carParkingApi.Enum;
using carParkingApi.Models;
using Microsoft.AspNetCore.Mvc;

namespace carParkingApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ParkingSpotController : ControllerBase
    {
        private readonly ParkingContext _context;

        public ParkingSpotController(ParkingContext context)
        {
            _context = context;
        }

        #region Get

        [HttpGet("{id}")]
        public IActionResult GetSpotById(int id)
        {
            var spot = _context.ParkingSpots.FirstOrDefault(p => p.Id == id);

            if (spot == null)
                return NotFound();

            return Ok(spot);
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            var spots = _context.ParkingSpots.ToList();

            return Ok(spots);
        }

        [HttpGet("number")]
        public IActionResult GetByNumber(int number)
        {
            var spots = _context.ParkingSpots.Where(x => x.Number == number).ToList();

            return Ok(spots);
        }

        [HttpGet("type")]
        public IActionResult GetByType(string type)
        {
            var spots = _context.ParkingSpots.Where(x => x.Type != null && x.Type.Contains(type)).ToList();

            return Ok(spots);
        }

        [HttpGet("status")]
        public IActionResult GetByStatus(ParkingSpotState status)
        {
            var spots = _context.ParkingSpots.Where(s => s.Status == status).ToList();

            return Ok(spots);
        }

        #endregion

        [HttpPost]
        public IActionResult Create([FromBody] ParkingSpot parkingSpot)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            _context.Add(parkingSpot);
            _context.SaveChanges();
            return CreatedAtAction(nameof(GetSpotById), new {id = parkingSpot.Id}, parkingSpot);
        }

        [HttpPut("{id}")]
        public IActionResult Update(int id, ParkingSpot parkingSpot)
        {
            var oldestParkingSpot = _context.ParkingSpots.Find(id);

            if (oldestParkingSpot == null)
                return NotFound();

            oldestParkingSpot.Number = parkingSpot.Number;
            oldestParkingSpot.Type = parkingSpot.Type;
            oldestParkingSpot.Status = parkingSpot.Status;

            _context.SaveChanges();

            return Ok(parkingSpot);
        }
    }
}
