using System.ComponentModel.DataAnnotations.Schema;

namespace carParkingApi.Models;

public class ParkingAssignment
{
    public int Id { get; set; }

    [Column("VagaId")]
    public int SpotId { get; set; }

    [Column("CarrosId")]
    public int CarId { get; set; }
}
