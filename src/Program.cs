using System;
using System.IO;
using Projektarbeit_M346;

class Program
{
    static void Main(string[] args)
    {
        // Test-CSV-Datei
        var csvFilePath = "sample.csv";

        try
        {
            // Konvertiere die Datei zu JSON
            var json = CsvToJsonConverter.ConvertCsvFileToJson(csvFilePath);

            // Ausgabe des JSON-Strings
            Console.WriteLine("Konvertiertes JSON:");
            Console.WriteLine(json);

            // Optional: JSON in einer Datei speichern
            File.WriteAllText("output.json", json);
            Console.WriteLine("Das JSON wurde in 'output.json' gespeichert.");
        }
        catch (FileNotFoundException ex)
        {
            Console.WriteLine($"Fehler: {ex.Message}");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Ein unerwarteter Fehler ist aufgetreten: {ex.Message}");
        }
    }
}
