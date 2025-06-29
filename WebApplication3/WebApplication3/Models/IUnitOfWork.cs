//-
using System;


namespace WebApplication3.Models;

public interface IUnitOfWork : IDisposable
{
    int SaveChanges(bool ensureAutoHistory = false);

    IRepository<TEntity> GetRepository<TEntity>(bool hasCustomRepository = true) where TEntity : class;
}
