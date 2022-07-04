namespace CadUtils.Commands;
using CadUtils.Models;
using CadUtils.Utils;

/// <summary>
/// Команда включения/отключения плагина.
/// </summary>
public class SwitchingPluginCommand : BaseCommand
{
    public override void Execute(object parameter)
    {
        var plugin = (CadPlugin)parameter;

        //тут инверсия, т.к. после нажатия кнопки срабатывает set и приходит противоположное значение
        if (!plugin.IsEnabled)
            plugin.DisableCadPlugin();
        else
            plugin.EnableCadPlugin();
    }
}