using Dominio.Enum;
using Dominio.Modelos;
using Repositorio.Repositorio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Utils.TratamentoEvento;

namespace ProcessoCalculoLucroVendedor.Servico
{
    public class ServicoVenda : IServicoVenda
    {
        private readonly IRepositorioVenda _repositorioVenda;
        public ServicoVenda(IRepositorioVenda repositorioVenda)
        {
            _repositorioVenda = repositorioVenda;
        }

        public ContextoEventoDto Buscar()
        {
            try
            {
                return _repositorioVenda.Buscar();
            }
            catch (Exception ex)
            {
                return ContextoEventoDto.CriarErro(ErroEnum.ConexaoBanco, ex.Message);
            }
        }

        public ContextoEventoDto Atualizar(List<Venda> vendas)
        {
            vendas.ForEach((ven) =>
            {
                ven.Processado = true;
            });
            
            return _repositorioVenda.Atualizar(vendas);
        }

            public bool PopularVendas()
        {
            var vendas = Utils.Calculos.CalcularVendas();
            var eventoSalvarVendas = _repositorioVenda.Salvar(vendas);
            
            if(eventoSalvarVendas.TipoEvento == TipoEvento.Erro)
                return false;
                
            return true;   
        }

        
    }
}
