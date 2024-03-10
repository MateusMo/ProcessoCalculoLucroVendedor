using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Utils.TratamentoEvento;

namespace Repositorio.Repositorio
{
    public class RepositorioVendedor : IRepositorioVendedor
    {
        private readonly Context _context;
        public RepositorioVendedor(Context context)
        {
            _context = context;
        }

        public ContextoEventoDto GetVendedores()
        {
            try
            {
                return ContextoEventoDto.CriarSucesso("Vendedores recuperados com sucesso",
                    _context.Vendedores.ToList());
            }
            catch (Exception ex)
            {
                return ContextoEventoDto.CriarErro(ErroEnum.ConexaoBanco, ex.Message);
            }
        }
    }
}
