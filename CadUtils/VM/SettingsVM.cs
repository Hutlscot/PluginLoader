namespace CadUtils.VM;

using System.Collections.Generic;
using System.Windows.Input;

using CadUtils.Commands;
using CadUtils.Models;

/// <summary>
/// Vm окна настроек кадов.
/// </summary>
public class SettingsVM
{
    /// <summary>
    /// Инициализация vm окна настроек нанокадов.
    /// </summary>
    public SettingsVM()
    {
        CadVersions = NcadDictionary.Instance.InstallNcadVersions;
        AddPluginCommand = new AddPluginCommand();
        AddedPlugin = new AddedPluginVM();
    }

    public ICommand AddPluginCommand { get; set; }

    public AddedPluginVM AddedPlugin { get; set; }

    /// <summary>
    /// Список установленных версий кадов.
    /// </summary>
    public IEnumerable<CadSystem> CadVersions { get; set; }

    /// <summary>
    /// Выбранный нанокад в списке.
    /// </summary>
    public CadSystem? SelectedCadVersion { get; set; }
}

public class AddedPluginVM
{
    public string Name { get; set; }
    public string PathToDll { get; set; }
}