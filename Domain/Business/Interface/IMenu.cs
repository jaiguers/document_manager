using Abbott.CrossCutting.ApplicationModel;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;

namespace Domain.Business.Interface
{
    public interface IMenu
    {
        public long Create(MenuAM entity);
        public int Count();
        public int Count(Expression<Func<MenuAM, bool>> predicate);
        public MenuAM Get(long id);
        public List<MenuAM> Get();
        public List<MenuAM> Get(Expression<Func<MenuAM, bool>> predicate);
        public MenuAM GetFirst(Expression<Func<MenuAM, bool>> predicate);
        public void Update(MenuAM entity);
    }
}
