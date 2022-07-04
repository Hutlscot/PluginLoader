namespace CadUtils.Utils;

using System;

using Microsoft.Win32;

public static class NcadUtils
{
    /// <summary>
    /// Получить путь до приложения Ncad.
    /// </summary>
    /// <param name="registerKey"> Ключ реестра системы. </param>
    /// <returns> Найденный путь до приложения, либо null, если пути нет. </returns>
    public static string? GetNcadLocationValue(string registerKey)
    {
        if (string.IsNullOrEmpty(registerKey))
            throw new ArgumentException($"Неверно переданны параметры {registerKey}");

        //Корневой ключ реестра.
        var view64 = RegistryKey.OpenBaseKey(RegistryHive.LocalMachine, RegistryView.Registry64);

        var registryKey = view64.OpenSubKey(registerKey);
        var locationValue = registryKey?.GetValue("InstallLocation", null);
        return locationValue?.ToString();
    }
}