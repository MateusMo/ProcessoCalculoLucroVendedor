using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Utils.TratamentoEvento;

namespace Mensageria
{
    public interface IProducer
    {
        public ContextoEventoDto Produce(ContextoEventoDto contexto);

    }
}
