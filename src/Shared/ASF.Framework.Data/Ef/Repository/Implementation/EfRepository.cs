using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Validation;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using ASF.Framework.Data.Common.Context;
using ASF.Framework.Data.Common.Repository;
using ASF.Framework.Localization.Kernel.Common;

namespace ASF.Framework.Data.Ef.Repository
{
    /// <summary>
    /// Entity Framework Repository
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class EfRepository<TEntity> : BaseEfRepository, IEfRepository<TEntity>, IRepository<TEntity>, BaseRepository<TEntity>
        where TEntity : EntityBase
    {
        #region Ctor

        public EfRepository(IDbContext context)
            : base(context)
        {
        }

        #endregion

        #region Fields

        private IDbSet<TEntity> _entities;

        /// <summary>
        /// Entities
        /// </summary>
        protected virtual IDbSet<TEntity> Entities => _entities ?? (_entities = Context.Set<TEntity>());

        public IQueryable<TEntity> Table => Entities;

        public IQueryable<TEntity> TableNoTracking => this.Entities.AsNoTracking();

        #endregion


        #region Utilities

        private string GetFullErrorText(DbEntityValidationException dbEx)
        {
            return dbEx.EntityValidationErrors
               .SelectMany(validationErrors => validationErrors.ValidationErrors)
               .Aggregate(string.Empty, (current, error) => current + (string.Format("Property: {0} Error: {1}", error.PropertyName, error.ErrorMessage) + Environment.NewLine));
        }

        #endregion

        #region Public Methods


        public virtual TEntity GetById(object id)
        {
            return this.Entities.Find(id);
        }
        
        public virtual IEnumerable<TEntity> GetAll(Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>> orderBy = null, string includeProperties = null, int? skip = default(int?), int? take = default(int?))
        {
            return this.GetQueryable(null, orderBy, includeProperties, skip, take).ToList();
        }

        public virtual async Task<IEnumerable<TEntity>> GetAllAsync(Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>> orderBy = null, string includeProperties = null, int? skip = default(int?), int? take = default(int?))
        {
            return await this.GetQueryable(null, orderBy, includeProperties, skip, take).ToListAsync();
        }

        public virtual IEnumerable<TEntity> Get(Expression<Func<TEntity, bool>> filter = null, Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>> orderBy = null, string includeProperties = null, int? skip = default(int?), int? take = default(int?))
        {
            return this.GetQueryable(filter, orderBy, includeProperties, skip, take).ToList();
        }

        public virtual async Task<IEnumerable<TEntity>> GetAsync(Expression<Func<TEntity, bool>> filter = null, Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>> orderBy = null, string includeProperties = null, int? skip = default(int?), int? take = default(int?))
        {
            return await this.GetQueryable(filter, orderBy, includeProperties, skip, take).ToListAsync();
        }

        public virtual TEntity GetOne(Expression<Func<TEntity, bool>> filter = null, string includeProperties = null)
        {
            return GetQueryable(filter, null, includeProperties).FirstOrDefault();
        }

        public virtual async Task<TEntity> GetOneAsync(Expression<Func<TEntity, bool>> filter = null, string includeProperties = null)
        {
            return await GetQueryable(filter, null, includeProperties).FirstOrDefaultAsync();
        }

        public virtual TEntity GetFirst(Expression<Func<TEntity, bool>> filter = null, Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>> orderBy = null, string includeProperties = null)
        {
            return this.GetQueryable(filter, orderBy, includeProperties).FirstOrDefault();
        }

        public virtual async Task<TEntity> GetFirstAsync(Expression<Func<TEntity, bool>> filter = null, Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>> orderBy = null, string includeProperties = null)
        {
            return await this.GetQueryable(filter, orderBy, includeProperties).FirstOrDefaultAsync();
        }

        public virtual async Task<TEntity> GetByIdAsync(object id)
        {
            return await this.Table.FirstAsync(x => x.Id == (long)id);
        }

        public virtual int GetCount(Expression<Func<TEntity, bool>> filter = null)
        {
            return this.GetQueryable(filter).Count();
        }

        public virtual async Task<int> GetCountAsync(Expression<Func<TEntity, bool>> filter = null)
        {
            return await GetQueryable(filter).CountAsync();
        }

        public virtual bool GetExists(Expression<Func<TEntity, bool>> filter = null)
        {
            return GetQueryable(filter).Any();
        }

        public virtual async Task<bool> GetExistsAsync(Expression<Func<TEntity, bool>> filter = null)
        {
            return await GetQueryable(filter).AnyAsync();
        }

        public virtual void Create(TEntity entity)
        {
            this.Entities.Add(entity);
        }

        public virtual void Update(TEntity entity)
        {
            this.Entities.Attach(entity);
            this.Context.SetEntityState(entity, EntityState.Modified);
        }

        public virtual void Delete(object id)
        {
            var entity = this.Entities.Find(id);
            this.Entities.Remove(entity);
        }

        public virtual void Delete(TEntity entity)
        {
            if (Context.Entry(entity).State == EntityState.Detached)
            {
                Entities.Attach(entity);
            }
            Entities.Remove(entity);
        }

        #endregion

        #region Utilities

        protected virtual IQueryable<TEntity> GetQueryable(
            Expression<Func<TEntity, bool>> filter = null,
            Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>> orderBy = null,
            string includeProperties = null,
            int? skip = null,
            int? take = null)
        {
            includeProperties = includeProperties ?? string.Empty;
            IQueryable<TEntity> query = Table;

            if (filter != null)
            {
                query = Table.Where(filter);
            }

            foreach (var includeProperty in includeProperties.Split
                (new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries))
            {
                query = query.Include(includeProperty);
            }

            if (orderBy != null)
            {
                query = orderBy(query);
            }

            if (skip.HasValue)
            {
                query = query.Skip(skip.Value);
            }

            if (take.HasValue)
            {
                query = query.Take(take.Value);
            }

            return query;
        }


        #endregion
    }
}
