using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Interfaces
{
    public interface IApplicationDbContext : IDisposable
    {
        DbSet<User> Users { get; set; }
        DbSet<Customer> Customers { get; set; }
        DbSet<Gender> Genders { get; set; }
        DbSet<City> Cities { get; set; }
        DbSet<Region> Regions { get; set; }
        DbSet<Classification> Classifications { get; set; }
        Task<int> SaveChangesAsync(CancellationToken cancellationToken);
        IQueryable<TEntity> AsNoTracking<TEntity>() where TEntity : class;
        DbSet<TEntity> Set<TEntity>() where TEntity : class;
    }
}