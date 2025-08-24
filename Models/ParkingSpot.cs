using System.ComponentModel.DataAnnotations.Schema;
using carParkingApi.Enum;

namespace carParkingApi.Models;

public class ParkingSpot
{
    public int Id { get; set; }

    [Column("Numero")]
    public int Number { get; set; }

    [Column("Tipo")]
    public string? Type { get; set; }

    [Column("Status")]
    public ParkingSpotState Status { get; set; } 
}
