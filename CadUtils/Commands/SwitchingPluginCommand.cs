namespace CadUtils.Commands;

using CadUtils.Utils;
using CadUtils.VM;

/// <summary>
/// Команда включения/отключения кад плагина.
/// </summary>
public class SwitchingPluginCommand : BaseCommand
{
    /// <inheritdoc cref="SwitchingPluginCommand" />
    public override void Execute(object parameter)
    {
        var plugin = (CadPluginVM)parameter;

        //тут инверсия, т.к. после нажатия кнопки срабатывает set и приходит противоположное значение
        if (!plugin.CadPlugin.IsEnabled)
            plugin.CadPlugin.DisableCadPlugin();
        else
            plugin.CadPlugin.EnableCadPlugin();
    }
}