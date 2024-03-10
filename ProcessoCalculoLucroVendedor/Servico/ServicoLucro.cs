using Dominio.Dto;
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
    public class ServicoLucro : IServicoLucro
    {
        private readonly IRepositorioLucro _IRepositorioLucro;

        private readonly IServicoVendedor _ServicoVendedor;
        private readonly IServicoVenda _IServicoVenda;
        public ServicoLucro(IRepositorioLucro IRepositorioLucro,
            IServicoVendedor servicoVendedor,
            IServicoVenda IServicoVenda)
        {
            _IRepositorioLucro = IRepositorioLucro;
            _ServicoVendedor = servicoVendedor;
            _IServicoVenda = IServicoVenda;
        }
        public ContextoEventoDto Processar()
        {
            var contextoVendas = CriarContextoVenda();
            var lucros = Utils.Calculos.CalculoLucro(contextoVendas);
            var eventoSalvarLucros = _IRepositorioLucro.Salvar(lucros);
            var eventoAtualizarVendas = _IServicoVenda.Atualizar(contextoVendas.Select(x => x.Venda).ToList());

            return ContextoEventoDto.CriarSucesso("Lucros criados com sucesso",lucros);
        }

        
        public ContextoEventoDto BuscarVendedores()
        {
            var contexto = _ServicoVendedor.BuscarVendedores();
            //adicionar tratamento
            if (contexto.TipoEvento == TipoEvento.Erro)
            {

            }

            return contexto;
        }

        public ContextoEventoDto BuscarVendas()
        {
            var contexto = _IServicoVenda.Buscar();
            //adicionar tratamento
            if (contexto.TipoEvento == TipoEvento.Erro)
            {

            }

            return contexto;
        }


        public List<ContextoVendaDto> CriarContextoVenda()
        {
            var contextoVendas = new List<ContextoVendaDto>();
            var Vendedores = BuscarVendedores().Objeto as List<Vendedor>;
            var Vendas = BuscarVendas().Objeto as List<Venda>;

            if (Vendedores == null || Vendas == null)
            {

            }

            Vendas.ForEach((venda) =>
            {
                var vendedor = Vendedores
                .FirstOrDefault(vendedor => vendedor.Id == venda.VendedorId);

                var contextoVenda = new ContextoVendaDto()
                {
                    Venda = venda,
                    Vendedor = vendedor
                };

                contextoVendas.Add(contextoVenda);
            });

            return contextoVendas;
        }
    }
}
