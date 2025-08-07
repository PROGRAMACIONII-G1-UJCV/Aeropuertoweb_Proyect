using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Aeropuerto.EntityModels;

public partial class Aerolinea
{
    [Key]
    public int IdAerolinea { get; set; }

    [StringLength(100)]
    [Unicode(false)]
    public string Nombre { get; set; } = null!;

    [StringLength(50)]
    [Unicode(false)]
    public string PaisOrigen { get; set; } = null!;

    public int? AñoFundacion { get; set; }

    [StringLength(100)]
    [Unicode(false)]
    public string? SitioWeb { get; set; }

    [StringLength(20)]
    [Unicode(false)]
    public string? Telefono { get; set; }

    [StringLength(50)]
    [Unicode(false)]
    public string? Email { get; set; }

    [StringLength(150)]
    [Unicode(false)]
    public string? Direccion { get; set; }

    public bool? Estado { get; set; }

    [InverseProperty("IdAerolineaNavigation")]
    public virtual ICollection<Avione> Aviones { get; set; } = new List<Avione>();
}
