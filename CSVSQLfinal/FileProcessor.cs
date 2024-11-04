
using CSVSQLfinal;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSVSQLfinal
{
    public class FileProcessor //Fazer a leitura do arquivo e o processamento dos dados para inserção no SQL Server.
    {
        private readonly string _sourceFolderPath;
        private readonly string _fileExtension;
        private readonly string _fileDelimiter;
        private readonly string _columnsDataType;
        private readonly string _schemaName;
        private readonly DatabaseHelper _dbHelper;

        public FileProcessor(string sourceFolderPath, string fileExtension, string fileDelimiter, string columnsDataType, string schemaName, DatabaseHelper dbHelper)
        {
            _sourceFolderPath = sourceFolderPath;
            _fileExtension = fileExtension;
            _fileDelimiter = fileDelimiter;
            _columnsDataType = columnsDataType;
            _schemaName = schemaName;
            _dbHelper = dbHelper;
        }

        public void ProcessAllFiles() // Faz a leitura do arquivo. Se o arquivo estiver vazio, retorna uma mensagem de erro ao usuário.
        {
            string[] fileEntries = Directory.GetFiles(_sourceFolderPath, "*" + _fileExtension);
            if (fileEntries.Length == 0)
            {
                Console.WriteLine("Nenhum arquivo encontrado na pasta de origem.");
                return;
            }

            foreach (string fileName in fileEntries)
            {
                ProcessFile(fileName);
                Console.WriteLine($"Dados do arquivo {fileName} processados com sucesso.");
            }
        }

        private void ProcessFile(string fileName) // Processa os dados do arquivo, colocando-os em um array
        {
            using (StreamReader sourceFile = new StreamReader(fileName))
            {
                string tableName = Path.GetFileNameWithoutExtension(fileName);
                string columnList = "";
                DataTable dataTable = new DataTable();

                string line;
                int counter = 0;

                while ((line = sourceFile.ReadLine()) != null)
                {
                    if (counter == 0)
                    {
                        columnList = "[" + line.Replace(_fileDelimiter, "],[") + "]";
                        string[] columns = line.Split(new string[] { _fileDelimiter }, StringSplitOptions.None);
                        _dbHelper.CreateTableIfNotExists(tableName, columns, _columnsDataType, _schemaName);
                        AddColumnsToDataTable(dataTable, columns);
                    }
                    else
                    {
                        AddDataRowToTable(dataTable, line.Split(new string[] { _fileDelimiter }, StringSplitOptions.None));
                    }
                    counter++;
                }

                _dbHelper.BulkInsertData(dataTable, _schemaName + "." + tableName);
            }
        }

        private void AddColumnsToDataTable(DataTable dataTable, string[] columns) //Adiciona as colunas á tabela
        {
            foreach (string column in columns)
            {
                dataTable.Columns.Add(column, typeof(string));
            }
        }

        private void AddDataRowToTable(DataTable dataTable, string[] values) //Adiciona as linhas da tabela
        {
            DataRow row = dataTable.NewRow();
            row.ItemArray = values;
            dataTable.Rows.Add(row);
        }
    }
}