using Dominio.Modelos;
using Mensageria;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using ProcessoCalculoLucroVendedor.Servico;
using Repositorio;
using Repositorio.Repositorio;
using System;

public class Program
{
    static void Main()
    {
        var serviceProvider = ConfigurarServicos();

        IniciarSimulacao(serviceProvider);
    }

    static void IniciarSimulacao(ServiceProvider serviceProvider)
    {
        var statusVendas = serviceProvider.GetService<IServicoVenda>().PopularVendas();
        var lucrosSalvos = serviceProvider.GetService<IServicoLucro>().Processar();
        var statusMensageria = serviceProvider.GetService<IProducer>().Produce(lucrosSalvos);

        if(lucrosSalvos.TipoEvento != Utils.TratamentoEvento.TipoEvento.Erro
            && statusMensageria.TipoEvento != Utils.TratamentoEvento.TipoEvento.Erro
            && statusVendas == true)
        {
            var obj = lucrosSalvos.Objeto as List<Lucro>;
            var sucessos = $@"status popular vendas: {statusVendas}, status processar: {lucrosSalvos.Mensagem}, 
totalProcessados: {obj.Count()}, status mensageria: {statusMensageria.Mensagem}";

            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine(sucessos);
            Console.WriteLine();
            IniciarSimulacao(serviceProvider);
        }
        else{
            var erros = $@"status popular vendas: {statusVendas}, 
                        status processar: {lucrosSalvos.Mensagem}
                        status mensageria: {statusMensageria.Mensagem}";
            
            Console.WriteLine(erros);
        }

    }

    public static ServiceProvider ConfigurarServicos()
    {
        var serviceCollection = new ServiceCollection();

        serviceCollection.AddDbContext<Context>(options =>
            options.UseSqlServer("Server=COSMOS;Database=CalculoLucroVendedor;Trusted_Connection=true;TrustServerCertificate=true;"));
        
        //Serviços
        serviceCollection.AddTransient<IServicoVendedor, ServicoVendedor>();
        serviceCollection.AddTransient<IServicoVenda, ServicoVenda>();
        serviceCollection.AddTransient<IServicoLucro, ServicoLucro>();
        //Repositorios
        serviceCollection.AddTransient<IRepositorioVendedor, RepositorioVendedor>();
        serviceCollection.AddTransient<IRepositorioVenda, RepositorioVenda>();
        serviceCollection.AddTransient<IRepositorioLucro, RepositorioLucro>();
        //Mensageria
        serviceCollection.AddTransient<IProducer, Producer>();

        var serviceProvider = serviceCollection.BuildServiceProvider();
        return serviceProvider;
    }
}