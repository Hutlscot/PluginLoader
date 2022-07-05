namespace CadUtils.Commands;

using System.Windows;

using CadUtils.Extensions;
using CadUtils.VM;

/// <summary>
/// Команда удаления кад плагина.
/// </summary>
public class DeletePluginCommand : TypedBaseCommand<CadPluginVM>
{
    /// <inheritdoc cref="DeletePluginCommand" />
    protected override void Execute(CadPluginVM cadPluginVM)
    {
        var plugin = cadPluginVM.CadPlugin;
        var dialogResult = MessageBox.Show($"Точно хотите удалить плагин {plugin.DisplayName}?", "Внимание!", MessageBoxButton.YesNo, MessageBoxImage.Warning);

        if (dialogResult != MessageBoxResult.Yes)
            return;

        plugin.DeleteCadPlugin();
        cadPluginVM.CadVersionVM.CadPluginVMs.Remove(cadPluginVM);
    }
}