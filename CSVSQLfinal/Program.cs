using CSVSQLfinal;

class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("Insira o caminho para o arquivo:");
        string sourceFolderPath = Console.ReadLine();
        Console.WriteLine("Insira a extensão do arquivo (.tsv/.csv):");
        string fileExtension = Console.ReadLine();
        string fileDelimiter;
        if (fileExtension == ".tsv")
        {
            fileDelimiter = "\t";
        }
        else if (fileExtension == ".csv")
        {
            fileDelimiter = ",";
        }
        else
        {
            fileDelimiter = "";
            Console.WriteLine("Extensão não suportada.");
        }
        string columnsDataType = "NVARCHAR(4000)";
        string schemaName = "dbo";
        string connectionString = "Data Source=DESKTOP-7DU2LGB;Initial Catalog=TesteCSVsql;Integrated Security=True";

        try
        {
            var dbHelper = new DatabaseHelper(connectionString);
            var fileProcessor = new FileProcessor(sourceFolderPath, fileExtension, fileDelimiter, columnsDataType, schemaName, dbHelper);
            fileProcessor.ProcessAllFiles();
        }
        catch (Exception ex)
        {
            Console.WriteLine("Erro: " + ex.Message);
        }
    }
}