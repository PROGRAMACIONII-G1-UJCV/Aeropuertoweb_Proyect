using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Aeropuerto.DataContext.SqlServer1;

[Table("Mantenimiento")]
public partial class Mantenimiento
{
    [Key]
    public int IdMantenimiento { get; set; }

    public int IdAvion { get; set; }

    public DateOnly Fecha { get; set; }

    [StringLength(50)]
    [Unicode(false)]
    public string Tipo { get; set; } = null!;

    [StringLength(200)]
    [Unicode(false)]
    public string? Descripcion { get; set; }

    [Column(TypeName = "decimal(10, 2)")]
    public decimal? Costo { get; set; }

    [StringLength(100)]
    [Unicode(false)]
    public string? Responsable { get; set; }

    [StringLength(30)]
    [Unicode(false)]
    public string Estado { get; set; } = null!;

    public DateOnly? ProximoServicio { get; set; }

    [ForeignKey("IdAvion")]
    [InverseProperty("Mantenimientos")]
    public virtual Avione IdAvionNavigation { get; set; } = null!;
}
