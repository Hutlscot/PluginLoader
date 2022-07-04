namespace CadUtils.VM;

/// <summary>
/// VM добавляемого плагина.
/// </summary>
public class AddedPluginVM
{
    /// <inheritdoc cref="AddedPluginVM" />
    public AddedPluginVM(string pathToIniFile)
    {
        Name = string.Empty;
        PathToDll = string.Empty;
        PathToIniFile = pathToIniFile;
    }

    /// <summary>
    /// Имя.
    /// </summary>
    public string Name { get; set; }

    /// <summary>
    /// Путь до dll.
    /// </summary>
    public string PathToDll { get; set; }

    /// <summary>
    /// Путь до .ini файла.
    /// </summary>
    public string PathToIniFile { get; set; }
}