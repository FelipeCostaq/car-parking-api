using System.ComponentModel.DataAnnotations.Schema;

namespace carParkingApi.Models;

public class Car
{
    public int Id { get; set; }

    [Column("Placa")]
    public string? Plate { get; set; }

    [Column("Modelo")]
    public string? Model { get; set; }

    [Column("Proprietario")]
    public string? Owner { get; set; }

    [Column("Apartamento")]
    public int Apartment { get; set; }
}
