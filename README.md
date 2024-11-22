# **Capital Gains Application**

Este repositório contém uma aplicação console desenvolvida em .NET 8 para processamento de operações financeiras de compra e venda. A aplicação pode ser executada localmente ou em um contêiner Docker. Este guia fornece todas as instruções necessárias para compilar, executar e testar o projeto.


---

## **Justificativa para o Uso de Frameworks e Bibliotecas**

- **.NET 8**: Escolhido por possuir maior experiencia, e suporte a aplicações multiplataforma.
- **Docker**: Escolhido pela facilidade para gerar build e execução da aplicação em qualquer sistema operacional.
- **xUnit**: Framework de testes escolhido por sua simplicidade e popularidade na comunidade .NET, e onde possuo mais afinidade.
- **Newtonsoft.Json**: Biblioteca amplamente utilizada para manipulação de objetos JSON.
- **Coverlet.collector**: Biblioteca amplamente aceita na comunidasde .NET, de simples entendimento para analise de cobertura de testes.

Bibiliotecas e Frameworks em geral foram escolhidos levando em consideração três pontos, familiaridade com a tecnologia, facilidade
de utilização e abstração de alguns processos que acredito não entrarem na avaliação da logica de raciocinio da solução em si.

---

## **Pré-Requisitos de Sistema**

Antes de começar, certifique-se de que o ambiente está configurado corretamente. Você precisará das seguintes ferramentas instaladas:

- **Acesso ao terminal ou prompt de comando**  
  - No Linux/MacOS, utilize o terminal padrão.  
  - No Windows, pode usar o PowerShell ou CMD.

- **.NET SDK 8.0 ou superior**  
  - Faça o download e instale a partir do site oficial da Microsoft: [Download .NET SDK](https://dotnet.microsoft.com/download).  
  - Verifique se está instalado corretamente executando no terminal:
  ```bash
  dotnet --version
  ```

- **Docker e Docker Compose**  
  - Faça o download e instale a partir do site oficial do Docker: [Download Docker](https://www.docker.com/products/docker-desktop).  
  - Verifique se está instalado corretamente executando no terminal:
  ```bash
  docker --version
  docker compose version
   ```
  
---

## **Instruções para Compilar e Executar o Projeto**

### **1. Compilando o Projeto Localmente**

1. Abra o terminal ou prompt de comando.
2. Navegue até o diretório raiz do projeto (onde está o arquivo `.csproj`).
3. Compile o projeto utilizando o seguinte comando:
```bash
dotnet build
```
4.Após a compilação, os binários serão gerados no diretório bin/Debug/net8.0.

### **2. Subindo a Imagem do Projeto para o Docker**

1. Certifique-se de estar no diretório raiz da aplicação, onde está localizado o arquivo Dockerfile e/ou docker-compose.yml.
2. Suba a aplicação no Docker utilizando o comando abaixo:
```bash
docker compose up --build
```

### **3. Executando a Aplicação para Processar o Arquivo de Operações**

1. Certifique-se de que o arquivo de entrada input.txt está no mesmo diretório onde o comando será executado.
- Exemplo do conteúdo esperado em input.txt:
```text
[{"operation":"buy","unit-cost":20.00,"quantity":50},{"operation":"sell","unit-cost":20.00,"quantity":50}]
[{"operation":"buy","unit-cost":10.00,"quantity":100},{"operation":"sell","unit-cost":15.00,"quantity":50},{"operation":"buy","unit-cost":10.00,"quantity":50}]
[{"operation":"buy","unit-cost":15.00,"quantity":200},{"operation":"sell","unit-cost":10.00,"quantity":100}]

```
2. Execute o seguinte comando no terminal para rodar a aplicação no Docker:
```bash
docker run --rm -i capitalgains-server ./capital-gains < input.txt
```
3. A saída será exibida diretamente no terminal, processando as operações contidas no arquivo input.txt.
- Exemplo de saida esperada para cada linha do input.txt:
```text
[{"tax":0.00},{"tax":80000.00},{"tax":0.00},{"tax":60000.00}]
```

---

## **Instruções para Executar os Testes**

### **1. Executando testes unitarios**

1. Navegue até o diretório raiz do projeto.
2 .Utilize o seguinte comando para executar os testes:
```bash
dotnet test
```
3. O framework xUnit será utilizado para executar os testes configurados no projeto. Após a execução, você verá os resultados diretamente no terminal.

### **2. Executando testes unitarios e gerando relatorio de cobertura**

1. Navegue até o diretório raiz do projeto.
2 .Utilize o seguinte comando para executar os testes e gerar o relatorio:
```bash
dotnet test --collect:"XPlat Code Coverage"
```
3. A biblioteca xUnit será utilizado para executar os testes configurados no projeto, e o Coverlet.collections sera responsavel por gerar o arquivo de cobertura com extensão .xml.
Arquivo sera gerado no diretorio **CapitalGains.Test/TestResult**.

