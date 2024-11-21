# Code challenge - Capital Gain

## Justificativa para o uso de frameworks e bibliotecas

A solução foi construída utilizando as seguintes bibliotecas e frameworks:

- **xUnit**: Foi utilizado como framework de testes unitários devido à sua simplicidade para implementação e relaização dos testes.
- **coverlet.collector**: Esse framework foi utilizado para analise de cobertura de testes da solução, devido simplicidade para execução e geração de relatorio para analise. 
- **Newtonsoft.Json**: Framework escolhido para lidar com a serialização e desserialização de objetos JSON devido à sua simplicidade e grande utilização na comunidade .NET.

Essas bibliotecas e frameworks foram escolhidos por sua simplicidade e integração com o .NET, garantem uma estrutura de código mais limpa e fácil de testar. Sem interferir
em logicas de negocio propostas no desafio.

## Instruções para compilar e executar o projeto

1. **Pré-requisitos**: Certifique-se de ter o **.NET SDK** instalado em sua máquina. Você pode obter a versão mais recente [aqui](https://dotnet.microsoft.com/download).

2. **Compilando o projeto**:
   - Abra o terminal ou prompt de comando.
   - Navegue até o diretório do projeto.
   - Execute o comando:
     ```bash
     dotnet build
     ```
   Esse comando irá compilar o projeto e gerar os binários necessários.

3. **Executando testes e gerando relatorio de cobertura**
   - Abra o terminal ou prompt de comando no diretorio raiz do projeto.
   - Execute o comando:
     ```
     dotnet test --collect:"XPlat Code Coverage"
     ```
   Comando ira executar os testes e gerar relatorio em formato xml
   e com porcetagens de cobertura de testes unitarios. Arquivo pode
   ser encontrado no caminho **CapitalGains.Test\TestResults**
	
3. **Executando o projeto**:
   Para executar a aplicação, utilize o comando:
   ```bash
   dotnet run
   ```
