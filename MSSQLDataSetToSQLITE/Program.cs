using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MSSQLDataSetToSQLITE
{
    class Program
    {
        static void Main(string[] args)
        {
            string dstext;
            string filedir = @"..\..\..\mymins\";
            System.Console.WriteLine("Replacing MS SQL code in " + filedir + "myminsDataset.Designer.cs with SQLite code.");

            try
            {
                dstext = System.IO.File.ReadAllText(filedir + "myminsDataset.Designer.cs");
                if (!dstext.Contains("SQLite"))
                {
                    // Replace MS SQL code with SQLite.
                    dstext = dstext.Replace("Sql", "SQLite");
                    dstext = dstext.Replace("SQLiteClient", "SQLite");
                    dstext = dstext.Replace("SQLiteDbType", "DbType");
                    dstext = dstext.Replace(", \"\", \"\", \"\"", "");

                    // DATATYPE Replacement
                    dstext = dstext.Replace("TinyInt", "SByte");
                    dstext = dstext.Replace("SmallInt", "Int16");
                    dstext = dstext.Replace(".Int,", ".Int32,");
                    dstext = dstext.Replace("NVarChar", "String");
                    dstext = dstext.Replace("Float", "Double");
                    dstext = dstext.Replace("Bit", "Boolean");
                    dstext = dstext.Replace("NChar", "String");
                    
                    // Concatenate SQL strings for further replacement.
                    dstext = dstext.Replace("\" +\r\n                \"", "");

                    // SQL Syntax replacement
                    dstext = dstext.Replace("[dbo].", "[main].[sqlite_default_schema].");
                    dstext = dstext.Replace("dbo.", "main.");
                    // This extra line is needed for SQLiteDataAdapter.Update to retrieve identities like SqlDataAdapter.Update does.
                    dstext = dstext.Replace("SCOPE_IDENTITY())\";", "last_insert_rowid())\";\r\n            this._adapter.InsertCommand.UpdatedRowSource = System.Data.UpdateRowSource.FirstReturnedRecord;");
                    
                    System.IO.File.WriteAllText(filedir + "myminsDataset.Designer.cs", dstext);
                }
            }
            catch
            {
                System.Console.WriteLine("Error accessing myminsDataset.Designer.cs.\r\nOperation Failed.");
                System.Console.ReadKey();
                return;
            }

            System.Console.WriteLine("Operation succeeded.");
            System.Console.ReadKey();
        }
    }
}
