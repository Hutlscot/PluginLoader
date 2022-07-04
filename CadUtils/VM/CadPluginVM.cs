namespace CadUtils.VM;

using CadUtils.Commands;
using CadUtils.Models;

/// <summary>
/// VM плагина.
/// </summary>
public class CadPluginVM
{
    public CadPluginVM(CadPlugin cadPlugin, CadVersionVM cadVersionVM)
    {
        CadVersionVM = cadVersionVM;
        CadPlugin = cadPlugin;
        DeletePluginCommand = new DeletePluginCommand();
        SwitchingPluginCommand = new SwitchingPluginCommand();
    }

    /// <summary>
    /// Кад плагин.
    /// </summary>
    public CadPlugin CadPlugin { get; set; }

    /// <summary>
    /// Ссылка на vm кад системы.
    /// </summary>
    public CadVersionVM CadVersionVM { get; set; }

    /// <summary>
    /// Команда удаления плагина.
    /// </summary>
    public DeletePluginCommand DeletePluginCommand { get; set; }

    /// <summary>
    /// Команда включение/отключения плагина.
    /// </summary>
    public SwitchingPluginCommand SwitchingPluginCommand { get; set; }
}