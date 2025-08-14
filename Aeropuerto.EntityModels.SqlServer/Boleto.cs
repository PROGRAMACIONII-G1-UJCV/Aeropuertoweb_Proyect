using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Aeropuerto.EntityModels;

[Index("IdVuelo", "Asiento", Name = "UQ_Boletos_Asiento", IsUnique = true)]
public partial class Boleto
{
    [Key]
    public int IdBoleto { get; set; }

    public int IdVuelo { get; set; }

    public int IdPasajero { get; set; }

    [StringLength(10)]
    [Unicode(false)]
    public string Asiento { get; set; } = null!;

    [Column(TypeName = "decimal(10, 2)")]
    public decimal? Precio { get; set; }

    [Column(TypeName = "datetime")]
    public DateTime FechaCompra { get; set; }

    [StringLength(30)]
    [Unicode(false)]
    public string Estado { get; set; } = null!;

    [StringLength(30)]
    [Unicode(false)]
    public string? FormaPago { get; set; }

    [StringLength(30)]
    [Unicode(false)]
    public string? CodigoReserva { get; set; }

    [InverseProperty("IdBoletoNavigation")]
    public virtual ICollection<Equipaje> Equipajes { get; set; } = [];

    [ForeignKey("IdPasajero")]
    [InverseProperty("Boletos")]
    public virtual Pasajero IdPasajeroNavigation { get; set; } = null!;

    [ForeignKey("IdVuelo")]
    [InverseProperty("Boletos")]
    public virtual Vuelo IdVueloNavigation { get; set; } = null!;
}
