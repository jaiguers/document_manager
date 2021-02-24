using Domain.Context;
using Domain.Models;
using Domain.Repository.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace Domain.Repository
{
    public class MenuRepo : BaseRepository<Menu>
    {
        public MenuRepo(DomainContext context) : base(context)
        {
        }

        public override int Count()
        {
            try
            {
                return context.Menu.Count();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message, ex.InnerException);
            }
        }

        public override int Count(Expression<Func<Menu, bool>> predicate)
        {
            try
            {
                return context.Menu.Count(predicate);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message, ex.InnerException);
            }
        }

        public override long Create(Menu entity)
        {
            try
            {
                context.Menu.Add(entity);
                context.SaveChanges();

                return entity.Id;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message, ex.InnerException);
            }
        }

        public override Menu Get(long id)
        {
            try
            {
                return context.Menu.Where(j => j.Id == id).FirstOrDefault();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message, ex.InnerException);
            }
        }

        public override ICollection<Menu> Get()
        {
            try
            {
                return context.Menu.ToList();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message, ex.InnerException);
            }
        }

        public override ICollection<Menu> Get(Expression<Func<Menu, bool>> predicate)
        {
            try
            {
                return context.Menu.Where(predicate).ToList();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message, ex.InnerException);
            }
        }

        public override ICollection<Menu> Get(Expression<Func<Menu, bool>> predicate, int page, int size, Func<Menu, object> filterAttribute, bool descending)
        {
            return descending ? context.Menu.Where(predicate).Skip(page).Take(size).OrderByDescending(filterAttribute).ToList()
               : context.Menu.Where(predicate).Skip(page).Take(size).OrderBy(filterAttribute).ToList();
        }

        public override Menu GetFirst(Expression<Func<Menu, bool>> predicate)
        {
            try
            {
                return context.Menu.FirstOrDefault(predicate);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message, ex.InnerException);
            }
        }

        public override void Update(Menu entity)
        {
            try
            {
                context.Menu.Update(entity);
                context.SaveChanges();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message, ex.InnerException);
            }
        }
    }
}
