using Domain.Context;
using Domain.Models;
using Domain.Repository.Base;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace Domain.Repository
{
    public class RolMenuRepo : BaseRepository<RolMenu>
    {
        public RolMenuRepo(DomainContext context) : base(context)
        {
        }

        public override int Count()
        {
            try
            {
                return context.RolMenu.Count();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message, ex.InnerException);
            }
        }

        public override int Count(Expression<Func<RolMenu, bool>> predicate)
        {
            try
            {
                return context.RolMenu.Count(predicate);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message, ex.InnerException);
            }
        }

        public override long Create(RolMenu entity)
        {
            try
            {
                context.RolMenu.Add(entity);
                context.SaveChanges();

                return entity.Id;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message, ex.InnerException);
            }
        }

        public override RolMenu Get(long id)
        {
            try
            {
                return context.RolMenu.Where(j => j.Id == id).FirstOrDefault();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message, ex.InnerException);
            }
        }

        public override ICollection<RolMenu> Get()
        {
            try
            {
                return context.RolMenu.ToList();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message, ex.InnerException);
            }
        }

        public override ICollection<RolMenu> Get(Expression<Func<RolMenu, bool>> predicate)
        {
            try
            {
                return context.RolMenu.Include(j => j.Menu).Where(predicate).ToList();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message, ex.InnerException);
            }
        }

        public override ICollection<RolMenu> Get(Expression<Func<RolMenu, bool>> predicate, int page, int size, Func<RolMenu, object> filterAttribute, bool descending)
        {
            return descending ? context.RolMenu.Where(predicate).Skip(page).Take(size).OrderByDescending(filterAttribute).ToList()
               : context.RolMenu.Where(predicate).Skip(page).Take(size).OrderBy(filterAttribute).ToList();
        }

        public override RolMenu GetFirst(Expression<Func<RolMenu, bool>> predicate)
        {
            try
            {
                return context.RolMenu.FirstOrDefault(predicate);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message, ex.InnerException);
            }
        }

        public override void Update(RolMenu entity)
        {
            try
            {
                context.RolMenu.Update(entity);
                context.SaveChanges();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message, ex.InnerException);
            }
        }
    }
}
