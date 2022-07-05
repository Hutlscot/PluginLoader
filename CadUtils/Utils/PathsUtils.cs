namespace CadUtils.Utils;

using System;
using System.IO;
using System.Reflection;

/// <summary>
/// Помощник работы с путями.
/// </summary>
public static class PathsUtils
{
    /// <summary>
    /// Получить путь до файла с плагинами нанокада.
    /// </summary>
    /// <param name="name"> Имя нанокада. </param>
    /// <returns> Путь к ini файлу с плагинами. </returns>
    public static string GetPathToIniFile(string name)
    {
        var iniFilesDirectory = $@"{GetAssemblyDirectory()}\IniFiles";

        if (!Directory.Exists(iniFilesDirectory))
            Directory.CreateDirectory(iniFilesDirectory);

        var iniFileName = $@"{iniFilesDirectory}\{name}{IniFileUtils.INI_EXTENSIONS}";
        ;
        return File.Exists(iniFileName)
            ? iniFileName
            : IniFileUtils.CreateIniFile(iniFileName);
    }

    /// <summary>
    /// Получить Assembly Location.
    /// </summary>
    /// <returns> Путь Assembly Location. </returns>
    private static string? GetAssemblyDirectory()
    {
        var codeBase = Assembly.GetExecutingAssembly().Location;
        var uri = new UriBuilder(codeBase);
        var path = Uri.UnescapeDataString(uri.Path);
        return Path.GetDirectoryName(path);
    }
}