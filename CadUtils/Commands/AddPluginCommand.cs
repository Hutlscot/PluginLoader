namespace CadUtils.Commands;

using System;

using CadUtils.Models;
using CadUtils.Utils;
using CadUtils.VM;

/// <summary>
/// Команда добавления кад плагина.
/// </summary>
public class AddPluginCommand : TypedBaseCommand<CadVersionVM>
{
    /// <inheritdoc cref="AddPluginCommand" />
    protected override void Execute(CadVersionVM cadVersionVM)
    {
        var vm = cadVersionVM.AddedPluginVM;
        if (string.IsNullOrEmpty(vm.Name) || string.IsNullOrEmpty(vm.PathToDll) || vm.Name.Equals(vm.PathToDll))
            throw new ArgumentException("Переданы некорректные значения");

        var newCadPlugin = new CadPlugin(vm.Name, vm.PathToDll, vm.PathToIniFile);
        newCadPlugin.AddCadPlugin();
        cadVersionVM.CadPluginVMs.Add(new CadPluginVM(newCadPlugin, cadVersionVM));
    }
}