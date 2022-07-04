namespace CadUtils.Commands;

using CadUtils.VM;

/// <summary>
/// Команда добавления кад плагина.
/// </summary>
public class AddPluginCommand : BaseCommand
{
    public override void Execute(object parameter)
    {
        var vm = (SettingsVM)parameter;
        var selectedCad = vm.SelectedCadVersion;
        if (selectedCad == null)
            return;

        var name = vm.AddedPlugin.Name;
        var pathToDll = vm.AddedPlugin.PathToDll;
        selectedCad.AddCadPlugin(name, pathToDll);
    }
}