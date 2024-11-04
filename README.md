# CSVSQL1

Este projeto em C# lê arquivos CSV/TSV de uma pasta específica e insere os dados em tabelas de um banco de dados SQL Server. Ele cria tabelas automaticamente com base nas colunas do arquivo e utiliza `SqlBulkCopy` para uma inserção eficiente.

## Tecnologias Utilizadas
- [.NET 8.0](https://dotnet.microsoft.com/pt-br/download)
- [SQL Server Management Studio](https://learn.microsoft.com/pt-br/sql/ssms/download-sql-server-management-studio-ssms?view=sql-server-ver16)
- [Visual Studio](https://visualstudio.microsoft.com/pt-br/)

## Como Executar

### Pré-requisitos
Antes de executar o projeto, instale as seguintes ferramentas:
- [.NET 8.0](https://dotnet.microsoft.com/pt-br/download/dotnet?cid=getdotnetcorecli)
- [SQL Server Management Studio](https://learn.microsoft.com/pt-br/sql/ssms/download-sql-server-management-studio-ssms?view=sql-server-ver16)

Certifique-se de configurar o seu SQL Server conforme desejado.

### Passo a Passo

1. **Clone o repositório**:
   ```bash
   git clone https://github.com/RicAAC/CSVtoSQL.git
   cd CSVtoSQL
2. **Abra o projeto**:
- Abra o Visual Studio.
- Navegue até a pasta do projeto e abra o arquivo de solução (CSVtoSQL.sln).
3. **Configure a string de conexão**:
- No arquivo Program.cs, modifique a string de conexão connectionString conforme o seu ambiente SQL Server.
4. **Compile o projeto**:
- Pressione F5 para compilar e executar o projeto, ou CTRL + F5 para executar sem depuração.
