# ProcessoCalculoLucroVendedor
#Objetivo
O objetivo desse projeto é simular um ambiente real de processamento de dados de venda. Como é uma simulação é possível
entender esse software em 3 partes

-1 Simulação
Nessa parte vendas simuladas são adicionadas no banco de dados com a flag Processado = false;
é possível ver essa dinâmica no arquivo Dominio.Modelo.Venda.

São criados de 100 a 500 vendas.
Os dados de venda são adicionados na tabela dbo.Venda

Além do status processado uma venda possui a data da venda, o valor da venda, o id do vendedor e um enum da
forma de pagamento.

-2 Processamento
Nessa parte os dados de venda que possuem o status Processado = false são recuperados do banco de dados.
Então aplica-se a seguinte regra de negócio:

-Vendedores bronze recebem um lucro de 10% no valor de cada venda
-Vendedores prata recebem um lucro de 20% no valor de cada venda
-Vendedores ouro recebem um lucro de 30% no valor de cada venda

É possível ver esse cálculo no arquivo Utils.Calculos.CalculoLucro(...)
O teste para esse calculo está no arquivo TestesUnitarios.TesteCalculoLucro(...)

Então após o calculo ser realizado a opção de processado daquelas vendas base para o calculo
é atualizada para true. Ou seja, Processado = true; 
As vendas utilizadas são então atualizadas no banco de dados.
É possível ver essa dinâmica no arquivo ProcessoCalculoLucroVendedor.Servicos.ServicoVenda.Atualizar(...)

-3 Mensageria
Após esse processo ser finalizado uma mensagem é enviada para a fila ProcessoCalculo contendo informações de
quantos dados foram processados e o Guid da operação.

Ao finalizar o processo tudo se repete por recursão, simulando um ambiente de vendas que funcioa 24 horas por dia.
A recursão está em ProcessoCalculoLucroVendedor.Program.IniciarSimulacao(...)

#Pré Requisitos para rodar
-1 Dotnet 7.0.1 Sdk
https://dotnet.microsoft.com/en-us/download/dotnet/7.0
-2 Ide - Visual Studio 2022 (sugestão)
https://visualstudio.microsoft.com/vs/community/
-3 RabbitMq
-Erlang
https://www.erlang.org/downloads
-RabbitMq
https://www.rabbitmq.com/docs/download
-4 Instalar dependências declaradas no projeto
-Entity framework, entity design, rabbitMq client...

#Imagens do projeto rodando:

Logs no console:
![image](https://github.com/MateusMo/ProcessoCalculoLucroVendedor/assets/71354894/429cfab0-ce74-4e3f-b0ea-c1512a4da4fa)

Tabela de lucro:
![image](https://github.com/MateusMo/ProcessoCalculoLucroVendedor/assets/71354894/90ffbed2-bab4-45ea-b9ba-da2b72799e56)

Tabela de venda:
![image](https://github.com/MateusMo/ProcessoCalculoLucroVendedor/assets/71354894/488164c7-20f2-4a9e-ba9a-693903d01de2)

Tabela de vendedor:
![image](https://github.com/MateusMo/ProcessoCalculoLucroVendedor/assets/71354894/ec9e5f79-fcca-45b6-8592-3a1871b81629)

Mensagens no rabbitMq:

-Fila:
![image](https://github.com/MateusMo/ProcessoCalculoLucroVendedor/assets/71354894/09ce36e1-8757-43e2-81f6-94039ed694eb)

-Mensagem:
![image](https://github.com/MateusMo/ProcessoCalculoLucroVendedor/assets/71354894/b3124610-caec-4fa1-a13f-40b833f3a901)



