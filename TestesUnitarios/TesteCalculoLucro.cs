using Dominio.Dto;
using Dominio.Modelos;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.VisualStudio.TestPlatform.TestHost;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace TestesUnitarios
{
    [TestClass]
    public class TesteCalculoLucro
    {
        [TestMethod]
        public void TestarCalculoHierarquiaPorcentagem()
        {
            var contextoVendaDto = new List<ContextoVendaDto>()
            {
                new ContextoVendaDto()
                {
                    Venda = new Venda()
                    {
                        Id = 1,
                        DataVenda = DateTime.Now,
                        MeioPagamentoEnum = Dominio.Enum.MeioPagamentoEnum.Pix,
                        Processado = false,
                        Valor = 100,
                        VendedorId = 1,
                    },
                    Vendedor = new Vendedor()
                    {
                        Id = 1,
                        ClasseVendedorEnum = Dominio.Enum.ClasseVendedorEnum.Bronze,
                        Email = "teste@teste.com",
                        Matricula = 12345678,
                        Nome = "Teste1",
                        Sexo = true
                    }
                },
                new ContextoVendaDto()
                {
                    Venda = new Venda()
                    {
                        Id = 2,
                        DataVenda = DateTime.Now,
                        MeioPagamentoEnum = Dominio.Enum.MeioPagamentoEnum.Pix,
                        Processado = false,
                        Valor = 100,
                        VendedorId = 2,
                    },
                    Vendedor = new Vendedor()
                    {
                        Id = 2,
                        ClasseVendedorEnum = Dominio.Enum.ClasseVendedorEnum.Prata,
                        Email = "teste@teste.com",
                        Matricula = 12345678,
                        Nome = "Teste1",
                        Sexo = true
                    }
                },
                new ContextoVendaDto()
                {
                    Venda = new Venda()
                    {
                        Id = 3,
                        DataVenda = DateTime.Now,
                        MeioPagamentoEnum = Dominio.Enum.MeioPagamentoEnum.Pix,
                        Processado = false,
                        Valor = 100,
                        VendedorId = 3,
                    },
                    Vendedor = new Vendedor()
                    {
                        Id = 3,
                        ClasseVendedorEnum = Dominio.Enum.ClasseVendedorEnum.Ouro,
                        Email = "teste@teste.com",
                        Matricula = 12345678,
                        Nome = "Teste1",
                        Sexo = true
                    }
                }
            };
            var lucros = Utils.Calculos.CalculoLucro(contextoVendaDto);


            Assert.IsNotNull(lucros, "Lucros list should not be null");
            Assert.AreEqual(3, lucros.Count, "Expected 3 lucros in the list");
            Assert.AreEqual(10, lucros[0].Valor, "Expected value for the first lucro");
            Assert.AreEqual(20, lucros[1].Valor, "Expected value for the second lucro");
            Assert.AreEqual(30, lucros[2].Valor, "Expected value for the third lucro");
        }
    }
}