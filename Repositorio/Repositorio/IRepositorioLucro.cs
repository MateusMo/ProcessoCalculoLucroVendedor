using Dominio.Modelos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Utils.TratamentoEvento;

namespace Repositorio.Repositorio
{
    public interface IRepositorioLucro
    {
        ContextoEventoDto Salvar(List<Lucro> lucros);
        ContextoEventoDto Buscar(DateTime date);
    }
}
