using Dominio.Enum;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dominio.Modelos
{
    public class Vendedor
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public int Matricula { get; set; }
        public string Email { get; set; }
        public bool Sexo { get; set; }
        public ClasseVendedorEnum ClasseVendedorEnum { get; set; }

        //Propriedades de navegação
        public List<Lucro> Lucros { get; set; }
        public List<Venda> Vendas { get; set; }
    }
}
