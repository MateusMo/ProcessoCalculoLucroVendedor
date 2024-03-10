using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Utils.TratamentoEvento;

namespace Repositorio.Repositorio
{
    public interface IRepositorioVendedor
    {
        public ContextoEventoDto GetVendedores();
    }
}
