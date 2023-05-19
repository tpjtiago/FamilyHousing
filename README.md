# FamilyHousing

Neste desafio, foram empregados vários recursos e práticas para garantir uma arquitetura robusta e de alta qualidade. Alguns dos destaques incluem:

Arquitetura em camadas: O projeto foi estruturado em camadas distintas, como API, Data, Domain e Tests. Essa abordagem ajuda a separar as responsabilidades e facilita a manutenção e escalabilidade do sistema.

Princípios de Clean Code e SOLID: Foram aplicados conceitos de Clean Code para escrever um código legível, de fácil compreensão e manutenção. Além disso, os princípios SOLID foram utilizados para criar um design flexível e extensível.

Testes unitários: Foram criados testes unitários para as controllers e serviços. Isso garante que as funcionalidades do sistema estejam corretas e consistentes, permitindo uma rápida detecção de possíveis problemas.

Repositório genérico: Foi adotado o conceito de repositório genérico para abstrair as operações de acesso a dados. Isso proporciona uma maior flexibilidade e reutilização de código, além de simplificar o desenvolvimento e facilitar a manutenção.

Entidades e Modelos: Para fornecer respostas customizadas ao frontend, utilizamos entidades e modelos. Isso permite que apenas as propriedades relevantes sejam retornadas, evitando informações desnecessárias e melhorando a performance da aplicação.

Code-First e Entity Framework: Optamos por utilizar a abordagem Code-First juntamente com o Entity Framework para a modelagem e acesso aos dados. Essa abordagem permite que o modelo de banco de dados seja criado a partir do código, facilitando a evolução e o versionamento do esquema do banco de dados.

Banco de dados SQL Server: O SQL Server foi escolhido como o banco de dados para o projeto. Através do Entity Framework e do conceito de DB Context, podemos interagir com o banco de dados de forma eficiente e escalável.

Utilização do .NET 6 e C#: O projeto foi desenvolvido utilizando o framework .NET 6 e a linguagem C#, aproveitando as melhorias e recursos mais recentes disponíveis na plataforma.

AutoMapper: O AutoMapper foi utilizado para mapear objetos entre as entidades e modelos, simplificando o processo de conversão de dados.

Em resumo, este projeto demonstrou a aplicação de diversos conceitos e tecnologias modernas, visando desenvolver um sistema de alta qualidade, modular e fácil de dar manutenção.
