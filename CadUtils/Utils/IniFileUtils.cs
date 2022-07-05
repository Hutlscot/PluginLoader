namespace CadUtils.Utils;

using System.IO;
using System.Text;

/// <summary>
/// Помощник работы с ini файлами.
/// </summary>
public static class IniFileUtils
{
    /// <summary>
    /// Расширение для ini файлов.
    /// </summary>
    public const string INI_EXTENSIONS = ".ini";

    /// <summary>
    /// Создать ini файл.
    /// </summary>
    /// <param name="iniFileName"> Путь к ini файлу. </param>
    /// <returns> Путь к созданному ini файлу. </returns>
    public static string CreateIniFile(string iniFileName)
    {
        const string LoadCommandName = "[\\NetModules]\n";

        // через using, чтобы файл сразу был доступен для работы
        using (var fs = File.Create(iniFileName))
        {
            
            var buffer = Encoding.Default.GetBytes(LoadCommandName);
            fs.Write(buffer);
        }

        return iniFileName;
    }
}