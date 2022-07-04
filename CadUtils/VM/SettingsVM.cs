namespace CadUtils.VM;

using System.Collections.ObjectModel;
using System.Linq;

/// <summary>
/// Vm окна настроек кадов.
/// </summary>
public class SettingsVM
{
    /// <summary>
    /// Инициализация vm окна настроек нанокадов.
    /// </summary>
    public SettingsVM()
    {
        CadVersionsVMs = new ObservableCollection<CadVersionVM>();
        var cadVersions = NcadDictionary.Instance.InstallNcadVersions.ToList();
        cadVersions.ForEach(cadSystem => CadVersionsVMs.Add(new CadVersionVM(cadSystem)));
    }

    /// <summary>
    /// Список установленных версий кадов.
    /// </summary>
    public ObservableCollection<CadVersionVM> CadVersionsVMs { get; set; }

    /// <summary>
    /// Выбранный нанокад в списке.
    /// </summary>
    public CadVersionVM? SelectedCadVersionVM { get; set; }
}