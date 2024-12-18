using System;
using System.Collections.Generic;
using System.IO;
using Newtonsoft.Json;
namespace Projektarbeit_M346{
public class CsvToJsonConverter
{
    /// <summary>
    /// Konvertiert den Inhalt einer CSV-Datei in ein JSON-Format.
    /// </summary>
    /// <param name="csvContent">Der Inhalt der CSV-Datei als String.</param>
    /// <returns>Ein JSON-String, der die CSV-Daten repräsentiert.</returns>
    public static string ConvertCsvContentToJson(string csvContent)
    {
        // Teile den CSV-Inhalt in Zeilen
        var lines = csvContent.Split(new[] { '\n', '\r' }, StringSplitOptions.RemoveEmptyEntries);

        // Extrahiere die Kopfzeile
        var headers = lines[0].Split(',');

        // Liste für JSON-Daten
        var jsonList = new List<Dictionary<string, string>>();

        // Verarbeite jede Datenzeile
        for (int i = 1; i < lines.Length; i++)
        {
            var values = lines[i].Split(',');
            var rowDict = new Dictionary<string, string>();

            for (int j = 0; j < headers.Length; j++)
            {
                rowDict[headers[j].Trim()] = values[j].Trim();
            }

            jsonList.Add(rowDict);
        }

        // Konvertiere die Liste in JSON
        return JsonConvert.SerializeObject(jsonList, Formatting.Indented);
    }

    /// <summary>
    /// Lädt den Inhalt einer CSV-Datei von einem Dateipfad und konvertiert ihn in JSON.
    /// </summary>
    /// <param name="filePath">Der Pfad zur CSV-Datei.</param>
    /// <returns>Ein JSON-String, der die CSV-Daten repräsentiert.</returns>
    public static string ConvertCsvFileToJson(string filePath)
    {
        // Prüfe, ob die Datei existiert
        if (!File.Exists(filePath))
        {
            throw new FileNotFoundException($"Die Datei '{filePath}' wurde nicht gefunden.");
        }

        // Lese den Inhalt der Datei
        var csvContent = File.ReadAllText(filePath);

        // Konvertiere den Inhalt in JSON
        return ConvertCsvContentToJson(csvContent);
    }
}
}
