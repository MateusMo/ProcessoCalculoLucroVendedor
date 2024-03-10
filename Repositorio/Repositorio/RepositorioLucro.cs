using Dominio.Modelos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Utils.TratamentoEvento;

namespace Repositorio.Repositorio
{
    public class RepositorioLucro : IRepositorioLucro
    {
        private readonly Context _context;
        public RepositorioLucro(Context context)
        {
            _context = context;
        }

        public ContextoEventoDto Salvar(List<Lucro> lucros)
        {
            try
            {
                _context.Lucros.AddRange(lucros);
                _context.SaveChanges();

                return ContextoEventoDto.CriarSucesso("Processo Finalizado",null);
            }
            catch (Exception)
            {
                return ContextoEventoDto.CriarErro(ErroEnum.ConexaoBanco, "Falha no processo");
            }
        }

        public ContextoEventoDto Buscar(DateTime date)
        {
            try
            {
                return ContextoEventoDto
                    .CriarSucesso("Dados Recuperados com sucesso",
                    _context.Lucros
                    .Where(l => l.DataLucro.Date == date.Date)
                    .ToList());

            }
            catch (Exception)
            {
                return ContextoEventoDto
                    .CriarErro(ErroEnum.ConexaoBanco, "Falha ao buscar dados");
            }
        }
    }
}
