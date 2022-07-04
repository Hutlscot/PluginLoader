namespace CadUtils.Commands;

using System.Diagnostics;
using System.IO;

using CadUtils.Models;

/// <summary>
/// Команда запуска када.
/// </summary>
public class CadRunCommand : BaseCommand
{
    ///<inheritdoc cref="CadRunCommand"/>
    public override void Execute(object parameter)
    {
        var cadVersionVM = (CadSystem)parameter;
        if (File.Exists(cadVersionVM.ExePath))
            Process.Start(cadVersionVM.ExePath);
    }
}