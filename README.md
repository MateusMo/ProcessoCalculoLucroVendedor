# ProcessoCalculoLucroVendedor

## Objetivo

O objetivo desse projeto é simular um ambiente real de processamento de dados de venda. O software pode ser entendido em 3 partes distintas.

### 1. Simulação
Nessa fase, vendas simuladas são adicionadas no banco de dados com a flag `Processado = false`. A dinâmica pode ser observada no arquivo `Dominio.Modelo.Venda`.

- São criadas de 100 a 500 vendas.
- Os dados de venda são adicionados na tabela `dbo.Venda`.

Cada venda possui: 
- Status processado
- Data da venda
- Valor da venda
- ID do vendedor
- Enum da forma de pagamento

### 2. Processamento
Nessa etapa, os dados de venda com `Processado = false` são recuperados do banco de dados. Aplica-se a seguinte regra de negócio:

- Vendedores bronze recebem um lucro de 10% no valor de cada venda.
- Vendedores prata recebem um lucro de 20% no valor de cada venda.
- Vendedores ouro recebem um lucro de 30% no valor de cada venda.

O cálculo é realizado no arquivo `Utils.Calculos.CalculoLucro(...)`. O teste para esse cálculo está no arquivo `TestesUnitarios.TesteCalculoLucro(...)`. Após o cálculo, a flag `Processado` é atualizada para `true`, indicando que a venda foi processada. A atualização ocorre no banco de dados e está descrita no arquivo `ProcessoCalculoLucroVendedor.Servicos.ServicoVenda.Atualizar(...)`.

### 3. Mensageria
Após o processamento, uma mensagem é enviada para a fila `ProcessoCalculo` contendo informações sobre quantos dados foram processados e o GUID da operação.

Ao finalizar o processo, tudo se repete por recursão, simulando um ambiente de vendas que funciona 24 horas por dia. A recursão está em `ProcessoCalculoLucroVendedor.Program.IniciarSimulacao(...)`.

## Pré Requisitos para rodar

1. Dotnet 7.0.1 SDK
   
   - [Download Dotnet 7.0.1 SDK](https://dotnet.microsoft.com/en-us/download/dotnet/7.0)

2. IDE - Visual Studio 2022 (sugestão)
   
   - [Download Visual Studio 2022](https://visualstudio.microsoft.com/vs/community/)

3. RabbitMQ
   
   - Erlang: [Download Erlang](https://www.erlang.org/downloads)
   - RabbitMQ: [Download RabbitMQ](https://www.rabbitmq.com/docs/download)

4. Instalar dependências declaradas no projeto
   - Entity Framework, Entity Design, RabbitMQ client, etc.

## Imagens do projeto rodando:

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



