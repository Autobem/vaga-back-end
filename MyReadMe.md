<h1>Teste de Backend - Autobem<h1> 
 
<h2>API Rest - Veículos e Proprietários</h2>

<p>Api desenvolvida com Java 11 :</p>
<ul>
  <li>Spring Boot</li>
  <li>Spring Data JPA</li>
  <li>Banco de Dados MySQL</li>
  <li>Autenticação com Spring Security</li>
  <li>JWT para autenticação via Token</li>
  <li>Swagger para documentação ( path:/swagger-ui.html )</li>
</ul>

<h3>Usuário de Autenticação Autobem:<h3>

<p>Usuário: Autobem</p>
<p>Email: autobem@email.com<p>
<p>Senha: vagabackend<p>

<p>A autenticação é realizada através do email e senha, será gerado um token de autenticação através de um método POST para o caminho "/auth". É necessário este token no header Authorization de cada requisição HTTP do tipo POST, DELETE e PUT, as requisições do tipo GET estão abertas para usuários não autenticados.</p>
