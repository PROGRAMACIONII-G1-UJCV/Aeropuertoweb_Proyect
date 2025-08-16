using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace Aeropuerto.EntityModels;

public partial class AeropuertoContext : DbContext
{
    public AeropuertoContext()
    {
    }

    public AeropuertoContext(DbContextOptions<AeropuertoContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Aerolinea> Aerolineas { get; set; }

    public virtual DbSet<Aeropuerto> Aeropuertos { get; set; }

    public virtual DbSet<Avione> Aviones { get; set; }

    public virtual DbSet<Boleto> Boletos { get; set; }

    public virtual DbSet<Empleado> Empleados { get; set; }

    public virtual DbSet<Equipaje> Equipajes { get; set; }

    public virtual DbSet<Mantenimiento> Mantenimientos { get; set; }

    public virtual DbSet<Pasajero> Pasajeros { get; set; }

    public virtual DbSet<PuertasEmbarque> PuertasEmbarques { get; set; }

    public virtual DbSet<Vuelo> Vuelos { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Data Source=localhost,11433;Initial Catalog=AEROPUERTO;TrustServerCertificate=true;MultipleActiveResultSets=true;User Id=sa;Password=P@ssw0rd;");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Aerolinea>(entity =>
        {
            entity.HasKey(e => e.IdAerolinea).HasName("PK__Aeroline__FE89E8DFBAC0D327");

            entity.Property(e => e.Estado).HasDefaultValue(true);
        });

        modelBuilder.Entity<Aeropuerto>(entity =>
        {
            entity.HasKey(e => e.IdAeropuerto).HasName("PK__Aeropuer__02A32F6949587344");

            entity.Property(e => e.CodigoIata).IsFixedLength();
            entity.Property(e => e.CodigoIcao).IsFixedLength();
        });

        modelBuilder.Entity<Avione>(entity =>
        {
            entity.HasKey(e => e.IdAvion).HasName("PK__Aviones__5CBC7B3FD215AC42");

            entity.Property(e => e.Estado).HasDefaultValue(true);

            entity.HasOne(d => d.IdAerolineaNavigation).WithMany(p => p.Aviones).HasConstraintName("FK__Aviones__IdAerol__45F365D3");
        });

        modelBuilder.Entity<Boleto>(entity =>
        {
            entity.HasOne(d => d.IdVueloNavigation).WithMany(p => p.Boletos)
                .OnDelete(DeleteBehavior.Cascade) // ✅ Esto permite eliminar el vuelo y sus boletos
                .HasConstraintName("FK__Boletos__IdVuelo__628FA481");
        });

        modelBuilder.Entity<Empleado>(entity =>
        {
            entity.HasKey(e => e.IdEmpleado).HasName("PK__Empleado__CE6D8B9E93BB1E16");

            entity.Property(e => e.Estado).HasDefaultValue(true);

            entity.HasOne(d => d.IdAeropuertoNavigation).WithMany(p => p.Empleados).HasConstraintName("FK__Empleados__IdAer__4CA06362");
        });

        modelBuilder.Entity<Equipaje>(entity =>
        {
            entity.HasKey(e => e.IdEquipaje).HasName("PK__Equipaje__B0A41322D395F3E5");

            entity.HasOne(d => d.IdBoletoNavigation).WithMany(p => p.Equipajes)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Equipaje__IdBole__6E01572D");
        });

        modelBuilder.Entity<Mantenimiento>(entity =>
        {
            entity.HasKey(e => e.IdMantenimiento).HasName("PK__Mantenim__DD1C4417650CD784");

            entity.HasOne(d => d.IdAvionNavigation).WithMany(p => p.Mantenimientos)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Mantenimi__IdAvi__73BA3083");
        });

        modelBuilder.Entity<Pasajero>(entity =>
        {
            entity.HasKey(e => e.IdPasajero).HasName("PK__Pasajero__78E232CBBC02B8EB");

            entity.Property(e => e.Estado).HasDefaultValue(true);
        });

        modelBuilder.Entity<PuertasEmbarque>(entity =>
        {
            entity.HasKey(e => e.IdPuerta).HasName("PK__PuertasE__4A275A431F9DA628");

            entity.HasOne(d => d.IdAeropuertoNavigation).WithMany(p => p.PuertasEmbarques)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__PuertasEm__IdAer__68487DD7");
        });

        modelBuilder.Entity<Vuelo>(entity =>
        {
            entity.HasKey(e => e.IdVuelo).HasName("PK__Vuelos__2176172606195BF2");

            entity.ToTable(tb => tb.HasTrigger("trg_CheckHoraLlegada"));

            entity.HasOne(d => d.IdAeropuertoDestinoNavigation).WithMany(p => p.VueloIdAeropuertoDestinoNavigations)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Vuelos__IdAeropu__59063A47");

            entity.HasOne(d => d.IdAeropuertoOrigenNavigation).WithMany(p => p.VueloIdAeropuertoOrigenNavigations)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Vuelos__IdAeropu__5812160E");

            entity.HasOne(d => d.IdAvionNavigation).WithMany(p => p.Vuelos)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Vuelos__IdAvion__59FA5E80");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
