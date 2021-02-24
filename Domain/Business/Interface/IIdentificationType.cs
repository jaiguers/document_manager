using DocumentManager.CrossCutting.ApplicationModel;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace Domain.Business.Interface
{
    public interface IIdentificationType
    {
        public long Create(IdentificationTypeAM entity);
        public int Count();
        public int Count(Expression<Func<IdentificationTypeAM, bool>> predicate);
        public IdentificationTypeAM Get(long id);
        public List<IdentificationTypeAM> Get();
        public List<IdentificationTypeAM> Get(Expression<Func<IdentificationTypeAM, bool>> predicate);
        public IdentificationTypeAM GetFirst(Expression<Func<IdentificationTypeAM, bool>> predicate);
        public void Update(IdentificationTypeAM entity);
    }
}
