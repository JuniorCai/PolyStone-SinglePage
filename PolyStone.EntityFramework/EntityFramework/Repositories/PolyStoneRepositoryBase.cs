using Abp.Domain.Entities;
using Abp.EntityFramework;
using Abp.EntityFramework.Repositories;

namespace PolyStone.EntityFramework.Repositories
{
    public abstract class PolyStoneRepositoryBase<TEntity, TPrimaryKey> : EfRepositoryBase<PolyStoneDbContext, TEntity, TPrimaryKey>
        where TEntity : class, IEntity<TPrimaryKey>
    {
        protected PolyStoneRepositoryBase(IDbContextProvider<PolyStoneDbContext> dbContextProvider)
            : base(dbContextProvider)
        {

        }

        //add common methods for all repositories
    }

    public abstract class PolyStoneRepositoryBase<TEntity> : PolyStoneRepositoryBase<TEntity, int>
        where TEntity : class, IEntity<int>
    {
        protected PolyStoneRepositoryBase(IDbContextProvider<PolyStoneDbContext> dbContextProvider)
            : base(dbContextProvider)
        {

        }

        //do not add any method here, add to the class above (since this inherits it)
    }
}
