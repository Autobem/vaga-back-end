# Teste de Backend

Olá Dev!  Tudo bem?

Nós estamos procurando profissionais organizados, que não saibam de tudo, porém que saibam pesquisar e aprender.

Este teste tem como objetivo avaliar e desafiar você. Não é obrigatório realizá-lo completamente, queremos apenas reconhecer seu esforço e potencial para aprender, se adaptar e tomar decisões.

Vamos ao teste!

## Cadastro de veículos

O objetivo é criar uma web api para cadastro de veículos utilizando .net Core 3.1.
- A web api deve conter o crud básico (buscar, adicionar, atualizar e remover) de veículos e seus respectivos proprietários.
- Seria interessante que os veículos e seus proprietários tivessem seus dados armazenados em tabelas distintas ligadas (chave estrangeira).
- Seria interessante a utilização de Entity Framework com repositórios destinados para cada entidade ou um repositório genérico para atender todas (fica a critério).
- Dependendo do tamanho da base, pode ser interessante uma solução de indexação para maior agilidade nas pesquisas.

## Regras

Para o desafio ficar mais interessante, decidimos criar umas regras básicas:
- Deve ser usada a arquitetura DDD para a estrutura do projeto.
- Devem ser criados casos de teste para todos os elementos da api (a escolha do framework de testes é livre).
- A api deve utilizar uma base de dados para persistência de dados (SQL Server, LocalDB, SQLite, MySQL ou qualquer outro, deste que utilizando EF Core).
- A api não deve ter acesso livre. Deve ser utilizado algum método de identificação utilizando OAuth 2.0.
- É permitido utilizar pacotes nuget ou similares para agilidade (inclusive pacotes de autoria própria).

## Por onde começo?

Primeiramente, você pode fazer um fork desse repositório aqui, para sua conta do Github, depois disso crie uma branch nova com o seu nome (ex: nome_sobrenome), para podermos indentificá-lo.

Após terminar o desafio, você pode solicitar um pull request para a branch master do nosso repositório. Vamos receber e fazer a avaliação de todos.

## Só isso?

Só! Mas se estiver motivado, tente preparar o projeto para ser executado e testado de maneira prática, usando alguma ferramenta que facilite isso (ex: nuget).
