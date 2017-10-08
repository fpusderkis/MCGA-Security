using ASF.Framework.Data.Common.Context;

namespace ASF.Framework.Data.Ef.Repository
{
    public abstract class BaseEfRepository
    {
        protected BaseEfRepository(IDbContext context)
        {
            Context = context;
        }

        protected IDbContext Context { get; }
    }
}
