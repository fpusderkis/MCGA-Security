using ASF.Framework.Data.Common.Repository;

namespace ASF.Framework.Data.Ef
{
    public interface IEfRepository<TEntity> : IRepository<TEntity>, BaseRepository<TEntity>
    {
    }
}
