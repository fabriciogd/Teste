# Teste

## Projeto separado em camadas

  - Domínio: A camada geralmente contém lógica de negócio e entidades.
  - Aplicação: A camada de aplicativo contem interfaces e tipos.
  - Apresentação: A camada de apresentação é onde está localizado o projeto aonde o usuário pode acessar.
  - Infraestrutura: A camada de infraestrutura é aonde fica localizado o acesso ao banco de dados e a configuração das entidades.

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

## Observações

Quando você cria um contexto para o EF e indica as classes do mapeamento, basicamente diz a ele que todos os objetos deverão ser rastreados, ou seja, o simples fato de você criar um objeto ou ler a partir do contexto, coloca este objeto sobre o controle do EF. Para não executar esta lógica, temos o método “AsNoTracking()", que em termos bem simples diz ao contexto para não mapear o objeto.

Foi utilizado o padrão RepositoryQuery para a implementação da busca das listas, visando diminuir a replicação da lógica e centralizando em uma unica classe.
