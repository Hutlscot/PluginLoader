namespace CadUtils.VM;

using System.Collections.ObjectModel;
using System.Linq;

using CadUtils.Commands;
using CadUtils.Models;

/// <summary>
/// VM кад системы.
/// </summary>
public class CadVersionVM
{
    /// <summary>
    /// VM кад системы.
    /// </summary>
    /// <param name="cadSystem"> Кад система. </param>
    public CadVersionVM(CadSystem cadSystem)
    {
        CadRunCommand = new CadRunCommand();
        AddPluginCommand = new AddPluginCommand();
        CadPluginVMs = new ObservableCollection<CadPluginVM>();
        AddedPluginVM = new AddedPluginVM(cadSystem.PathToIniFile);

        CadSystem = cadSystem;
        var cadVersions = cadSystem.CadPlugins.ToList();
        cadVersions.ForEach(plugin => CadPluginVMs.Add(new CadPluginVM(plugin, this)));
    }

    public AddedPluginVM AddedPluginVM { get; set; }

    /// <summary>
    /// Команда добавления кад плагина.
    /// </summary>
    public AddPluginCommand AddPluginCommand { get; set; }

    /// <summary>
    /// Плагины для кад системы.
    /// </summary>
    public ObservableCollection<CadPluginVM> CadPluginVMs { get; set; }

    /// <summary>
    /// Команда запуска када.
    /// </summary>
    public CadRunCommand CadRunCommand { get; set; }

    /// <summary>
    /// Класс кад системы
    /// </summary>
    public CadSystem CadSystem { get; set; }
}