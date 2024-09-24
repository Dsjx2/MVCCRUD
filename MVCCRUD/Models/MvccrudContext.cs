using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace MVCCRUD.Models;

public partial class MvccrudContext : DbContext
{
    public MvccrudContext()
    {
    }

    public MvccrudContext(DbContextOptions<MvccrudContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Carta> Cartas { get; set; }

    public virtual DbSet<Mazo> Mazos { get; set; }

    public virtual DbSet<Usuario> Usuarios { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    //#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
    //=> optionsBuilder.UseSqlServer("Server=DANIELSS\\MSSQLSERVER01;Database=MVCCRUD;Integrated Security=True; TrustServerCertificate=Yes");
    { }
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Carta>(entity =>
        {
            entity.HasKey(e => e.IdCarta).HasName("PK__Cartas__D3C2E8F17F4DCD3F");

            entity.Property(e => e.IdCarta).HasColumnName("id_carta");
            entity.Property(e => e.NombreCarta)
                .HasMaxLength(100)
                .HasColumnName("nombre_carta");
            entity.Property(e => e.PoderAtaque).HasColumnName("poder_ataque");
            entity.Property(e => e.PoderDefensa).HasColumnName("poder_defensa");
            entity.Property(e => e.TipoCarta)
                .HasMaxLength(50)
                .HasColumnName("tipo_carta");
        });

        modelBuilder.Entity<Mazo>(entity =>
        {
            entity.HasKey(e => e.IdMazo).HasName("PK__mazos__6FA07F700543202F");

            entity.ToTable("mazos");

            entity.Property(e => e.IdMazo).HasColumnName("id_mazo");
            entity.Property(e => e.MazoNombre)
                .HasMaxLength(100)
                .HasColumnName("mazo_nombre");
        });

        modelBuilder.Entity<Usuario>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Usuarios__3214EC071A3FB509");

            entity.Property(e => e.Clave)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.Nombre)
                .HasMaxLength(50)
                .IsUnicode(false);
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
