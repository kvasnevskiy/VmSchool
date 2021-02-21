using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using VmSchool.DAL.EF;
using VmSchool.DAL.Entities;
using VmSchool.DAL.Interfaces;

namespace VmSchool.DAL.Repositories
{
    public class SettingsRepository : IDatabaseRepository<Setting>
    {
        private readonly Context db;

        public SettingsRepository(Context db)
        {
            this.db = db;
        }

        public IEnumerable<Setting> ReadAll()
        {
            return db.Settings;
        }

        public Setting Read(int id)
        {
            return db.Settings.Find(id);
        }

        public IEnumerable<Setting> ReadByExpression(Expression<Func<Setting, bool>> predicate)
        {
            return db.Settings.Where(predicate);
        }

        public void Create(Setting item)
        {
            db.Settings.Add(item);
        }

        public void Update(Setting item)
        {
            db.Settings.Update(item);
        }

        public void Delete(int id)
        {
            var item = db.Settings.Find(id);

            if (item != null)
            {
                db.Settings.Remove(item);
            }
        }
    }
}
