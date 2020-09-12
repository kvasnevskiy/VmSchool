using System;
using VmSchool.DAL.Entities;

namespace VmSchool.DAL.Interfaces
{
    public interface IDatabaseManager : IDisposable
    {
        IDatabaseRepository<Article> Articles { get; }
        IDatabaseRepository<Gallery> Galleries { get; }
        IDatabaseRepository<GalleryImage> GalleryImages { get; }
        void Save();
    }
}