using carParkingApi.Context;
using carParkingApi.Models;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;

namespace carParkingApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ParkingAssignmentController : ControllerBase
    {
        private readonly ParkingContext _context;

        public ParkingAssignmentController(ParkingContext context)
        {
            _context = context;
        }


        #region Get

        [HttpGet("all")]
        public IActionResult GetAllParkingAssignments()
        {
            var parkingAssignments = _context.ParkingAssignments.ToList();

            return Ok(parkingAssignments);
        }

        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            var parkingAssignment = _context.ParkingAssignments.FirstOrDefault(x => x.Id == id);

            if (parkingAssignment == null)
                return NotFound();

            return Ok(parkingAssignment);
        }

        [HttpGet("spotId")]
        public IActionResult GetBySpotId(int spotId)
        {
            var parkingAssignment = _context.ParkingAssignments.Where(x => x.SpotId == spotId);

            if (parkingAssignment == null)
                return NotFound();

            return Ok(parkingAssignment);
        }

        [HttpGet("carId")]
        public IActionResult GetByCarId(int carId)
        {
            var parkingAssignment = _context.ParkingAssignments.Where(x => x.CarId == carId);

            if (parkingAssignment == null)
                return NotFound();

            return Ok(parkingAssignment);
        }

        #endregion

        [HttpPost]
        public IActionResult Create([FromBody] ParkingAssignment parkingAssignment)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            _context.ParkingAssignments.Add(parkingAssignment);
            _context.SaveChanges();
            return CreatedAtAction(nameof(GetById), new {id = parkingAssignment.Id}, parkingAssignment);
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var parkingAssignment = _context.ParkingAssignments.Find(id);

            if (parkingAssignment == null)
                return NotFound();

            _context.Remove(parkingAssignment);
            _context.SaveChanges();

            return NoContent();
        }

        [HttpPut("{id}")]
        public IActionResult Update(int id, ParkingAssignment parkingAssignment)
        {
            var oldestParkingAssignment = _context.ParkingAssignments.Find(id);

            if (oldestParkingAssignment == null)
                return NotFound();

            oldestParkingAssignment.SpotId = parkingAssignment.SpotId;
            oldestParkingAssignment.CarId = parkingAssignment.CarId;

            _context.SaveChanges();
            return Ok(parkingAssignment);
        }
    }
}
