
using Repositorio.Repositorio;
using Utils.TratamentoEvento;

namespace ProcessoCalculoLucroVendedor.Servico
{
    public class ServicoVendedor : IServicoVendedor
    {
        private readonly IRepositorioVendedor _IRepositorioVendedor;
        public ServicoVendedor(IRepositorioVendedor IRepositorioVendedor)
        {
            _IRepositorioVendedor = IRepositorioVendedor;
        }

        public ContextoEventoDto BuscarVendedores()
        {
            return _IRepositorioVendedor.GetVendedores();
        }
    }
}
