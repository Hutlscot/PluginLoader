namespace CadUtils.Commands;

using System.Diagnostics;
using System.IO;

using CadUtils.VM;

/// <summary>
/// Команда запуска када.
/// </summary>
public class CadRunCommand : BaseCommand
{
    /// <inheritdoc cref="CadRunCommand" />
    public override void Execute(object parameter)
    {
        var cadVersionVM = (CadVersionVM)parameter;
        if (File.Exists(cadVersionVM.CadSystem.ExePath))
            Process.Start(cadVersionVM.CadSystem.ExePath);
    }
}