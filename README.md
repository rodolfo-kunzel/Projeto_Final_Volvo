# Projeto_Final_Volvo

## Introdução
Este projeto consiste em uma WebAPI para o gerenciamento de uma concessionária. Permite o registro de caminhões, clientes, pedidos e geração de faturamento mensal. Foi desenvolvido utilizando _Clean Architecture_ para promover a separação de preocupações e facilitar a manutenção e escalabilidade do código. Além disso, conta com um sistema de logs para registrar erros em arquivos diários, garantindo a rastreabilidade e resolução de problemas de forma eficiente.
 
## Tecnologias Utilizadas
Linguagem de Programação: .NET (8.0.1)

Framework: .NET Core

Banco de Dados: SQL Server

ORM (Object-Relational Mapping): Entity Framework (8.0.1)

## Configuração do Ambiente
Para configurar o ambiente de desenvolvimento local, siga os passos abaixo:

### Clonar o Repositório:
`git clone` https://github.com/rodolfo-kunzel/Projeto_Final_Volvo.git

### Instalar Dependências:
Primeiramente acesse o local do projeto.

Em seguida utiliza o comando: dotnet restore

### Configurar Banco de Dados:
Primeiramente acesse o arquivo ..\API\appsettings.Development.json

Em "ConnectionStrings" é possível configurar seu acesso no Windows com: `"NomeDoAcesso": "Server:Caminho;Database:NomeDoDB;Trusted_Connection=True;MultipleActiveResultSets=true;TrustServerCertificate=True;"`

Após acesse o arquivo API\Program.cs e altere `context.UseSqlServer(config.GetConnectionString("NomeDoAcesso"))`

### Executar o Projeto:

`dotnet run` 

Ou `dotnet watch run` para abertura direta do swagger

##Estrutura do Projeto
O projeto segue uma arquitetura limpa, organizada em camadas, com o objetivo de separar as responsabilidades de cada componente. A estrutura do projeto é composta por:

API: Responsável por fornecer a interface de comunicação com o mundo externo, ou seja, a camada de apresentação. Aqui estão os controladores da API que recebem as solicitações HTTP e direcionam para os casos de uso apropriados na camada de aplicação.

Application: Contém os casos de uso da aplicação, representando as operações que podem ser realizadas no sistema. Estes casos de uso implementam as regras de negócio e coordenam as chamadas aos serviços do domínio.

Domain: Define as entidades principais do sistema, representando os conceitos do domínio do negócio. Aqui também estão os serviços do domínio, que implementam as operações específicas relacionadas a essas entidades.

Persistence: Responsável por lidar com a persistência de dados. Aqui estão os repositórios que são responsáveis pela interação com o banco de dados ou qualquer outro mecanismo de armazenamento utilizado pela aplicação.

## Vídeo de Explicação e Funcionamento
Confira nosso vídeo de explicação e funcionamento do projeto o video contém 10 minutos para uma visão geral do projeto e uma demonstração de algumas funcionalidade:

[Vídeo de Explicação do Projeto](https://drive.google.com/drive/folders/18lbReVF90fazEK8qozIMS17fIIwC7Wa0?usp=drive_link)

## Autores
André Igarashi

Rodolfo Kunzel
