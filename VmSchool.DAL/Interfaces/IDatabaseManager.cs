using System;
using VmSchool.DAL.Entities;

namespace VmSchool.DAL.Interfaces
{
    public interface IDatabaseManager : IDisposable
    {
        IDatabaseRepository<User> Users { get; }
        IDatabaseRepository<Article> Articles { get; }
        IDatabaseRepository<ArticleCategory> ArticleCategories { get; }
        IDatabaseRepository<Gallery> Galleries { get; }
        IDatabaseRepository<GalleryImage> GalleryImages { get; }
        void Save();
    }
}