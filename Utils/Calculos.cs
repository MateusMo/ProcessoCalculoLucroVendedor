using Dominio.Dto;
using Dominio.Enum;
using Dominio.Modelos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Utils
{
    public class Calculos
    {
        public static List<Lucro> CalculoLucro(List<ContextoVendaDto> ContextoVendaDto)
        {
            var lucros = new List<Lucro>();
            ContextoVendaDto.ForEach((conVen) =>
            {
                var lucro = new Lucro()
                {
                    DataLucro = DateTime.Now.Date,
                    MeioPagamentoEnum = conVen.Venda.MeioPagamentoEnum,
                    VendedorId = conVen.Vendedor.Id,
                };

                if (conVen.Vendedor.ClasseVendedorEnum == Dominio.Enum.ClasseVendedorEnum.Bronze)
                {
                    lucro.Valor = conVen.Venda.Valor * 0.1m;
                }
                if (conVen.Vendedor.ClasseVendedorEnum == Dominio.Enum.ClasseVendedorEnum.Prata)
                {
                    lucro.Valor = conVen.Venda.Valor * 0.2m;
                }
                if (conVen.Vendedor.ClasseVendedorEnum == Dominio.Enum.ClasseVendedorEnum.Ouro)
                {
                    lucro.Valor = conVen.Venda.Valor * 0.3m;
                }

                lucros.Add(lucro);
            });

            return lucros;
        }
        public static List<Venda> CalcularVendas()
        {
            var vendas = new List<Venda>();
            var random = new Random();
            var novasVendasVolume = random.Next(100, 500);
            for (var i = 0; i <= novasVendasVolume; i++)
            {
                var venda = new Venda()
                {
                    DataVenda = DateTime.Today,
                    MeioPagamentoEnum = (MeioPagamentoEnum)random.Next(1, 5),
                    Valor = (decimal)(random.NextDouble() * (1000 - 100) + 100),
                    VendedorId = random.Next(2, 11)
                };
                vendas.Add(venda);
            }
            return vendas;
        }
    }
}
