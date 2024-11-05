# CSVSQL1

This C# project reads CSV/TSV files from a specific folder and inserts the data into tables in a SQL Server database. It automatically creates tables based on the file columns and uses SqlBulkCopy for efficient insertion.

## Technologies Used
- [.NET 8.0](https://dotnet.microsoft.com/pt-br/download)
- [SQL Server Management Studio](https://learn.microsoft.com/pt-br/sql/ssms/download-sql-server-management-studio-ssms?view=sql-server-ver16)
- [Visual Studio](https://visualstudio.microsoft.com/pt-br/)

## How to run

### Prerequisites
Before running the project, install the following tools:
- [.NET 8.0](https://dotnet.microsoft.com/pt-br/download/dotnet?cid=getdotnetcorecli)
- [SQL Server Management Studio](https://learn.microsoft.com/pt-br/sql/ssms/download-sql-server-management-studio-ssms?view=sql-server-ver16)

Ensure your SQL Server is configured as desired.

### Step-by-step

1. **Clone the repository**:
   ```bash
   git clone https://github.com/RicAAC/CSVtoSQL.git
   cd CSVtoSQL
2. **Open the project:**
- Open Visual Studio.
- Navigate to the project folder and open the solution file (CSVtoSQL.sln).
3. **Configure the connection string:**
- In the Program.cs file, modify the connectionString to match your SQL Server environment.
4. **Compile the project:**
- Press F5 to compile and run the project, or CTRL + F5 to run without debugging.
