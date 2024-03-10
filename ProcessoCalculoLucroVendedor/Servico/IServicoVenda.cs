using Dominio.Modelos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Utils.TratamentoEvento;

namespace ProcessoCalculoLucroVendedor.Servico
{
    public interface IServicoVenda
    {
        public ContextoEventoDto Buscar();
        public ContextoEventoDto Atualizar(List<Venda> vendas);
        public bool PopularVendas();
    }
}
