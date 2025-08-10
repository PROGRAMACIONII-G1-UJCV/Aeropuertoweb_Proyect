using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Aeropuerto.DataContext.SqlServer1;

public partial class Pasajero
{
    [Key]
    public int IdPasajero { get; set; }

    [StringLength(50)]
    [Unicode(false)]
    public string Nombre { get; set; } = null!;

    [StringLength(50)]
    [Unicode(false)]
    public string Apellido { get; set; } = null!;

    [StringLength(20)]
    [Unicode(false)]
    public string? Pasaporte { get; set; }

    [StringLength(50)]
    [Unicode(false)]
    public string Nacionalidad { get; set; } = null!;

    [StringLength(50)]
    [Unicode(false)]
    public string? Email { get; set; }

    [StringLength(20)]
    [Unicode(false)]
    public string? Telefono { get; set; }

    public DateOnly FechaNacimiento { get; set; }

    public bool? Estado { get; set; }

    [InverseProperty("IdPasajeroNavigation")]
    public virtual ICollection<Boleto> Boletos { get; set; } = new List<Boleto>();
}
