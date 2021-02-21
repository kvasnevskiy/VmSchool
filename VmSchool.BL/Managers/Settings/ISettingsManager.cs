using VmSchool.BL.Entities;

namespace VmSchool.BL.Managers.Settings
{
    public interface ISettingsManager
    {
        Setting GetSetting(string key);
        T GetValue<T>(string key);
    }
}