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
    public class VendaMap : IEntityTypeConfiguration<Venda>
    {
        void IEntityTypeConfiguration<Venda>.Configure(EntityTypeBuilder<Venda> builder)
        {
            // Tabela
            builder.ToTable("Venda");

            // Chave Primária
            builder.HasKey(x => x.Id);

            // Identity
            builder.Property(x => x.Id)
                .ValueGeneratedOnAdd()
                .UseIdentityColumn();
         
            builder.Property(x => x.Valor)
                .IsRequired()
                .HasColumnName("Valor")
                .HasColumnType("Float");


            builder.Property(x => x.DataVenda)
                .IsRequired()
                .HasColumnName("DataVenda")
                .HasColumnType("DateTime");

            builder.Property(x => x.MeioPagamentoEnum)
                    .IsRequired()
                    .HasColumnName("MeioPagamento")
                    .HasColumnType("smallint");

            builder.Property(x => x.VendedorId)
                .IsRequired()
                .HasColumnName("VendedorId")
                .HasColumnType("int");

            builder.Property(x => x.Processado)
                .IsRequired()
                .HasColumnName("Processado")
                .HasColumnType("smallint");
        }
    }
}
