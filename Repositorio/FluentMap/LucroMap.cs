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
    public class LucroMap : IEntityTypeConfiguration<Lucro>
    {
        public void Configure(EntityTypeBuilder<Lucro> builder)
        {
            // Tabela
            builder.ToTable("Lucro");

            // Chave Primária
            builder.HasKey(x => x.Id);

            // Identity
            builder.Property(x => x.Id)
                .ValueGeneratedOnAdd()
                .UseIdentityColumn();
            
            builder.Property(x => x.DataLucro)
                .IsRequired()
                .HasColumnName("DataLucro")
                .HasColumnType("DateTime");

            builder.Property(x => x.MeioPagamentoEnum)
                .IsRequired()
                .HasColumnName("MeioPagamentoEnum")
                .HasColumnType("smallint");

            builder.Property(x => x.Valor)
                .IsRequired()
                .HasColumnName("Valor")
                .HasColumnType("Float");

            builder.Property(x => x.VendedorId)
                .IsRequired()
                .HasColumnName("VendedorId")
                .HasColumnType("int");
        }
    }
}
