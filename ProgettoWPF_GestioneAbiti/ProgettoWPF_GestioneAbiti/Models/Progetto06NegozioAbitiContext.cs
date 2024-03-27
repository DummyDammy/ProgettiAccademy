using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace ProgettoWPF_GestioneAbiti.Models;

public partial class Progetto06NegozioAbitiContext : DbContext
{
    public Progetto06NegozioAbitiContext()
    {
    }

    public Progetto06NegozioAbitiContext(DbContextOptions<Progetto06NegozioAbitiContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Categorium> Categoria { get; set; }

    public virtual DbSet<Offertum> Offerta { get; set; }

    public virtual DbSet<Ordine> Ordines { get; set; }

    public virtual DbSet<Prodotto> Prodottos { get; set; }

    public virtual DbSet<Utente> Utentes { get; set; }

    public virtual DbSet<Variazione> Variaziones { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Server=ACADEMY2024-16\\SQLEXPRESS;Database=progetto06_NegozioAbiti;User Id=academy;Password=academy!;MultipleActiveResultSets=true;Encrypt=false;TrustServerCertificate=false");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Categorium>(entity =>
        {
            entity.HasKey(e => e.CategoriaId).HasName("PK__Categori__6378C0200B180C25");

            entity.HasIndex(e => e.Nome, "UQ__Categori__6F71C0DCA67B00CF").IsUnique();

            entity.Property(e => e.CategoriaId).HasColumnName("categoriaID");
            entity.Property(e => e.Nome)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("nome");
        });

        modelBuilder.Entity<Offertum>(entity =>
        {
            entity.HasKey(e => e.OffertaId).HasName("PK__Offerta__7E01CEA862E1B9BE");

            entity.Property(e => e.OffertaId).HasColumnName("offertaID");
            entity.Property(e => e.DataFine).HasColumnName("data_fine");
            entity.Property(e => e.DataInizio).HasColumnName("data_inizio");
            entity.Property(e => e.Sconto).HasColumnName("sconto");
            entity.Property(e => e.VariazioneRif).HasColumnName("variazioneRIF");

            entity.HasOne(d => d.VariazioneRifNavigation).WithMany(p => p.Offerta)
                .HasForeignKey(d => d.VariazioneRif)
                .HasConstraintName("FK__Offerta__variazi__6477ECF3");
        });

        modelBuilder.Entity<Ordine>(entity =>
        {
            entity.HasKey(e => e.OrdineId).HasName("PK__Ordine__8F87D0E5A45B4790");

            entity.ToTable("Ordine");

            entity.Property(e => e.OrdineId).HasColumnName("ordineID");
            entity.Property(e => e.DataOrdine)
                .HasColumnType("datetime")
                .HasColumnName("data_ordine");
            entity.Property(e => e.DataRitiro)
                .HasColumnType("datetime")
                .HasColumnName("data_ritiro");
            entity.Property(e => e.Quantita).HasColumnName("quantita");
            entity.Property(e => e.UtenteRif).HasColumnName("utenteRIF");
            entity.Property(e => e.VariazioneRif).HasColumnName("variazioneRIF");

            entity.HasOne(d => d.UtenteRifNavigation).WithMany(p => p.Ordines)
                .HasForeignKey(d => d.UtenteRif)
                .HasConstraintName("FK__Ordine__utenteRI__693CA210");

            entity.HasOne(d => d.VariazioneRifNavigation).WithMany(p => p.Ordines)
                .HasForeignKey(d => d.VariazioneRif)
                .HasConstraintName("FK__Ordine__utenteRI__68487DD7");
        });

        modelBuilder.Entity<Prodotto>(entity =>
        {
            entity.HasKey(e => e.ProdottoId).HasName("PK__Prodotto__3AB65975852D667F");

            entity.ToTable("Prodotto");

            entity.Property(e => e.ProdottoId).HasColumnName("prodottoID");
            entity.Property(e => e.CategoriaRif).HasColumnName("categoriaRIF");
            entity.Property(e => e.Descrizione)
                .HasColumnType("text")
                .HasColumnName("descrizione");
            entity.Property(e => e.Marca)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("marca");
            entity.Property(e => e.Nome)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("nome");

            entity.HasOne(d => d.CategoriaRifNavigation).WithMany(p => p.Prodottos)
                .HasForeignKey(d => d.CategoriaRif)
                .HasConstraintName("FK__Prodotto__catego__5DCAEF64");
        });

        modelBuilder.Entity<Utente>(entity =>
        {
            entity.HasKey(e => e.UtenteId).HasName("PK__Utente__CA5C2253ABDAA2C8");

            entity.ToTable("Utente");

            entity.HasIndex(e => e.Telefono, "UQ__Utente__2A16D945D48D64F9").IsUnique();

            entity.Property(e => e.UtenteId).HasColumnName("utenteID");
            entity.Property(e => e.Cognome)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("cognome");
            entity.Property(e => e.Nome)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("nome");
            entity.Property(e => e.Telefono)
                .HasMaxLength(15)
                .IsUnicode(false)
                .HasColumnName("telefono");
        });

        modelBuilder.Entity<Variazione>(entity =>
        {
            entity.HasKey(e => e.VariazioneId).HasName("PK__Variazio__54F6EA5A89A3F540");

            entity.ToTable("Variazione");

            entity.Property(e => e.VariazioneId).HasColumnName("variazioneID");
            entity.Property(e => e.Colore)
                .HasMaxLength(30)
                .IsUnicode(false)
                .HasColumnName("colore");
            entity.Property(e => e.Prezzo)
                .HasColumnType("decimal(7, 2)")
                .HasColumnName("prezzo");
            entity.Property(e => e.ProdottoRif).HasColumnName("prodottoRIF");
            entity.Property(e => e.Quantita).HasColumnName("quantita");
            entity.Property(e => e.Taglia)
                .HasMaxLength(10)
                .IsUnicode(false)
                .HasColumnName("taglia");

            entity.HasOne(d => d.ProdottoRifNavigation).WithMany(p => p.Variaziones)
                .HasForeignKey(d => d.ProdottoRif)
                .HasConstraintName("FK__Variazion__prodo__619B8048");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
