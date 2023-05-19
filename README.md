# Teste de Backend

Teste de BackEnd Finalizado por - Davisson Assuncao


## Cadastro de veículos

Para acessar o cadastro de Veículos, acesse a rota "/api/carros"

Para obter todos os Carros, acesse a rota: "api/carro".
Para obter carro por ID, acesse a rota  passando o id do Carro: "api/carro/id"
Para obter carro por proprietario, acesse a rota passando o id do Proprietario: "api/carro-por-proprietario/id"
Para alterar um Carro,  acesse a rota "api/carro" com o VERBO PUT, passando o ID e o Objeto Carro;
Para deletar um Carro, acesse a rota "api/carro" com o VERBO DELETE, passando o ID do Carro;

## Cadastro de Proprietarios

Para obter todos os Proprietarios: acesse a rota: api/proprietario
Para obter carro por ID de proprietarios, acesse a rota  passando o id do Proprietario: "api/carros-por-proprietarios/id"
Para obter endereço por proprietario, acesse a rota passando o id do Proprietario: "api/proprietario/endereco/id"
Para alterar um Proprietario, acesse a rota "api/proprietario" com o VERBO PUT, passando o ID e o Objeto Proprietario;
Para alterar um Endereco de um Proprietario, acesse a rota "api/atualizar-endereco-prop" com o VERBO PUT, passando o ID do endereco;
Para deletar um Proprietario, acesse a rota "api/proprietario" com o VERBO DELETE, passando o ID do Proprietario;

## PARA ACESSAR A AUTENTICACAO

Não foi configurado a autenticacao pelo Swagger

POR FAVOR - ACESSE VIA POSTMAN;

Para fazer registro de login: /api/authoriza/registrar
Para fazer login: /api/authoriza/login

Para autenticar: utilizar o token gerado pelo login ou registro e utilizar via POSTMAN

## Só isso?

Só! 