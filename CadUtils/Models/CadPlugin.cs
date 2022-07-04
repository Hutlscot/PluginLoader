namespace CadUtils.Models;

/// <summary>
/// Класс кад плагина.
/// </summary>
public class CadPlugin
{
    /// <summary>
    /// Инициализация класса кад плагина.
    /// </summary>
    /// <param name="name"> Имя плагина. </param>
    /// <param name="pathToDll"> Путь до dll плагина. </param>
    /// <param name="pathToIniFile">Путь до ini файла.</param>
    public CadPlugin(string name, string pathToDll, string pathToIniFile)
    {
        var validName = name.Replace("#", "");

        DisplayName = validName;
        Name = $"#{validName}";

        DisplayPathToDll = pathToDll.Replace("#", "");
        PathToDll = pathToDll;

        PathToIniFile = pathToIniFile;
        IsEnabled = !pathToDll.Contains("#");
    }

    /// <summary>
    /// True - если плагин включён.
    /// </summary>
    public bool IsEnabled { get; set; }

    /// <summary>
    /// Отображаемое имя.
    /// </summary>
    public string DisplayName { get; set; }

    /// <summary>
    /// Отображаемый путь к dll.
    /// </summary>
    public string DisplayPathToDll { get; set; }

    /// <summary>
    /// Имя кад плагина.
    /// </summary>
    public string Name { get; set; }

    /// <summary>
    /// Путь до dll плагина.
    /// </summary>
    public string PathToDll { get; set; }

    /// <summary>
    /// Путь до ini файла, откуда плагин загружен.
    /// </summary>
    public string PathToIniFile { get; }
}