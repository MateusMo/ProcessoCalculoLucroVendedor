﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Utils.TratamentoEvento;

namespace ProcessoCalculoLucroVendedor.Servico
{
    public interface IServicoVendedor
    {
        public ContextoEventoDto BuscarVendedores();
    }
}
