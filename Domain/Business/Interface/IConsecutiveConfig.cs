using Abbott.CrossCutting.ApplicationModel;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;

namespace Domain.Business.Interface
{
    public interface IConsecutiveConfig
    {
        public long Create(ConsecutiveConfigAM entity);
        public int Count();
        public int Count(Expression<Func<ConsecutiveConfigAM, bool>> predicate);
        public ConsecutiveConfigAM Get(long id);
        public List<ConsecutiveConfigAM> Get();
        public List<ConsecutiveConfigAM> Get(Expression<Func<ConsecutiveConfigAM, bool>> predicate);
        public ConsecutiveConfigAM GetFirst(Expression<Func<ConsecutiveConfigAM, bool>> predicate);
        public void Update(ConsecutiveConfigAM entity);
    }
}
