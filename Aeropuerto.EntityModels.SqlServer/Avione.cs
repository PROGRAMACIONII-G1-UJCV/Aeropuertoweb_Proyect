using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Aeropuerto.EntityModels;

[Index("Matricula", Name = "UQ__Aviones__0FB9FB4F765653AA", IsUnique = true)]
public partial class Avione
{
    [Key]
    public int IdAvion { get; set; }

    [StringLength(15)]
    [Unicode(false)]
    public string Matricula { get; set; } = null!;

    [StringLength(50)]
    [Unicode(false)]
    public string Modelo { get; set; } = null!;

    public int? Capacidad { get; set; }

    public int? AñoFabricacion { get; set; }

    public int IdAerolinea { get; set; }

    public bool? Estado { get; set; }

    [StringLength(30)]
    [Unicode(false)]
    public string? Tipo { get; set; }

    public DateOnly? UltimoMantenimiento { get; set; }

    [ForeignKey("IdAerolinea")]
    [InverseProperty("Aviones")]
    public virtual Aerolinea IdAerolineaNavigation { get; set; } = null!;

    [InverseProperty("IdAvionNavigation")]
    public virtual ICollection<Mantenimiento> Mantenimientos { get; set; } = new List<Mantenimiento>();

    [InverseProperty("IdAvionNavigation")]
    public virtual ICollection<Vuelo> Vuelos { get; set; } = new List<Vuelo>();
}
