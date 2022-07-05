namespace CadUtils.Models;

using System.Collections.Generic;
using System.IO;
using CadUtils.Utils;

/// <summary>
/// Класс кад-системы.
/// </summary>
public class CadSystem
{
    /// <summary>
    /// Инициализация класса кад-системы.
    /// </summary>
    /// <param name="registerKey"> Ключ регистра. </param>
    /// <param name="name"> Наименование системы. </param>
    public CadSystem(string registerKey, string name)
    {
        Name = name;
        PathToIniFile = PathsUtils.GetPathToIniFile(name);
        CadPlugins = GetCadPlugins(PathToIniFile);

        _installPath = NcadUtils.GetNcadLocationValue(registerKey) ?? string.Empty;
    }

    private readonly string? _installPath;

    /// <summary>
    /// Список кад плагинов.
    /// </summary>
    public List<CadPlugin> CadPlugins { get; set; }

    /// <summary>
    /// Путь до exe.
    /// </summary>
    public string ExePath => $@"{_installPath}nCad.exe";

    /// <summary>
    /// Путь до nCad.ini.
    /// </summary>
    public string NCadIniPath => $@"{_installPath}nCad.ini";

    /// <summary>
    /// True - если кад установлен.
    /// </summary>
    public bool IsInstall => !string.IsNullOrEmpty(_installPath);

    /// <summary>
    /// Наименование системы.
    /// </summary>
    public string Name { get; }

    /// <summary>
    /// Путь до ini файла c плагинами.
    /// </summary>
    public string PathToIniFile { get; }

    /// <summary>
    /// Заполнить список кад плагинов.
    /// </summary>
    /// <param name="pathToIniFile"> Пусть до ini файла с плагинами. </param>
    /// <returns> Список всех плагинов из ini файла. </returns>
    private static List<CadPlugin> GetCadPlugins(string pathToIniFile)
    {
        var cadPlugins = new List<CadPlugin>();
        using (var sr = new StreamReader(pathToIniFile))
        {
            while (true)
            {
                var name = sr.ReadLine();
                var pathToDll = sr.ReadLine();

                if (string.IsNullOrEmpty(name) || string.IsNullOrEmpty(pathToDll))
                    break;

                cadPlugins.Add(new CadPlugin(name, pathToDll, pathToIniFile));
            }
        }
        return cadPlugins;
    }
}