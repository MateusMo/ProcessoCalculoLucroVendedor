using Dominio.Modelos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dominio.Dto
{
    public class ContextoVendaDto
    {
        public Vendedor Vendedor { get; set; }
        public Venda Venda { get; set; }
    }
}
