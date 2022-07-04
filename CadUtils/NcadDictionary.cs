namespace CadUtils;

using System.Collections.Generic;
using System.Linq;

using CadUtils.Constants;
using CadUtils.Models;

/// <summary>
/// Словарь-синглтон всех систем NanoCAD.
/// </summary>
public class NcadDictionary
{
    private static NcadDictionary? _instance;

    /// <summary>
    /// Список всех доступных версий нанокадов.
    /// </summary>
    private readonly IEnumerable<CadSystem> _allNcadVersion;

    private NcadDictionary()
    {
        _allNcadVersion = new List<CadSystem>
        {
            new(ApplicationKeys.KEY_NCAD_PLUS_11_0, CadVersions.NCAD_PLUS_11_0),
            new(ApplicationKeys.KEY_NCAD_PLUS_11_1, CadVersions.NCAD_PLUS_11_1),
            new(ApplicationKeys.KEY_NCAD_PLUS_20_0, CadVersions.NCAD_PLUS_20_0),
            new(ApplicationKeys.KEY_NCAD_PLUS_20_1, CadVersions.NCAD_PLUS_20_1),
            new(ApplicationKeys.KEY_NCAD_PLUS_21_0, CadVersions.NCAD_PLUS_21_0),
            new(ApplicationKeys.KEY_NCAD_21_0, CadVersions.NCAD_21_0),
            new(ApplicationKeys.KEY_NCAD_22_0, CadVersions.NCAD_22_0)
        };
    }

    /// <summary>
    /// Список установленных версий нанокадов.
    /// </summary>
    public IEnumerable<CadSystem> InstallNcadVersions => _allNcadVersion.Where(v => v.IsInstall);

    /// <summary>
    /// Словарь-синглтон всех систем NanoCAD.
    /// </summary>
    public static NcadDictionary Instance => _instance ??= new NcadDictionary();
}