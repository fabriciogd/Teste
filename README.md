# Teste

## Projeto separado em camadas

Domínio: A camada geralmente contém lógica de negócio e entidades.
Aplicação: A camada de aplicativo contem interfaces e tipos.
Apresentação: A camada de apresentação é onde está localizado o projeto aonde o usuário pode acessar.
Infraestrutura: A camada de infraestrutura é aonde fica localizado o acesso ao banco de dados e a configuração das entidades.

## Tecnologias e bibliotecas

  - C#
  - ASP NET MVC Core
  - Entity Framework Core
  - MediatR
  - Boostrap

## Banco de dados

Foi utilizado o banco de dados local através da leitura do arquivo .mdf

## Padrões

CQRS: Significa Command Query Responsibility Segregation. O objetivo principal é que você pode usar um modelo diferente para atualizar 
informações e outro para ler informações. No projeto foi utilizado apenas as Queries, sendo criado um Message para cada Query realizada.

Dependency Inversion Principle: De uma forma objetiva o princípio nos faz entender que sempre devemos depender de abstrações e não das implementações.
