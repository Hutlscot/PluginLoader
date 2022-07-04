namespace CadUtils.Models;

using System.Collections.Generic;
using System.IO;
using System.Windows.Input;

using CadUtils.Commands;
using CadUtils.Constants;
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
        ExePath = NcadUtils.GetNcadLocationValue(registerKey) == null
            ? string.Empty
            : $@"{NcadUtils.GetNcadLocationValue(registerKey)}nCad.exe";

        PathToIniFile = Paths.GetPathToIniFile(name);
        SetCadPlugins(PathToIniFile);
        CadRunCommand = new CadRunCommand();
    }

    /// <summary>
    /// Путь до exe.
    /// </summary>
    public string ExePath { get; set; }

    /// <summary>
    /// Команда запуска нанокада.
    /// </summary>
    public ICommand CadRunCommand { get; set; }

    /// <summary>
    /// Наименование системы.
    /// </summary>
    public string Name { get; }

    /// <summary>
    /// True - если кад установлен.
    /// </summary>
    public bool IsInstall => !string.IsNullOrEmpty(ExePath);

    /// <summary>
    /// Путь до ini файла.
    /// </summary>
    private string PathToIniFile { get; }

    /// <summary>
    /// Список кад плагинов.
    /// </summary>
    public List<CadPlugin> CadPlugins { get; set; }

    /// <summary>
    /// Заполнить список кад плагинов.
    /// </summary>
    /// <param name="pathToIniFile">Пусть до ini файла с плагинами.</param>
    /// <returns>Список всех плагинов из ini файла.</returns>
    private void SetCadPlugins(string pathToIniFile)
    {
        CadPlugins = new List<CadPlugin>();
        using (var sr = new StreamReader(pathToIniFile))
        {
            while (true)
            {
                var name = sr.ReadLine();
                var pathToDll = sr.ReadLine();

                if (string.IsNullOrEmpty(name) || string.IsNullOrEmpty(pathToDll))
                    break;

                CadPlugins.Add(new CadPlugin(name, pathToDll, pathToIniFile));
            }
        }
    }

    /// <summary>
    /// Добавить cad плагин.
    /// </summary>
    /// <param name="name">Имя cad плагина.</param>
    /// <param name="pathToDll">Путь к dll. </param>
    public void AddCadPlugin(string name, string pathToDll)
    {
        var newCadPlugin = new CadPlugin(name, pathToDll, PathToIniFile);
        newCadPlugin.AddCadPlugin();
        SetCadPlugins(PathToIniFile);
    }
}