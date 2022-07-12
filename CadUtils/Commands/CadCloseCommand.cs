namespace CadUtils.Commands;

using CadUtils.VM;
using System.Diagnostics;

/// <summary>
/// Команда остановки када.
/// </summary>

public class CadCloseCommand : TypedBaseCommand<CadVersionVM>
{
    /// <inheritdoc cref="CadCloseCommand" />
    protected override void Execute(CadVersionVM parameter)
    {
        var procs = Process.GetProcessesByName("nCAD");

        foreach (var proc in procs)
        {
            using var chosen = Process.GetProcessById(proc.Id);
            chosen.Kill();
        }
    }
}

