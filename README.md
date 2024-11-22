# Code challenge - Capital Gain

## Justificativa para o uso de frameworks e bibliotecas

A solução foi construída utilizando as seguintes bibliotecas e frameworks:

- **xUnit**: Foi utilizado como framework de testes unitários devido à sua simplicidade e felixidade para implementação e realização dos testes, o mesmo ja possui templates no Visual Studio.
- **coverlet.collector**: Esse framework foi utilizado para analise de cobertura de testes da solução, devido simplicidade para execução e geração de relatorio para analise.
  Xml gerado com porcentagens de cobertura é de facil entendimento e grande auxilio para verificar pontos que necessitam de antenção. 
- **Newtonsoft.Json**: Framework escolhido para lidar com a serialização e desserialização de objetos JSON de forma mais simples e objetiva. É altamente utilizado na comunidade .NET.

Essas bibliotecas e frameworks foram escolhidos por sua simplicidade e integração com o .NET, garantem uma estrutura de código mais limpa e fácil de testar. Sem interferir
em logicas de negocio propostas no desafio.

## Instruções para Testar o projeto e gerar Relatorio de cobertura

1. **Executando apenas os testes**
    - Abra o terminal ou prompt de comando no diretorio raiz do projeto.
    - Execute o comando:
     ```
     dotnet test
     ```
    Comando ira executar os testes unitarios do projeto.

2. **executando os testes e gerando relatorio de cobertura de testes**
    - Abra o terminal ou prompt de comando no diretorio raiz do projeto.
    - Execute o comando:
     ```
     dotnet test --collect:"XPlat Code Coverage"
     ```
    Comando ira executar os testes e gerar relatorio em formato xml
    com porcetagem de cobertura de testes unitarios.

## Instruções para compilar e executar o projeto

1. **Pré-requisitos**: Certifique-se de ter o **DOCKER** instalado em sua máquina.

2. **Compilando o projeto**:
    - Abra o terminal ou prompt de comando.
    - Navegue até o diretório do projeto.
    - Execute o comando:
     ```bash
     dotnet build
     ```
	
3. **Subindo imagem do projeto para o Docker**:
    - Permanessa no diretorio raiz da aplicação.
    - Execute o comando:
	 ```bash
     docker compose up --build
     ```
