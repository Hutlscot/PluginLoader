namespace CadUtils.Extensions;

using System.IO;
using System.Linq;

using CadUtils.Models;

public static class CadPluginExtensions
{
    /// <summary>
    /// Добавить cad плагин.
    /// </summary>
    /// <param name="cadPlugin">Cad плагин.</param>
    public static void AddCadPlugin(this CadPlugin cadPlugin)
    {
        using (var sw = new StreamWriter(cadPlugin.PathToIniFile, true))
        {
            sw.WriteLine($"{cadPlugin.Name}");
            sw.WriteLine($"{cadPlugin.PathToDll}");
        }
    }

    /// <summary>
    /// Удалить cad плагин.
    /// </summary>
    /// <param name="cadPlugin">Cad плагин.</param>
    public static void DeleteCadPlugin(this CadPlugin cadPlugin)
    {
        var allLines = File.ReadAllLines(cadPlugin.PathToIniFile);
        var newLines = allLines.Where(s => !s.Equals(cadPlugin.Name) && !s.Equals(cadPlugin.PathToDll)).ToList();
        File.WriteAllLines(cadPlugin.PathToIniFile, newLines);
    }

    /// <summary>
    /// Отключить cad плагин.
    /// </summary>
    /// <param name="cadPlugin">Cad плагин.</param>
    public static void DisableCadPlugin(this CadPlugin cadPlugin)
    {
        var allLines = File.ReadAllLines(cadPlugin.PathToIniFile);

        //коментируем строку с путём к dll плагина
        var newLines = allLines.Select(line => line == cadPlugin.PathToDll ? $"#{line}" : line);

        File.WriteAllLines(cadPlugin.PathToIniFile, newLines);
    }

    /// <summary>
    /// Включить cad плагин.
    /// </summary>
    /// <param name="cadPlugin">Cad плагин.</param>
    public static void EnableCadPlugin(this CadPlugin cadPlugin)
    {
        var allLines = File.ReadAllLines(cadPlugin.PathToIniFile);

        //раскометить строку с путём к dll плагина
        var newLines = allLines.Select(line => line.Contains($"{cadPlugin.PathToDll}") ? $"{cadPlugin.DisplayPathToDll}" : line);

        File.WriteAllLines(cadPlugin.PathToIniFile, newLines);
    }
}