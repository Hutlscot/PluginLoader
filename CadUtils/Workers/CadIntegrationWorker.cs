namespace CadUtils.Workers;

using System.Collections.Generic;
using System.IO;
using System.Linq;

using CadUtils.Models;

/// <summary>
/// Работник интеграции в кад системы.
/// </summary>
public static class CadIntegrationWorker
{
    /// <summary>
    /// Метод интеграции.
    /// </summary>
    /// <param name="cadSystems"> Список установленных кад систем. </param>
    public static void Integration(List<CadSystem> cadSystems)
    {
        foreach (var cadSystem in cadSystems)
        {
            var nCadIniFile = cadSystem.NCadIniPath;
            var allLines = File.ReadAllLines(nCadIniFile).ToList();

            var isIntegration = allLines.Any(line => line.Contains(cadSystem.PathToIniFile));
            if (isIntegration)
                continue;

            var lineIntegration = $@"#include ""{cadSystem.PathToIniFile}""";
            allLines.Add(lineIntegration);

            File.WriteAllLines(nCadIniFile, allLines);
        }
    }
}