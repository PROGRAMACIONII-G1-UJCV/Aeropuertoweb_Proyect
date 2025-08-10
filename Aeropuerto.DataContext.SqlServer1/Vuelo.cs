using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Aeropuerto.DataContext.SqlServer1;

[Index("NumeroVuelo", Name = "UQ__Vuelos__81835A7F86F418A1", IsUnique = true)]
public partial class Vuelo
{
    [Key]
    public int IdVuelo { get; set; }

    [StringLength(20)]
    [Unicode(false)]
    public string NumeroVuelo { get; set; } = null!;

    public int IdAeropuertoOrigen { get; set; }

    public int IdAeropuertoDestino { get; set; }

    public int IdAvion { get; set; }

    [Column(TypeName = "datetime")]
    public DateTime HoraSalida { get; set; }

    [Column(TypeName = "datetime")]
    public DateTime HoraLlegada { get; set; }

    [StringLength(30)]
    [Unicode(false)]
    public string Estado { get; set; } = null!;

    [Column(TypeName = "decimal(10, 2)")]
    public decimal? Precio { get; set; }

    public DateOnly FechaVuelo { get; set; }

    [InverseProperty("IdVueloNavigation")]
    public virtual ICollection<Boleto> Boletos { get; set; } = new List<Boleto>();

    [ForeignKey("IdAeropuertoDestino")]
    [InverseProperty("VueloIdAeropuertoDestinoNavigations")]
    public virtual Aeropuerto IdAeropuertoDestinoNavigation { get; set; } = null!;

    [ForeignKey("IdAeropuertoOrigen")]
    [InverseProperty("VueloIdAeropuertoOrigenNavigations")]
    public virtual Aeropuerto IdAeropuertoOrigenNavigation { get; set; } = null!;

    [ForeignKey("IdAvion")]
    [InverseProperty("Vuelos")]
    public virtual Avione IdAvionNavigation { get; set; } = null!;
}
