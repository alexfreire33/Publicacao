﻿// <auto-generated />
using System;
using Emergencia.Infrastructure.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace Emergencia.Infrastructure.Migrations
{
    [DbContext(typeof(PbiContext))]
    partial class PbiContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.10")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            NpgsqlModelBuilderExtensions.UseIdentityByDefaultColumns(modelBuilder);

            modelBuilder.Entity("Emergencia.Domain.Entities.Inscricao", b =>
                {
                    b.Property<Guid>("Id")
                        .HasColumnType("uuid");

                    b.Property<Guid>("CdCliente")
                        .HasColumnType("uuid");

                    b.Property<Guid>("CdEvento")
                        .HasColumnType("uuid");

                    b.Property<string>("Status")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("text")
                        .HasDefaultValue("Aguardadndo pagamento");

                    b.Property<DateTime>("dtInsricao")
                        .HasColumnType("timestamp with time zone");

                    b.Property<string>("nrChave")
                        .HasColumnType("text");

                    b.HasKey("Id")
                        .HasName("tb_inscricao_pkey");

                    b.HasIndex("CdCliente");

                    b.HasIndex("CdEvento");

                    b.ToTable("tb_inscricao", (string)null);
                });

            modelBuilder.Entity("Emergencia.Domain.Entities.Pagamento", b =>
                {
                    b.Property<Guid>("Id")
                        .HasColumnType("uuid");

                    b.Property<Guid>("CdCliente")
                        .HasColumnType("uuid");

                    b.Property<int?>("QtdParcelas")
                        .HasColumnType("integer");

                    b.Property<decimal?>("vlPagamento")
                        .HasColumnType("numeric");

                    b.HasKey("Id")
                        .HasName("tb_pagamento_pkey");

                    b.HasIndex("CdCliente");

                    b.ToTable("tb_pagamento", (string)null);
                });

            modelBuilder.Entity("Emergencia.Infrastructure.Models.Cliente", b =>
                {
                    b.Property<Guid>("Id")
                        .HasColumnType("uuid");

                    b.Property<string>("Email")
                        .HasColumnType("text");

                    b.Property<string>("NmCliente")
                        .HasColumnType("text");

                    b.Property<string>("NrCpf")
                        .HasColumnType("text");

                    b.HasKey("Id")
                        .HasName("tb_cliente_pkey");

                    b.ToTable("tb_cliente", (string)null);
                });

            modelBuilder.Entity("Emergencia.Infrastructure.Models.Evento", b =>
                {
                    b.Property<Guid>("Id")
                        .HasColumnType("uuid");

                    b.Property<DateTime?>("dtEvento")
                        .HasColumnType("timestamp with time zone");

                    b.Property<bool>("flAtivo")
                        .HasColumnType("boolean");

                    b.Property<string>("nmEvento")
                        .HasColumnType("text");

                    b.Property<decimal?>("vlEvento")
                        .HasColumnType("numeric");

                    b.HasKey("Id")
                        .HasName("tb_evento_pkey");

                    b.ToTable("tb_evento", (string)null);
                });

            modelBuilder.Entity("Emergencia.Domain.Entities.Inscricao", b =>
                {
                    b.HasOne("Emergencia.Infrastructure.Models.Cliente", "Cliente")
                        .WithMany("Inscricoes")
                        .HasForeignKey("CdCliente")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired()
                        .HasConstraintName("fk_inscricao_tb_cliente_1");

                    b.HasOne("Emergencia.Infrastructure.Models.Evento", "Evento")
                        .WithMany("Inscricoes")
                        .HasForeignKey("CdEvento")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired()
                        .HasConstraintName("fk_evento_inscricao");

                    b.Navigation("Cliente");

                    b.Navigation("Evento");
                });

            modelBuilder.Entity("Emergencia.Domain.Entities.Pagamento", b =>
                {
                    b.HasOne("Emergencia.Infrastructure.Models.Cliente", "Cliente")
                        .WithMany("Pagamentos")
                        .HasForeignKey("CdCliente")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired()
                        .HasConstraintName("fk_tb_pagamento_tb_cliente_1");

                    b.Navigation("Cliente");
                });

            modelBuilder.Entity("Emergencia.Infrastructure.Models.Cliente", b =>
                {
                    b.Navigation("Inscricoes");

                    b.Navigation("Pagamentos");
                });

            modelBuilder.Entity("Emergencia.Infrastructure.Models.Evento", b =>
                {
                    b.Navigation("Inscricoes");
                });
#pragma warning restore 612, 618
        }
    }
}
