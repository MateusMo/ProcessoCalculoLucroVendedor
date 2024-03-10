using Dominio.Modelos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Utils.TratamentoEvento;

namespace Repositorio.Repositorio
{
    public interface IRepositorioVenda
    {
        ContextoEventoDto Salvar(List<Venda> vendas);
        ContextoEventoDto Atualizar(List<Venda> vendas);

        ContextoEventoDto Buscar();
    }
}
