using carParkingApi.Context;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;

namespace carParkingApi.Controllers
{
    [ApiController]
    [Route("api/[controlller]")]
    public class ParkingAssignmentController : ControllerBase
    {
        private readonly ParkingContext _context;

        public ParkingAssignmentController(ParkingContext context)
        {
            _context = context;
        }

        [HttpGet("all")]
        public IActionResult GetAllParkingAssignments()
        {
            var parkingAssignments = _context.ParkingAssignments.ToList();

            return Ok(parkingAssignments);
        }

        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            var parkingAssignment = _context.ParkingAssignments.FirstOrDefault(p => p.Id == id);

            if (parkingAssignment == null)
                return NotFound();

            return Ok(parkingAssignment);
        }

    }
}
