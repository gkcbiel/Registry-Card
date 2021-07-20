# Registry-Card
Para executar o projeto necessário instalar: .NetCore 3.0, PostgreSql, Microsoft.AspNetCore.Authentication e Microsoft.AspNetCore.Authentication.JwtBearer e Npgsql.EntityFrameworkCore.PostgreSQL .</br>
Os dados de conexão do Banco de dados estão no appsettings.json para rodar na sua máquina talvez seja necessário alterar dados como: Porta do banco o usuario e a senha . </br>
Só é possivel fazer requisição se estiver autenticado, os dados para se autenticar estão mockados o Username é Gabriel e o Password é desafio. </br>
No cabeçalho das requisições adicione o Authorization com o value  Token como neste modelo: Bearer "token" para ser autenticado, após isso poderá fazer qualquer requisição por até uma hora. </br>
O endpoint de autenticação é /v1/account/login </br>
O endpoint de get e post é /v1/card ´so muda o método ,/br>
O endpont consulta de um único cartão é /v1/card/{Número} </br>
Para fazer o upload do arquivo txt o endpoint é /v1/card/upload </br>
