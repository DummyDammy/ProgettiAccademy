using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace Progetto_Eventi.Models;

public partial class Progetto05EventiContext : DbContext
{
    public Progetto05EventiContext()
    {
    }

    public Progetto05EventiContext(DbContextOptions<Progetto05EventiContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Evento> Eventos { get; set; }

    public virtual DbSet<Partecipante> Partecipantes { get; set; }

    public virtual DbSet<Risorsa> Risorsas { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Server=ACADEMY2024-16\\SQLEXPRESS;Database=progetto05_Eventi;User Id=academy;Password=academy!;MultipleActiveResultSets=true;Encrypt=false;TrustServerCertificate=false");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Evento>(entity =>
        {
            entity.HasKey(e => e.EventoId).HasName("PK__Evento__DE07229C19C6F508");

            entity.ToTable("Evento");

            entity.Property(e => e.EventoId).HasColumnName("eventoID");
            entity.Property(e => e.Capacita).HasColumnName("capacita");
            entity.Property(e => e.DataEvento).HasColumnName("data_evento");
            entity.Property(e => e.Luogo)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("luogo");
            entity.Property(e => e.Nome)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("nome");
            entity.Property(e => e.PartecipanteRif).HasColumnName("partecipanteRIF");
            entity.Property(e => e.RisorsaRif).HasColumnName("risorsaRIF");

            entity.HasOne(d => d.PartecipanteRifNavigation).WithMany(p => p.Eventos)
                .HasForeignKey(d => d.PartecipanteRif)
                .HasConstraintName("FK__Evento__risorsaR__74AE54BC");

            entity.HasOne(d => d.RisorsaRifNavigation).WithMany(p => p.Eventos)
                .HasForeignKey(d => d.RisorsaRif)
                .HasConstraintName("FK__Evento__risorsaR__75A278F5");
        });

        modelBuilder.Entity<Partecipante>(entity =>
        {
            entity.HasKey(e => e.PartecipanteId).HasName("PK__Partecip__59BAFC0EE9922D61");

            entity.ToTable("Partecipante");

            entity.HasIndex(e => e.Email, "UQ__Partecip__AB6E6164BDCA7DB9").IsUnique();

            entity.Property(e => e.PartecipanteId).HasColumnName("partecipanteID");
            entity.Property(e => e.Cognome)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("cognome");
            entity.Property(e => e.Email)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("email");
            entity.Property(e => e.Nome)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("nome");
        });

        modelBuilder.Entity<Risorsa>(entity =>
        {
            entity.HasKey(e => e.RisorsaId).HasName("PK__Risorsa__31473C9923E92433");

            entity.ToTable("Risorsa");

            entity.Property(e => e.RisorsaId).HasColumnName("risorsaID");
            entity.Property(e => e.Fornitore)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("fornitore");
            entity.Property(e => e.Nome)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("nome");
            entity.Property(e => e.Prezzo)
                .HasColumnType("decimal(7, 2)")
                .HasColumnName("prezzo");
            entity.Property(e => e.Quantita).HasColumnName("quantita");
            entity.Property(e => e.Tipo)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("tipo");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
