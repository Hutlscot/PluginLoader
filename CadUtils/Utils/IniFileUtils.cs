namespace CadUtils.Utils;

using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

using CadUtils.Models;

/// <summary>
/// Помощник работы с ini файлами.
/// </summary>
public static class IniFileUtils
{
    /// <summary>
    /// Расширение для ini файлов.
    /// </summary>
    public const string INI_EXTENSIONS = ".ini";

    private const string LOAD_COMMAND_NAME = "[\\NetModules]";

    /// <summary>
    /// Создать ini файл.
    /// </summary>
    /// <param name="pathToIniFile"> Путь к ini файлу. </param>
    /// <returns> Путь к созданному ini файлу. </returns>
    public static string CreateIniFile(string pathToIniFile)
    {
        // через using, чтобы файл сразу был доступен для работы
        using (var fs = File.Create(pathToIniFile))
        {
            const string StartLine = $"{LOAD_COMMAND_NAME}\n";
            var buffer = Encoding.Default.GetBytes(StartLine);
            fs.Write(buffer);
        }

        return pathToIniFile;
    }

    /// <summary>
    /// Получить список кад плагинов из ini файла.
    /// </summary>
    /// <param name="pathToIniFile"> Пусть до ini файла с плагинами. </param>
    /// <returns> Список плагинов из ini файла. </returns>
    public static List<CadPlugin> GetPluginsFromIniFile(string pathToIniFile)
    {
        var cadPlugins = new List<CadPlugin>();
        using (var sr = new StreamReader(pathToIniFile))
        {
            while (true)
            {
                var name = sr.ReadLine();
                if (string.IsNullOrEmpty(name))
                    break;

                var isStartLine = name.Equals(LOAD_COMMAND_NAME);
                if (isStartLine)
                    continue;

                var pathToDll = sr.ReadLine();
                if (string.IsNullOrEmpty(pathToDll))
                    throw new Exception($"У плагина {name} потерялся путь.");

                cadPlugins.Add(new CadPlugin(name, pathToDll, pathToIniFile));
            }
        }

        return cadPlugins;
    }
}