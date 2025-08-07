using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Aeropuerto.EntityModels;

public partial class Empleado
{
    [Key]
    public int IdEmpleado { get; set; }

    [StringLength(50)]
    [Unicode(false)]
    public string Nombre { get; set; } = null!;

    [StringLength(50)]
    [Unicode(false)]
    public string Apellido { get; set; } = null!;

    public int? Edad { get; set; }

    [StringLength(50)]
    [Unicode(false)]
    public string Cargo { get; set; } = null!;

    public int IdAeropuerto { get; set; }

    public DateOnly FechaIngreso { get; set; }

    [StringLength(50)]
    [Unicode(false)]
    public string? Email { get; set; }

    [StringLength(20)]
    [Unicode(false)]
    public string? Telefono { get; set; }

    public bool? Estado { get; set; }

    [ForeignKey("IdAeropuerto")]
    [InverseProperty("Empleados")]
    public virtual Aeropuerto IdAeropuertoNavigation { get; set; } = null!;
}
