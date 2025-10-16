using GymManagement.DAL.Data.Context;
using GymManagement.DAL.Entites;
using GymManagement.DAL.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GymManagement.DAL.Repositories.Implementations
{
    public class GenericRepository<TEntity> : IGenericRepository<TEntity> where TEntity : BaseEntity
    {
        protected readonly GymDbContext dbContext;

        public GenericRepository(GymDbContext _dbContext)
        {
            dbContext = _dbContext;
        }

        public TEntity Create(TEntity entity)
        {
            dbContext.Set<TEntity>().Add(entity);
            return entity;
        }

        public TEntity Delete(TEntity entity)
        {
            dbContext.Set<TEntity>().Remove(entity);
            return entity;
        }

        public IQueryable<TEntity> GetAll()
        {
            return dbContext.Set<TEntity>().AsQueryable();
        }

        public TEntity GetById(int id)
        {
            return dbContext.Set<TEntity>().Find(id)!;
        }

        public TEntity Update(TEntity entity)
        {
            dbContext.Set<TEntity>().Update(entity);
            return entity;
        }
    }
}
