using Dominio.Modelos;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Utils.TratamentoEvento;

namespace Repositorio.Repositorio
{
    public class RepositorioVenda : IRepositorioVenda
    {
        private readonly Context _context;
        public RepositorioVenda(Context context)
        {
            _context = context;
        }

        public ContextoEventoDto Salvar(List<Venda> vendas)
        {
            try
            {
                _context.Vendas.AddRange(vendas);
                _context.SaveChanges();
                return ContextoEventoDto.CriarSucesso("Vendas salvas com suvesso", null);
            }
            catch (Exception)
            {
                return ContextoEventoDto.CriarErro(ErroEnum.ConexaoBanco,"Ocorreu um erro ao salvar as vendas");
            }
        }

        public ContextoEventoDto Buscar()
        {
            try
            {
                
               return ContextoEventoDto.CriarSucesso("Busca Realizada com Sucesso",
                   _context.Vendas.Where(x => x.Processado == false).ToList());
            }
            catch (Exception ex)
            {
                return ContextoEventoDto.CriarErro(ErroEnum.ConexaoBanco, "Ocorreu um erro ao buscar as vendas");
            }
        }

        public ContextoEventoDto Atualizar(List<Venda> vendas)
        {
                try
                {
                    _context.Vendas.UpdateRange(vendas);
                    _context.SaveChanges();
                    return ContextoEventoDto.CriarSucesso("Vendas atualizadas com sucesso", null);
                }
                catch (Exception ex)
                {
                    return ContextoEventoDto.CriarErro(ErroEnum.ConexaoBanco, "Ocorreu um erro ao atualizar as vendas");
                }
        }
    }
}
