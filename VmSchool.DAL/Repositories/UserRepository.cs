using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using VmSchool.DAL.EF;
using VmSchool.DAL.Entities;
using VmSchool.DAL.Interfaces;

namespace VmSchool.DAL.Repositories
{
    public class UserRepository : IDatabaseRepository<User>
    {
        private readonly Context db;

        public UserRepository(Context db)
        {
            this.db = db;
        }

        public IEnumerable<User> ReadAll()
        {
            return db.Users;
        }

        public User Read(int id)
        {
            return db.Users.Find(id);
        }

        public IEnumerable<User> ReadByExpression(Expression<Func<User, bool>> predicate)
        {
            return db.Users.Where(predicate);
        }

        public void Create(User item)
        {
            db.Users.Add(item);
        }

        public void Update(User item)
        {
            db.Users.Update(item);
        }

        public void Delete(int id)
        {
            var item = db.Users.Find(id);

            if (item != null)
            {
                db.Users.Remove(item);
            }
        }
    }
}
