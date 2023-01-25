<h1 align="center"><b>LojaEstoque</b></h1>

<p>Este projeto faz parte de um teste prático de uso das ferramentas .NET para criação de um sistema que implemente CRUD.</p><br>

<p align="center">
<a href="#sobre"><b>Sobre</b></a> •
<a href="#features"><b>Features</b></a> •
<a href="#tecnologias"><b>Tecnologias</b></a> •
<a href="#pre-requisitos"><b>Pré-Requisitos</b></a> •
<a href="#autor"><b>Autor</b></a> 
</p><br>

<h2 id="sobre"><b>Sobre</b></h2>

<p>O objetivo do sistema é realizar visualização, cadastro, alteração e exclusão de produtos em um banco de dados.</p>
<p>O banco de dados funciona através de migrations que é implementada por ferramentas do Entity Framework.</p>
<p>Para administrar como serão salvos os dados e como serão geridos a aplicação conta com classes de repositório, sendo que cada classe é especifica para manutenção de sua tabela.</p> 
<p>Os objetos que dão os atributos necessários para o funcionamento da aplicação encontram-se na classe modelo, fazendo parte da MODEL no MVC. </p>


<h2 id="features"><b>Features</b></h2>

<h3><b>Busca</b></h3>
<p>A página contém um input de busca com autocomplete que oferece opções disponíveis de produtos.</p>
<p align="center"><img alt="busca" title="busca" src="./GitImages/busca.jpg"/></p>
<br>
<p>Caso o produto não exista ou não seja encontrado será exibido um aviso através de um dialog.</p>
<p align="center"><img alt="aviso busca" title="aviso-busca" src="./GitImages/aviso-busca.jpg"/></p>
<br>
<h2><b>Lista de produtos</b></h2>
<p>Cada produto possuí ID, NOME e VALOR, e em cada um existe o botão de editar e excluír.</p>
<p align="center"><img alt="lista de produtos" title="lista" src="./GitImages/lista.jpg"/></p>
<br>
<h2><b>Editar</b></h2>
<p>Ao clicar em editar a pagina encaminha os dados do produto para um formulário que virá previamente preenchido com dados atuais para que possam ser alterados.</p>
<p align="center"><img alt="formulario editar" title="editar" src="./GitImages/editar.jpg"/></p>
<br>
<h2><b>Cadastrar</b></h2>
<p>O formulário para cadastro é o mesmo utilizado na edição, porém o mesmo vem sem nenhum dado inserido, para que possa inserir nome e valor de um novo produto.</p>
<p align="center"><img alt="formulario cadastrar" title="cadastrar" src="./GitImages/cadastrar.jpg"/></p>
<br>
<h2><b>Avisos e Mensagens</b></h2>
<p>Ao tentar excluír será exibido um diálogo para confirmação, após clicar no mesmo o produto será excluído do banco de dados.</p>
<p>O mesmo painel de diálogo é utilizado para exibir confirmações de todas as ações.</p>
<p align="center"><img alt="avisos" title="avisos" src="./GitImages/aviso-excluir.jpg"/></p>
<br>
<h2><b>Seleção de temas</b></h2>
<p>A página possuí tema light e dark, as configurações são salvas em local storage.</p>
<p align="center"><img alt="tema light" title="tema-light" src="./GitImages/tema-light.jpg"/></p>
<p align="center"><img alt="tema dark" title="tema-dark" src="./GitImages/tema-dark.jpg"/></p>


<h2 id="tecnologias"><b>Tecnologias</b></h2>

- **`ASP.NET Core`**
- **`CSharp`**
- **`.NET Framework`**
- **`Entity Core Framework`**
- **`SQL Server`**
- **`HTML 5`**
- **`CSS 3`**
- **`Javascript`**

<p>A base tecnológica da aplicação é o NET Core, com o uso do MVC e pastas mapeadas para que a aplicação faça a integração entre Movel, View e Controller.</p>
<p>Para o uso do repositório foi utilizado o entity Framework, utilizando-se de migrations para que o banco de dados seja atualizado sem que dados sejam perdidos.</p>
<p>Com o objetivo de demonstrar o uso do NET Core poucas classes são criadas, apenas as necessárias para gerir as informações que serão armazenadas no banco de dados e o objeto que vai representar essas classes, sendo este a classe "produto".</p>
<p>Para responsividade e demais interações visuais foram utilizados técnicas de animação com CSS e Javascript integrados ao HTML.</p><br>

<h2 id="pre-requisitos"><b>Pré-Requisitos</b></h2>

<p>Para utilizar a aplicação é necessário possuir .NET 6 ou mais recente e  SQL Server<p>
<p>O arquivo "appsettings.json" deverá ser editado para que seja inserida uma conexão ao banco de dados</p>

    "ConnectionStrings": {
      "DefaultConnection": "sua conexão";
    }

Alterar a <b>DefaultConnection</b> para:

    "Data Source=SEU BANCO DE DADOS; Database=LandingPageDB; Trusted_Connection=True; MultipleActiveResultSets=true; User ID=SEU USER; Password=SUA SENHA"

<p>Após a conexão estar configurada basta apenas inicializar a aplicação.</p>
<br>

<h2 id="autor"><b>Autor</b></h2>

| [<img src="https://avatars.githubusercontent.com/u/107010683?v=4" width=115><br><sub>Felipe Rodrigues Santos</sub>](https://github.com/FelipeR-S) |  
| :---: |