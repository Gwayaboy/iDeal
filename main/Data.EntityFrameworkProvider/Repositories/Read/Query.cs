using System;
using System.Linq;
using System.Data.Entity;
using System.Linq.Expressions;
using Seterlund.CodeGuard;
using UIT.iDeal.Common.Interfaces.Data.Repositories.Read;
using UIT.iDeal.Data.EntityFrameworkProvider.Context;
using UIT.iDeal.Domain.Model.Base;

namespace UIT.iDeal.Data.EntityFrameworkProvider.Repositories.Read
{
    public class Query<T> : QueryWithTypedId<T,Guid>, IQuery<T>
        where T : Entity
    {
        public Query(DataContext context)
            : base(context)
        { }

        public override T Get(Guid id)
        {
            return GetOne(entity => entity.Id == id);
        }

        
    }
    
    public abstract class QueryWithTypedId<T,TId> : IQueryWithTypedId<T,TId> 
        where T : EntityWithTypedId<TId> 
    {
        public IDbSet<T> EntityCollection { get; set; }

        protected QueryWithTypedId(DataContext context)
        {
            Guard.That(context).IsNotNull();
            Context = context;
        }

        public virtual DataContext Context { get; private set; }

        public abstract T Get(TId id);

        public virtual IQueryable<T> GetAll(Expression<Func<T, bool>> predicate = null)
        {
            return QueryAllWith(predicate);
        }

        public virtual T GetOne(Expression<Func<T, bool>> predicate)
        {
            return Context.RetrieveSet<T>().SingleOrDefault(predicate);
        }

        public bool Exists(Expression<Func<T, bool>> predicate)
        {
            return GetOne(predicate) != null;
        }

        protected IQueryable<T> QueryAllWith(Expression<Func<T, bool>> predicate = null, params Expression<Func<T, object>>[] entitiesToBeincluded)
        {
            var query = Context.CreateQueryWith(entitiesToBeincluded);

            return (predicate == null) ? query : query.Where(predicate);
        }
    }
}