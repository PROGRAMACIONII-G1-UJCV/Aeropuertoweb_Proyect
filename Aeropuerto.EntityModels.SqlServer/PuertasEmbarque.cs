using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Aeropuerto.EntityModels;

[Table("PuertasEmbarque")]
public partial class PuertasEmbarque
{
    [Key]
    public int IdPuerta { get; set; }

    public int IdAeropuerto { get; set; }

    [StringLength(10)]
    [Unicode(false)]
    public string Numero { get; set; } = null!;

    [StringLength(30)]
    [Unicode(false)]
    public string Estado { get; set; } = null!;

    [StringLength(30)]
    [Unicode(false)]
    public string? Tipo { get; set; }

    public int? Capacidad { get; set; }

    [StringLength(200)]
    [Unicode(false)]
    public string? Observaciones { get; set; }

    [StringLength(10)]
    [Unicode(false)]
    public string? Piso { get; set; }

    [StringLength(30)]
    [Unicode(false)]
    public string? EstadoAsignacion { get; set; }

    [ForeignKey("IdAeropuerto")]
    [InverseProperty("PuertasEmbarques")]
    public virtual Aeropuerto IdAeropuertoNavigation { get; set; } = null!;
}
