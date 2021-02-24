using DocumentManager.CrossCutting.ApplicationModel;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;

namespace Domain.Business.Interface
{
    public interface IDepartment
    {
        public long Create(DepartmentAM entity);
        public int Count();
        public int Count(Expression<Func<DepartmentAM, bool>> predicate);
        public DepartmentAM Get(long id);
        public List<DepartmentAM> Get();
        public List<DepartmentAM> Get(Expression<Func<DepartmentAM, bool>> predicate);
        public DepartmentAM GetFirst(Expression<Func<DepartmentAM, bool>> predicate);
        public void Update(DepartmentAM entity);
    }
}
