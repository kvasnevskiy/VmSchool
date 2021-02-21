using System;
using System.Linq;
using AutoMapper;
using VmSchool.BL.Entities;
using VmSchool.DAL.Interfaces;

namespace VmSchool.BL.Managers.Settings
{
    public class SettingsManagerModel : ISettingsManager
    {
        private readonly IDatabaseManager databaseManager;
        private readonly Mapper mapper;

        #region Constructors

        public SettingsManagerModel(IDatabaseManager databaseManager)
        {
            this.databaseManager = databaseManager;
            mapper = new Mapper(new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<DAL.Entities.Setting, Setting>();
            }));
        }

        #endregion

        public Setting GetSetting(string key)
        {
            return mapper.Map<Setting>(databaseManager.Settings.ReadByExpression(setting => setting.Key == key).FirstOrDefault());
        }

        public T GetValue<T>(string key)
        {
            var setting = GetSetting(key);

            if (setting != null && setting.Type == typeof(T).ToString())
            {
                return (T)Convert.ChangeType(setting.Value, typeof(T));
            }

            return default;
        }
    }
}
