using Domain.Context;
using Domain.Models;
using Domain.Repository.Base;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace Domain.Repository
{
    public class ConsecutiveConfigRepo : BaseRepository<ConsecutiveConfig>
    {
        public ConsecutiveConfigRepo(DomainContext context) : base(context)
        {
        }

        public override int Count()
        {
            try
            {
                return context.ConsecutiveConfig.Count();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message, ex.InnerException);
            }
        }

        public override int Count(Expression<Func<ConsecutiveConfig, bool>> predicate)
        {
            try
            {
                return context.ConsecutiveConfig.Count(predicate);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message, ex.InnerException);
            }
        }

        public override long Create(ConsecutiveConfig entity)
        {
            try
            {
                context.ConsecutiveConfig.Add(entity);
                context.SaveChanges();

                return entity.Id;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message, ex.InnerException);
            }
        }

        public override ConsecutiveConfig Get(long id)
        {
            try
            {
                return context.ConsecutiveConfig.Where(j => j.Id == id).FirstOrDefault();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message, ex.InnerException);
            }
        }

        public override ICollection<ConsecutiveConfig> Get()
        {
            try
            {
                return context.ConsecutiveConfig.ToList();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message, ex.InnerException);
            }
        }

        public override ICollection<ConsecutiveConfig> Get(Expression<Func<ConsecutiveConfig, bool>> predicate)
        {
            try
            {
                return context.ConsecutiveConfig.Where(predicate).ToList();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message, ex.InnerException);
            }
        }

        public override ICollection<ConsecutiveConfig> Get(Expression<Func<ConsecutiveConfig, bool>> predicate, int page, int size, Func<ConsecutiveConfig, object> filterAttribute, bool descending)
        {
            return descending ? context.ConsecutiveConfig.Where(predicate).Skip(page).Take(size).OrderByDescending(filterAttribute).ToList()
               : context.ConsecutiveConfig.Where(predicate).Skip(page).Take(size).OrderBy(filterAttribute).ToList();
        }

        public override ConsecutiveConfig GetFirst(Expression<Func<ConsecutiveConfig, bool>> predicate)
        {
            try
            {
                return context.ConsecutiveConfig.FirstOrDefault(predicate);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message, ex.InnerException);
            }
        }

        public override void Update(ConsecutiveConfig data)
        {
            try
            {
                foreach (var entity in context.ChangeTracker.Entries())
                    entity.State = EntityState.Detached;

                context.ConsecutiveConfig.Update(data);
                context.SaveChanges();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message + ex.InnerException?.Message);
            }
        }
    }
}
