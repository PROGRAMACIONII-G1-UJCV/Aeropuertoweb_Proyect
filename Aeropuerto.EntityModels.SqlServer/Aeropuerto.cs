using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Aeropuerto.EntityModels;

public partial class Aeropuerto
{
    [Key]
    public int IdAeropuerto { get; set; }

    [StringLength(100)]
    [Unicode(false)]
    public string Nombre { get; set; } = null!;

    [StringLength(50)]
    [Unicode(false)]
    public string Ciudad { get; set; } = null!;

    [StringLength(50)]
    [Unicode(false)]
    public string Pais { get; set; } = null!;

    [StringLength(150)]
    [Unicode(false)]
    public string? Direccion { get; set; }

    [StringLength(20)]
    [Unicode(false)]
    public string? Telefono { get; set; }

    [StringLength(50)]
    [Unicode(false)]
    public string? Email { get; set; }

    [Column("CodigoIATA")]
    [StringLength(3)]
    [Unicode(false)]
    public string? CodigoIata { get; set; }

    [Column("CodigoICAO")]
    [StringLength(4)]
    [Unicode(false)]
    public string? CodigoIcao { get; set; }

    [InverseProperty("IdAeropuertoNavigation")]
    public virtual ICollection<Empleado> Empleados { get; set; } = new List<Empleado>();

    [InverseProperty("IdAeropuertoNavigation")]
    public virtual ICollection<PuertasEmbarque> PuertasEmbarques { get; set; } = new List<PuertasEmbarque>();

    [InverseProperty("IdAeropuertoDestinoNavigation")]
    public virtual ICollection<Vuelo> VueloIdAeropuertoDestinoNavigations { get; set; } = new List<Vuelo>();

    [InverseProperty("IdAeropuertoOrigenNavigation")]
    public virtual ICollection<Vuelo> VueloIdAeropuertoOrigenNavigations { get; set; } = new List<Vuelo>();
}
