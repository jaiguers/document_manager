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
    public class StatesRepo : BaseRepository<States>
    {
        public StatesRepo(DomainContext context) : base(context)
        {
        }

        public override int Count()
        {
            try
            {
                return context.States.Count();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message, ex.InnerException);
            }
        }

        public override int Count(Expression<Func<States, bool>> predicate)
        {
            try
            {
                return context.States.Count(predicate);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message, ex.InnerException);
            }
        }

        public override long Create(States entity)
        {
            try
            {
                context.States.Add(entity);
                context.SaveChanges();

                return entity.Id;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message, ex.InnerException);
            }
        }

        public override States Get(long id)
        {
            try
            {
                return context.States.Where(j => j.Id == id).FirstOrDefault();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message, ex.InnerException);
            }
        }

        public override ICollection<States> Get()
        {
            try
            {
                return context.States.ToList();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message, ex.InnerException);
            }
        }

        public override ICollection<States> Get(Expression<Func<States, bool>> predicate)
        {
            try
            {
                return context.States.Where(predicate).ToList();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message, ex.InnerException);
            }
        }

        public override ICollection<States> Get(Expression<Func<States, bool>> predicate, int page, int size, Func<States, object> filterAttribute, bool descending)
        {
            return descending ? context.States.Where(predicate).Skip(page).Take(size).OrderByDescending(filterAttribute).ToList()
               : context.States.Where(predicate).Skip(page).Take(size).OrderBy(filterAttribute).ToList();
        }

        public override States GetFirst(Expression<Func<States, bool>> predicate)
        {
            try
            {
                return context.States.FirstOrDefault(predicate);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message, ex.InnerException);
            }
        }

        public override void Update(States entity)
        {
            try
            {
                context.States.Update(entity);
                context.SaveChanges();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message, ex.InnerException);
            }
        }
    }
}
