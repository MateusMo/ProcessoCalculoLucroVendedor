using Dominio.Enum;
using Dominio.Modelos;
using Microsoft.EntityFrameworkCore;
using Repositorio.FluentMap;
using Repositorio.Seeders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace Repositorio
{
    public class Context : DbContext
    {
        public DbSet<Lucro> Lucros { get; set; }
        public DbSet<Venda> Vendas { get; set; }
        public DbSet<Vendedor> Vendedores { get; set; }

        public Context(DbContextOptions<Context> options) : base(options)
        {
        }

        //para criar migrations descomente essa linha e comente o construtor
        //para rodar o programa faça o inverso

        //protected override void OnConfiguring(DbContextOptionsBuilder options)
        //   => options.UseSqlServer("Server=COSMOS;Database=CalculoLucroVendedor;Trusted_Connection=true;TrustServerCertificate=true;");

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //Fluent
            modelBuilder.ApplyConfiguration(new LucroMap());
            modelBuilder.ApplyConfiguration(new VendaMap());
            modelBuilder.ApplyConfiguration(new VendedorMap());

            //Seeds
            //Preciso criar esses seeders
            //pois não tenho dados de contexto real
            modelBuilder.Entity<Vendedor>().HasData(Seeder.CriarVendedores());
            //modelBuilder.Entity<Venda>().HasData(Seeder.CriarVendas());
        }
    }
}
