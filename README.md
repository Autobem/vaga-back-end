# Registro de Veículos

Este simples projeto consiste em um teste de API REST para cadastro de veículos e seus respectivos proprietários. Além de permitir a manipulação de registros de marcas, modelos, cores e afins. A API utiliza autenticação OAuth2 com JWT e Swagger/OpenAPI para sua documentação.

## Pre-requisitos

* C#/.NET >= 7.0.0
* Entity Framework Core >= 7.0.5
* PostgreSQL >= 14.8.0

## Instalação

Após instalar o .NET SDK e o PostgreSQL em seu computador, e configurar as credenciais de persistência, bem como as credenciais de autenticação para o JWT no arquivo `appsettings.[x].json` apropriado, execute o seguinte comando na raiz do projeto para instalar as dependências:

```sh
dotnet restore
```

Feito isto, é necessário rodar as *migrations* e *seeders* no banco de dados:

```sh
dotnet ef database update --context IdentityContext
dotnet ef database update --context BusinessContext
```

Depois, basta executar o Kestrel para servir a API com o comando:

```sh
dotnet run
```

A fim de acessar a documentação da API, para saber quais *endpoints* estão disponíveis, com seus respectivos parâmetros, entre com o seguinte endereço em seu navegador:

```sh
http://localhost:5279/swagger
```

## Licença

Este projeto é de código aberto e está licenciado sob a [Licença MIT](license.md)