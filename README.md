<h1 align="center">
    Studer - Plataforma de Estudo para Vestibulares
</h1>

<h3 align="center">
O Studer é uma plataforma onde um estudante poderá realizar simulados, divididos por categorias e analisar o desempenho dos seus simulados realizados.
</h3>

<h3>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;Foi pensado para os estudantes para prepararem eles aos vestibulares que desejam prestar, trazendo assim questões criadas por professores que tem o cadastro no sistema, podendo escolher um vestibular específico para que os simulados sejam o mais semelhante com o que foi selecionado, conforme o aluno for praticando, mais familiarizado estará com o formato do vestibular, sobre as questões no simulado, além das questões de anos anteriores, são colocadas as questões de professores que criam com base no vestibular em específico.
</h3>

<div align="center" margin-bottom="30">
    <h3>Integrantes: </h3> 
    <div>Giovanni Mayer Sanches Zanotti - Prontuário: CP3008266</div>
    <div>Lucas Dias Pedrosa - Prontuário: CP300810X</div>
    <div>Marcos Vinicius Ota - Prontuário: CP3008304</div>
</div>

<br>

## C4 Model

- <h3> Diagrama de Contexto </h3>
    </br>
    A plataforma será usada por dois atores, o estudante e o professor. O Estudante irá fazer os simulados e poderá visualizar seu desempenho nos que já foram feitos. O sistema será primeiramente todo unificado, não necessitando de outros sistemas para complementa-lo, sendo assim, nele contará com a lógica da aplicação e a apresentação das informações
    </br><br>
    <img alt="Studer" title="Studer" src="./wwwroot/UML/diagrama de contexto.png" />
  
## Diagramas UML

- <h3> DER </h3>
    </br>
    O banco de dados irá conter os estudantes cadastrados, fazendo relação com os simulados, e como os estudantes podem ter muitos simulados, e cada simulado pode conter muitas questões, foi necessário criar uma terceira tabela, sendo ela a intermediária, contendo os ids dos simulados e os ids das questões que estão sendo relacionados. Cada questão deverá conter uma determinada disciplina, para poder fazer um filtro na hora de selecionar o tipo de questão para a realização do simulado, podendo o simulado conter várias questões de várias disciplinas. Por motivos de organização, os simulados serão também relacionados a um tipo de vestibular, e cada vestibular poderá ter um conjunto de caracteristicas, sendo elas a quantidade de questões de cada disciplina que irá conter. As questões poderão ser feitas também pelos professores, então nesse momento, a ação do professor é somente a criação de questões.
    </br></br>
    <img alt="Studer" title="Studer" src="./wwwroot/UML/DER.png" />
    </br></br>

- <h3> Diagrama de Casos de Uso </h3>
    </br>
    Nesse diagrama podemos observar as maneiras que os usuários podem interagir com o sistema. O usuário Estudante poderá se cadastrar, e após fazer o seu login, ele tambem poderá escolher um vestibular para realizar um simulado. Ele também poderá consultar o desempenho dos seus simulados realizados. O usuário professor, após fazer o login, poderá produzir e comentar uma questão.
    </br></br>
    <img alt="Studer" title="Studer" src="./wwwroot/UML/Casos de Uso.png" />
    </br></br>
    
- <h3> Diagrama de Classes </h3>
    </br>
    Nesse diagrama, podemos ver a representação da estrutura e das relações entre as classes do projeto. Optamos por adicionar uma classe Desempenho, que será responsável por fazer toda a intermediação simulado-estudante, pois essa classe terá acesso a uma lista de todos os simulados que foram realizados por um estudante. Cada classe terá os seus métodos capazes de fazer a comunicação com o banco de dados, para que esses dados sejam acessados pelo usuário do sistema.
    </br></br>
    <img alt="Studer" title="Studer" src="./wwwroot/UML/Diagrama de Classes.png" />
    </br></br>

## Diagrama de Classes dos Padrões de Projeto
    
- <h3> Builder </h3>
    </br>
    <img alt="Studer" title="Studer" src="./wwwroot/UML/Builder Estudante.png" />
    </br></br>