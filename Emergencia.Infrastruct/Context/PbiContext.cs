using System;
using System.Collections.Generic;
using Emergencia.Domain.Entities;
using Emergencia.Infrastructure.Models;
using Microsoft.EntityFrameworkCore;

namespace Emergencia.Infrastructure.Context;

public partial class PbiContext : DbContext
{
    public PbiContext()
    {
    }

    public PbiContext(DbContextOptions<PbiContext> options)
        : base(options)
    {
    }

    public DbSet<Cliente> Clientes { get; set; }

    public DbSet<Evento> Eventos { get; set; }

    public DbSet<Pagamento> Pagamentos { get; set; }

    public DbSet<Inscricao> Insricoes { get; set; }


    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseNpgsql("Host=localhost;Port=5433;Database=ingressosDB;Username=postgres;Password=postgres;");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {  

        modelBuilder.Entity<Cliente>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("tb_cliente_pkey");

            entity.ToTable("tb_cliente");

            entity.Property(e => e.Id)
                .ValueGeneratedNever();

        });

        modelBuilder.Entity<Pagamento>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("tb_pagamento_pkey");

            entity.ToTable("tb_pagamento");

            entity.Property(e => e.Id)
                .ValueGeneratedNever();


            entity.HasOne(d => d.Cliente).WithMany(p => p.Pagamentos)
                .HasForeignKey(d => d.CdCliente)
                .HasConstraintName("fk_tb_pagamento_tb_cliente_1");
        });


        modelBuilder.Entity<Inscricao>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("tb_inscricao_pkey");

            entity.ToTable("tb_inscricao");

            entity.Property(e => e.Id)
                .ValueGeneratedNever();

            entity.Property(e => e.Status)
              .HasDefaultValue("Aguardadndo pagamento");


            entity.HasOne(d => d.Cliente).WithMany(p => p.Inscricoes)
                .HasForeignKey(d => d.CdCliente)
                .HasConstraintName("fk_inscricao_tb_cliente_1");

            entity.HasOne(d => d.Evento).WithMany(p => p.Inscricoes)
              .HasForeignKey(d => d.CdEvento)
              .HasConstraintName("fk_evento_inscricao");
        });

        modelBuilder.Entity<Evento>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("tb_evento_pkey");

            entity.ToTable("tb_evento");

            entity.Property(e => e.Id)
                .ValueGeneratedNever();
           
        });

        OnModelCreatingPartial(modelBuilder);

        base.OnModelCreating(modelBuilder);
        modelBuilder.ApplyConfigurationsFromAssembly(typeof(PbiContext)
            .Assembly);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
