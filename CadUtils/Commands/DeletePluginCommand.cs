namespace CadUtils.Commands;
using System.Windows;

using CadUtils.Models;
using CadUtils.Utils;

public class DeletePluginCommand : BaseCommand
{
    public override void Execute(object parameter)
    {
        var plugin = (CadPlugin)parameter;
        var dialogResult = MessageBox.Show($"Точно хотите удалить плагин {plugin.DisplayName}?", "Внимание!", MessageBoxButton.YesNo, MessageBoxImage.Warning);
        if (dialogResult == MessageBoxResult.Yes)
            plugin.DeleteCadPlugin();
    }
}