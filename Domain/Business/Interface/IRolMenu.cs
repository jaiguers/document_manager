using DocumentManager.CrossCutting.ApplicationModel;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace Domain.Business.Interface
{
    public interface IRolMenu
    {
        public long Create(RolMenuAM entity);
        public int Count();
        public int Count(Expression<Func<RolMenuAM, bool>> predicate);
        public RolMenuAM Get(long id);
        public List<RolMenuAM> Get();
        public List<RolMenuAM> Get(Expression<Func<RolMenuAM, bool>> predicate);
        public RolMenuAM GetFirst(Expression<Func<RolMenuAM, bool>> predicate);
        public void Update(RolMenuAM entity);

    }
}
