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

    private Paths()
    {
        AssemblyDirectory = GetAssemblyDirectory();
        IniFilesDirectory = $@"{AssemblyDirectory}\IniFiles";
    }

    /// <summary>
    /// Путь до текущего каталога.
    /// </summary>
    private string? AssemblyDirectory { get; }

    public string IniFilesDirectory { get; set; }

    /// <summary>
    /// Словарь-синглтон всех систем NanoCAD.
    /// </summary>
    public static Paths Instance => _instance ??= new Paths();

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
    /// Получить путь до файла с плагинами нанокада.
    /// </summary>
    /// <param name="name"> Имя нанокада. </param>
    /// <returns> True - существует, false - иначе. </returns>
    public static string GetPathToIniFile(string name)
    {
        if (!Directory.Exists(Instance.IniFilesDirectory))
            Directory.CreateDirectory(Instance.IniFilesDirectory);

        var iniFileName = GetNameIniFile(name);
        if (!File.Exists(iniFileName))
            File.Create(iniFileName);

        return iniFileName;
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