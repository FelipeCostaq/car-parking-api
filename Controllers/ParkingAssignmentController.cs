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

        #endregion
    }
}
