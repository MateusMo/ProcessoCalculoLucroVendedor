using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Utils.TratamentoEvento
{
    public class ContextoEventoDto
    {
        public TipoEvento TipoEvento { get; set; }
        public MensagemEvento Mensagem { get; set; }
        public object? Objeto { get; set; }

        public static ContextoEventoDto CriarErro(ErroEnum erroEnum, string mensagem)
        {
            return new ContextoEventoDto
            {
                TipoEvento = TipoEvento.Erro,
                Mensagem = new MensagemEvento
                {
                    Guid = Guid.NewGuid(),
                    Data = DateTime.Now,
                    ErroEnum = erroEnum,
                    Mensagem = mensagem
                }
            };
        }

        public static ContextoEventoDto CriarSucesso(string mensagem,object? objeto)
        {
            return new ContextoEventoDto
            {
                Objeto = objeto,
                TipoEvento = TipoEvento.Sucesso,
                Mensagem = new MensagemEvento
                {
                    Guid = Guid.NewGuid(),
                    Data = DateTime.Now,
                    Mensagem = mensagem
                }
            };
        }
    }

    public class MensagemEvento
    {
        public Guid Guid { get; set; }
        public DateTime Data { get; set; }
        public ErroEnum? ErroEnum { get; set; }
        public string Mensagem { get; set; }
    }

    public enum ErroEnum
    {
       ConexaoBanco = 1,
       Mensageria = 2,
       Outro = 3
    }
    public enum TipoEvento
    {
        Erro,
        Sucesso
    }
}
