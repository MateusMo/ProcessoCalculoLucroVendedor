﻿using Dominio.Enum;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dominio.Modelos
{
    public class Lucro
    {
        public int Id { get; set; }
        public decimal Valor { get; set; }
        public MeioPagamentoEnum MeioPagamentoEnum { get; set; }
        public DateTime DataLucro { get; set; }
        public int VendedorId { get; set; }


        //Propriedades de navegação
        public Vendedor Vendedor { get; set; }
    }
}
