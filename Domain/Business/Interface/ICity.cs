using DocumentManager.CrossCutting.ApplicationModel;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;

namespace Domain.Business.Interface
{
    public interface ICity
    {
        public long Create(CityAM entity);
        public int Count();
        public int Count(Expression<Func<CityAM, bool>> predicate);
        public CityAM Get(long id);
        public List<CityAM> Get();
        public List<CityAM> Get(Expression<Func<CityAM, bool>> predicate);
        public CityAM GetFirst(Expression<Func<CityAM, bool>> predicate);
        public void Update(CityAM entity);
    }
}
