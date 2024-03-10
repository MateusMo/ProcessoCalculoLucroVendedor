using Dominio.Enum;
using Dominio.Modelos;
using Microsoft.EntityFrameworkCore;
using Repositorio.Seeders;
using System.Globalization;

namespace Repositorio.Seeders
{
    public class Seeder
    {
        public static List<Vendedor> CriarVendedores()
        {
            var vendedores = new List<Vendedor>();
            var random = new Random();
            for(var i = 1; i <= 10; i ++)
            {
                var vendedor = new Vendedor()
                {
                    Id = i + 1,
                    ClasseVendedorEnum = (ClasseVendedorEnum)random.Next(1, 3),
                    Email = $"vendedor{i}@dominio.com",
                    Matricula = int.Parse($"12345678"),
                    Nome = "Vendedor" + i,
                    Sexo = i % 2 == 0 ? true : false
                };
                vendedores.Add(vendedor);
            }
            return vendedores;
        }

        public static List<Venda> CriarVendas()
        {
            var vendas = new List<Venda>();
            var random = new Random();

            for (var i = 1; i <= 2000; i++)
            {
                var venda = new Venda()
                {
                    Id = i,
                    DataVenda = DateTime.Now,
                    MeioPagamentoEnum = (MeioPagamentoEnum)random.Next(1, 5),
                    Valor = (decimal)random.NextDouble() * (1000 - 100),
                    VendedorId = random.Next(1,10),
                };

                vendas.Add(venda);
            }

            return vendas;
        }
    }

}
