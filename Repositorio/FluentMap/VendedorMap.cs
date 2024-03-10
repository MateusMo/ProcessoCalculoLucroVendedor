using Dominio.Modelos;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repositorio.FluentMap
{
    public class VendedorMap : IEntityTypeConfiguration<Vendedor>
    {
        public void Configure(EntityTypeBuilder<Vendedor> builder)
        {
            // Tabela
            builder.ToTable("Vendedor");

            // Chave Primária
            builder.HasKey(x => x.Id);

            // Identity
            builder.Property(x => x.Id)
                .ValueGeneratedOnAdd()
                .UseIdentityColumn();

            builder.Property(x => x.Nome)
                .IsRequired()
                .HasColumnName("Name")
                .HasColumnType("NVARCHAR")
                .HasMaxLength(80);

            builder.Property(x => x.Matricula)
                .IsRequired()
                .HasColumnName("Matricula")
                .HasColumnType("int")
                .HasMaxLength(8);

            builder.Property(x => x.Email)
                    .IsRequired()
                    .HasColumnName("Email")
                    .HasColumnType("NVARCHAR")
                    .HasMaxLength(200);

            builder.Property(x => x.Sexo)
                .IsRequired()
                .HasColumnName("Sexo")
                .HasColumnType("smallint");

            builder.Property(x => x.ClasseVendedorEnum)
                .IsRequired()
                .HasColumnName("ClassVendedor")
                .HasColumnType("smallint");

            builder.HasMany(x => x.Lucros)
                .WithOne(x => x.Vendedor)
                .OnDelete(DeleteBehavior.Restrict);

            builder.HasMany(x => x.Vendas)
                .WithOne(x => x.Vendedor)
                .OnDelete(DeleteBehavior.Restrict);
        }

    }
}
