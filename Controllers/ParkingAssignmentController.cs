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
            var parkingAssignment = _context.ParkingAssignments.Find(spotId);

            if (parkingAssignment == null)
                return NotFound();

            return Ok(parkingAssignment);
        }

        [HttpGet("carId")]
        public IActionResult GetByCarId(int carId)
        {
            var parkingAssignment = _context.ParkingAssignments.Find(carId);

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

       
    }
}
