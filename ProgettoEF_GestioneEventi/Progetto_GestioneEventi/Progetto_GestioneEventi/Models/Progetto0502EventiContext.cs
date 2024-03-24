using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace Progetto_GestioneEventi.Models;

public partial class Progetto0502EventiContext : DbContext
{
    public Progetto0502EventiContext()
    {
    }

    public Progetto0502EventiContext(DbContextOptions<Progetto0502EventiContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Evento> Eventos { get; set; }

    public virtual DbSet<Partecipante> Partecipantes { get; set; }

    public virtual DbSet<Risorsa> Risorsas { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Server=ACADEMY2024-16\\SQLEXPRESS;Database=progetto05_02_Eventi;User Id=academy;Password=academy!;MultipleActiveResultSets=true;Encrypt=false;TrustServerCertificate=false");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Evento>(entity =>
        {
            entity.HasKey(e => e.EventoId).HasName("PK__Evento__DE07229CBA911D67");

            entity.ToTable("Evento");

            entity.HasIndex(e => e.Nome, "UQ__Evento__6F71C0DCA45E61CC").IsUnique();

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

            entity.HasMany(d => d.PartecipanteRifs).WithMany(p => p.EventoRifs)
                .UsingEntity<Dictionary<string, object>>(
                    "EventoPartecipante",
                    r => r.HasOne<Partecipante>().WithMany()
                        .HasForeignKey("PartecipanteRif")
                        .OnDelete(DeleteBehavior.ClientSetNull)
                        .HasConstraintName("FK__Evento_Pa__parte__74AE54BC"),
                    l => l.HasOne<Evento>().WithMany()
                        .HasForeignKey("EventoRif")
                        .OnDelete(DeleteBehavior.ClientSetNull)
                        .HasConstraintName("FK__Evento_Pa__parte__73BA3083"),
                    j =>
                    {
                        j.HasKey("EventoRif", "PartecipanteRif").HasName("PK__Evento_P__20AA1CF4BB058677");
                        j.ToTable("Evento_Partecipante");
                        j.IndexerProperty<int>("EventoRif").HasColumnName("eventoRIF");
                        j.IndexerProperty<int>("PartecipanteRif").HasColumnName("partecipanteRIF");
                    });

            entity.HasMany(d => d.RisorsaRifs).WithMany(p => p.EventoRifs)
                .UsingEntity<Dictionary<string, object>>(
                    "EventoRisorsa",
                    r => r.HasOne<Risorsa>().WithMany()
                        .HasForeignKey("RisorsaRif")
                        .OnDelete(DeleteBehavior.ClientSetNull)
                        .HasConstraintName("FK__Evento_Ri__risor__787EE5A0"),
                    l => l.HasOne<Evento>().WithMany()
                        .HasForeignKey("EventoRif")
                        .OnDelete(DeleteBehavior.ClientSetNull)
                        .HasConstraintName("FK__Evento_Ri__risor__778AC167"),
                    j =>
                    {
                        j.HasKey("EventoRif", "RisorsaRif").HasName("PK__Evento_R__13AAF592B4A8B982");
                        j.ToTable("Evento_Risorsa");
                        j.IndexerProperty<int>("EventoRif").HasColumnName("eventoRIF");
                        j.IndexerProperty<int>("RisorsaRif").HasColumnName("risorsaRIF");
                    });
        });

        modelBuilder.Entity<Partecipante>(entity =>
        {
            entity.HasKey(e => e.PartecipanteId).HasName("PK__Partecip__59BAFC0E21389093");

            entity.ToTable("Partecipante");

            entity.HasIndex(e => e.Email, "UQ__Partecip__AB6E6164D1180849").IsUnique();

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
            entity.HasKey(e => e.RisorsaId).HasName("PK__Risorsa__31473C9977D676DE");

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
