using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Aeropuerto.EntityModels;

[Table("Equipaje")]
public partial class Equipaje
{
    [Key]
    public int IdEquipaje { get; set; }

    public int IdBoleto { get; set; }

    [Column(TypeName = "decimal(5, 2)")]
    public decimal? Peso { get; set; }

    [StringLength(200)]
    [Unicode(false)]
    public string? Descripcion { get; set; }

    [StringLength(30)]
    [Unicode(false)]
    public string Estado { get; set; } = null!;

    [Column(TypeName = "datetime")]
    public DateTime HoraRegistro { get; set; }

    [StringLength(30)]
    [Unicode(false)]
    public string? Tipo { get; set; }

    [StringLength(100)]
    [Unicode(false)]
    public string? Ubicacion { get; set; }

    [StringLength(200)]
    [Unicode(false)]
    public string? Observaciones { get; set; }

    [ForeignKey("IdBoleto")]
    [InverseProperty("Equipajes")]
    public virtual Boleto IdBoletoNavigation { get; set; } = null!;
}
