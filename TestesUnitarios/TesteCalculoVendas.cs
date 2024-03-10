using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestesUnitarios
{
    [TestClass]
    public class TesteCalculoVendas
    {
        [TestMethod]
        public void TestarPropriedadesVendas()
        {
            var vendas = Utils.Calculos.CalcularVendas();

            Assert.IsNotNull(vendas);
            Assert.IsTrue(vendas.Count >= 99 && vendas.Count <= 499,"Expected a length between 100 and 500");
            Assert.IsTrue(vendas[0].DataVenda == DateTime.Today,$"Expected a date in this date: {DateTime.Today}");
            Assert.IsTrue(vendas[0].Processado == false,"Expected a false status");
            Assert.IsTrue(vendas[0].VendedorId > 1 && vendas[0].VendedorId < 12,"Expected ids between 2 and 11");
        }
    }
}
