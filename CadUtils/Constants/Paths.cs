namespace CadUtils.Constants;

using System;
using System.IO;
using System.Reflection;

/// <summary>
/// Класс со всеми путями.
/// </summary>
public class Paths
{
    private static Paths? _instance;

    /// <inheritdoc cref="Paths"/>>
    private Paths()
    {
        AssemblyDirectory = GetAssemblyDirectory();
        IniFilesDirectory = $@"{AssemblyDirectory}\IniFiles";
    }

    /// <summary>
    /// Путь до текущего каталога.
    /// </summary>
    private string? AssemblyDirectory { get; }

    /// <summary>
    /// Путь до папки с ini файлами.
    /// </summary>
    private string IniFilesDirectory { get; set; }

    /// <summary>
    /// Словарь-синглтон всех систем NanoCAD.
    /// </summary>
    private static Paths Instance => _instance ??= new Paths();

    /// <summary>
    /// Получить путь до файла с плагинами нанокада.
    /// </summary>
    /// <param name="name"> Имя нанокада. </param>
    /// <returns> True - существует, false - иначе. </returns>
    public static string GetPathToIniFile(string name)
    {
        if (!Directory.Exists(Instance.IniFilesDirectory))
            Directory.CreateDirectory(Instance.IniFilesDirectory);

        var iniFileName = GetNameIniFile(name);
        if (File.Exists(iniFileName))
            return iniFileName;

        //через using, чтобы файл сразу был доступен для работы
        using var fs = File.Create(iniFileName);
        return iniFileName;
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

    /// <summary>
    /// Получить имя файла с плагинами.
    /// </summary>
    /// <param name="name"> Имя нанокада. </param>
    /// <returns> </returns>
    private static string GetNameIniFile(string name)
    {
        return $@"{Instance.IniFilesDirectory}\{name}.ini";
    }
}