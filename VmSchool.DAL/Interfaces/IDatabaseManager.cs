using System;
using VmSchool.DAL.Entities;

namespace VmSchool.DAL.Interfaces
{
    public interface IDatabaseManager : IDisposable
    {
        IDatabaseRepository<Article> Articles { get; }
        void Save();
    }
}