namespace CadUtils.Models;

using System.Collections.Generic;

using CadUtils.Utils;

/// <summary>
/// Класс кад-системы.
/// </summary>
public class CadSystem
{
    private readonly string? _installPath;

    /// <summary>
    /// Инициализация класса кад-системы.
    /// </summary>
    /// <param name="registerKey"> Ключ регистра. </param>
    /// <param name="name"> Наименование системы. </param>
    public CadSystem(string registerKey, string name)
    {
        Name = name;
        PathToIniFile = PathsUtils.GetPathToIniFile(name);
        CadPlugins = IniFileUtils.GetPluginsFromIniFile(PathToIniFile);

        _installPath = NcadUtils.GetNcadLocationValue(registerKey) ?? string.Empty;
    }

    /// <summary>
    /// Список кад плагинов.
    /// </summary>
    public List<CadPlugin> CadPlugins { get; set; }

    /// <summary>
    /// Путь до exe.
    /// </summary>
    public string ExePath => $@"{_installPath}nCad.exe";

    /// <summary>
    /// True - если кад установлен.
    /// </summary>
    public bool IsInstall => !string.IsNullOrEmpty(_installPath);

    /// <summary>
    /// Наименование системы.
    /// </summary>
    public string Name { get; }

    /// <summary>
    /// Путь до nCad.ini.
    /// </summary>
    public string NCadIniPath => $@"{_installPath}nCad.ini";

    /// <summary>
    /// Путь до ini файла c плагинами.
    /// </summary>
    public string PathToIniFile { get; }
}