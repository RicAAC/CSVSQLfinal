using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSVSQLfinal;

public class DatabaseHelper //Função: interagir com o banco de dados, centralizar a lógica SQL.
{
    private readonly string _connectionString;

    public DatabaseHelper(string connectionString)
    {
        _connectionString = connectionString;
    }

    public void CreateTableIfNotExists(string tableName, string[] columns, string dataType, string schema) //Criação da tabela no banco de dados
    {
        string columnDefinitions = string.Join(",", Array.ConvertAll(columns, col => $"[{col}] {dataType}"));
        string createTableQuery = $@"
                IF EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[{schema}].[{tableName}]') AND type in (N'U'))
                    DROP TABLE [{schema}].[{tableName}];
                CREATE TABLE [{schema}].[{tableName}] ({columnDefinitions})";

        using (SqlConnection connection = new SqlConnection(_connectionString))
        {
            connection.Open();
            using (SqlCommand command = new SqlCommand(createTableQuery, connection))
            {
                command.ExecuteNonQuery();
            }
        }
    }

    public void BulkInsertData(DataTable dataTable, string destinationTable) //Inserção dos dados no banco
    {
        using (SqlConnection connection = new SqlConnection(_connectionString))
        {
            connection.Open();
            using (SqlBulkCopy bulkCopy = new SqlBulkCopy(connection))
            {
                bulkCopy.DestinationTableName = destinationTable;
                bulkCopy.WriteToServer(dataTable);
            }
        }
    }
}