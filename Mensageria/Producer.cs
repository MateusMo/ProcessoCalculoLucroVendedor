using Dominio.Modelos;
using RabbitMQ.Client;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Utils.TratamentoEvento;

namespace Mensageria
{
    public class Producer : IProducer
    {
        public ContextoEventoDto Produce(ContextoEventoDto contexto)
        {
            try
            {

                var factory = new ConnectionFactory()
                {
                    HostName = "localhost"
                };

                var lucros = contexto.Objeto as List<Lucro>;
                var totalEventos = lucros.Count();

                using (var connection = factory.CreateConnection())
                using (var channel = connection.CreateModel())
                {
                    channel.QueueDeclare("ProcessoCalculo", false, false, false, null);
                    string message = @$"ProcessoCalculoLucroVendedor: Um total de 
                    {totalEventos} lucros foram processados. Guid {contexto.Mensagem.Guid}";
                    var body = Encoding.UTF8.GetBytes(message);
                    channel.BasicPublish("", "ProcessoCalculo", null, body);
                    Console.WriteLine($"Send Message {message}");
                }

                return ContextoEventoDto.CriarSucesso("RabbitMq: Mensagem enviada", null);
            }
            catch (Exception ex)
            {
                return ContextoEventoDto.CriarSucesso("RabbitMq: Mensagem enviada", ex);

            }
        }
    }
}
