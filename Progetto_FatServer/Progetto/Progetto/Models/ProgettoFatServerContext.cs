using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace Progetto.Models;

public partial class ProgettoFatServerContext : DbContext
{
    public ProgettoFatServerContext()
    {
    }

    public ProgettoFatServerContext(DbContextOptions<ProgettoFatServerContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Cittum> Citta { get; set; }

    public virtual DbSet<Impiegato> Impiegatos { get; set; }

    public virtual DbSet<Provincium> Provincia { get; set; }

    public virtual DbSet<Reparto> Repartos { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Cittum>(entity =>
        {
            entity.HasKey(e => e.CittaId).HasName("PK__Citta__3EF53F311E452F96");

            entity.HasIndex(e => e.Citta, "UQ__Citta__5529C314BF961D45").IsUnique();

            entity.Property(e => e.CittaId).HasColumnName("cittaID");
            entity.Property(e => e.Citta)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("citta");
        });

        modelBuilder.Entity<Impiegato>(entity =>
        {
            entity.HasKey(e => e.ImpiegatoId).HasName("PK__Impiegat__C7A20D120746174E");

            entity.ToTable("Impiegato");

            entity.HasIndex(e => e.Matricola, "UQ__Impiegat__2C2751BAF9EA1E02").IsUnique();

            entity.Property(e => e.ImpiegatoId).HasColumnName("impiegatoID");
            entity.Property(e => e.CittaRif).HasColumnName("cittaRIF");
            entity.Property(e => e.Cognome)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("cognome");
            entity.Property(e => e.DataNascita).HasColumnName("dataNascita");
            entity.Property(e => e.Matricola)
                .HasMaxLength(15)
                .IsUnicode(false)
                .HasColumnName("matricola");
            entity.Property(e => e.Nome)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("nome");
            entity.Property(e => e.ProvinciaRif).HasColumnName("provinciaRIF");
            entity.Property(e => e.RepartoRif)
                .HasDefaultValue(1)
                .HasColumnName("repartoRIF");
            entity.Property(e => e.Ruolo)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasDefaultValue("Non Allocato")
                .HasColumnName("ruolo");
            entity.Property(e => e.ViaResidenza)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("viaResidenza");

            entity.HasOne(d => d.CittaRifNavigation).WithMany(p => p.Impiegatos)
                .HasForeignKey(d => d.CittaRif)
                .HasConstraintName("FK__Impiegato__citta__2DE6D218");

            entity.HasOne(d => d.ProvinciaRifNavigation).WithMany(p => p.Impiegatos)
                .HasForeignKey(d => d.ProvinciaRif)
                .HasConstraintName("FK__Impiegato__provi__2EDAF651");

            entity.HasOne(d => d.RepartoRifNavigation).WithMany(p => p.Impiegatos)
                .HasForeignKey(d => d.RepartoRif)
                .HasConstraintName("FK__Impiegato__provi__2CF2ADDF");
        });

        modelBuilder.Entity<Provincium>(entity =>
        {
            entity.HasKey(e => e.ProvinciaId).HasName("PK__Provinci__671F13456FD9307C");

            entity.HasIndex(e => e.Provincia, "UQ__Provinci__6D706CEE3F2A87FF").IsUnique();

            entity.Property(e => e.ProvinciaId).HasColumnName("provinciaID");
            entity.Property(e => e.Provincia)
                .HasMaxLength(10)
                .IsUnicode(false)
                .HasColumnName("provincia");
        });

        modelBuilder.Entity<Reparto>(entity =>
        {
            entity.HasKey(e => e.RepartoId).HasName("PK__Reparto__612C4F36B3ED98C7");

            entity.ToTable("Reparto");

            entity.HasIndex(e => e.Nome, "UQ__Reparto__6F71C0DC2A2B366C").IsUnique();

            entity.Property(e => e.RepartoId).HasColumnName("repartoID");
            entity.Property(e => e.Nome)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("nome");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
