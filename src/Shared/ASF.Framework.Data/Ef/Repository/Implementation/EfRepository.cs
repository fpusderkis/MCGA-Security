using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Validation;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using ASF.Framework.Data.Common.Context;
using ASF.Framework.Data.Common.Repository;
using ASF.Framework.Localization.Model.General;

namespace ASF.Framework.Data.Ef.Repository
{
    /// <summary>
    /// Entity Framework Repository
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class EfRepository<T> : BaseEfRepository, IEfRepository<T>, IRepository<T>, BaseRepository<T> where T : Entity
    {
        #region Ctor

        public EfRepository(IDbContext context)
            : base(context)
        {
        }

        #endregion

        #region Fields

        private IDbSet<T> _entities;

        /// <summary>
        /// Entities
        /// </summary>
        protected virtual IDbSet<T> Entities => _entities ?? (_entities = Context.Set<T>());

        #endregion


        public T GetById(object id)
        {
            return this.Entities.Find(id);
        }

        public void Insert(T entity)
        {
            try
            {
                if (entity == null)
                    throw new ArgumentNullException("entity");

                this.Entities.Add(entity);

                this.Context.SaveChanges();
            }
            catch (DbEntityValidationException dbEx)
            {
                throw new Exception(GetFullErrorText(dbEx), dbEx);
            }
        }

        public void Insert(IEnumerable<T> entities)
        {
            throw new NotImplementedException();
        }

        public void Update(T entity)
        {
            throw new NotImplementedException();
        }

        public void Update(IEnumerable<T> entities)
        {
            throw new NotImplementedException();
        }

        public void Delete(T entity)
        {
            throw new NotImplementedException();
        }

        public void Delete(IEnumerable<T> entities)
        {
            throw new NotImplementedException();
        }

        public IQueryable<T> Table { get; }
        public IQueryable<T> TableNoTracking { get; }
        public IEnumerable<TEntity> GetAll<TEntity>(Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>> orderBy = null, string includeProperties = null, int? skip = null, int? take = null) where TEntity : class
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<TEntity>> GetAllAsync<TEntity>(Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>> orderBy = null, string includeProperties = null, int? skip = null, int? take = null) where TEntity : class
        {
            throw new NotImplementedException();
        }

        public IEnumerable<TEntity> Get<TEntity>(Expression<Func<TEntity, bool>> filter = null, Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>> orderBy = null, string includeProperties = null,
            int? skip = null, int? take = null) where TEntity : class
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<TEntity>> GetAsync<TEntity>(Expression<Func<TEntity, bool>> filter = null, Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>> orderBy = null, string includeProperties = null, int? skip = null,
            int? take = null) where TEntity : class
        {
            throw new NotImplementedException();
        }

        public TEntity GetOne<TEntity>(Expression<Func<TEntity, bool>> filter = null, string includeProperties = null) where TEntity : class
        {
            throw new NotImplementedException();
        }

        public Task<TEntity> GetOneAsync<TEntity>(Expression<Func<TEntity, bool>> filter = null, string includeProperties = null) where TEntity : class
        {
            throw new NotImplementedException();
        }

        public TEntity GetFirst<TEntity>(Expression<Func<TEntity, bool>> filter = null, Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>> orderBy = null, string includeProperties = null) where TEntity : class
        {
            throw new NotImplementedException();
        }

        public Task<TEntity> GetFirstAsync<TEntity>(Expression<Func<TEntity, bool>> filter = null, Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>> orderBy = null, string includeProperties = null) where TEntity : class
        {
            throw new NotImplementedException();
        }

        public TEntity GetById<TEntity>(object id) where TEntity : class
        {
            throw new NotImplementedException();
        }

        public Task<TEntity> GetByIdAsync<TEntity>(object id) where TEntity : class
        {
            throw new NotImplementedException();
        }

        public int GetCount<TEntity>(Expression<Func<TEntity, bool>> filter = null) where TEntity : class
        {
            throw new NotImplementedException();
        }

        public Task<int> GetCountAsync<TEntity>(Expression<Func<TEntity, bool>> filter = null) where TEntity : class
        {
            throw new NotImplementedException();
        }

        public bool GetExists<TEntity>(Expression<Func<TEntity, bool>> filter = null) where TEntity : class
        {
            throw new NotImplementedException();
        }

        public Task<bool> GetExistsAsync<TEntity>(Expression<Func<TEntity, bool>> filter = null) where TEntity : class
        {
            throw new NotImplementedException();
        }

        public void Create<TEntity>(TEntity entity, string createdBy = null) where TEntity : Entity
        {
            throw new NotImplementedException();
        }

        public void Update<TEntity>(TEntity entity, string modifiedBy = null) where TEntity : class
        {
            throw new NotImplementedException();
        }

        public void Delete<TEntity>(object id) where TEntity : class
        {
            throw new NotImplementedException();
        }

        public void Delete<TEntity>(TEntity entity) where TEntity : class
        {
            throw new NotImplementedException();
        }

        public int Save()
        {
            throw new NotImplementedException();
        }

        public Task<int> SaveAsync()
        {
            throw new NotImplementedException();
        }

        #region Utilities

        private string GetFullErrorText(DbEntityValidationException dbEx)
        {
            throw new NotImplementedException();
        }

        #endregion
    }
}
