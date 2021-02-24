using Abbott.CrossCutting.ApplicationModel;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;

namespace Domain.Business.Interface
{
    public interface IPerson
    {
        public long Create(PersonAM entity);
        public int Count();
        public int Count(Expression<Func<PersonAM, bool>> predicate);
        public PersonAM Get(long id);
        public List<PersonAM> Get();
        public List<PersonAM> Get(Expression<Func<PersonAM, bool>> predicate);
        public PersonAM GetFirst(Expression<Func<PersonAM, bool>> predicate);
        public void Update(PersonAM entity);
    }
}
