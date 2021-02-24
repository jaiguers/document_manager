using Domain.Context;
using Domain.Models;
using Domain.Repository.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace Domain.Repository
{
    public class CityRepo : BaseRepository<City>
    {
        public CityRepo(DomainContext context) : base(context)
        {
        }

        public override int Count()
        {
            try
            {
                return context.City.Count();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message, ex.InnerException);
            }
        }

        public override int Count(Expression<Func<City, bool>> predicate)
        {
            try
            {
                return context.City.Count(predicate);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message, ex.InnerException);
            }
        }

        public override long Create(City entity)
        {
            try
            {
                context.City.Add(entity);
                context.SaveChanges();

                return entity.Id;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message, ex.InnerException);
            }
        }

        public override City Get(long id)
        {
            try
            {
                return context.City.Where(j => j.Id == id).FirstOrDefault();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message, ex.InnerException);
            }
        }

        public override ICollection<City> Get()
        {
            try
            {
                return context.City.ToList();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message, ex.InnerException);
            }
        }

        public override ICollection<City> Get(Expression<Func<City, bool>> predicate)
        {
            try
            {
                return context.City.Where(predicate).ToList();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message, ex.InnerException);
            }
        }

        public override ICollection<City> Get(Expression<Func<City, bool>> predicate, int page, int size, Func<City, object> filterAttribute, bool descending)
        {
            return descending ? context.City.Where(predicate).Skip(page).Take(size).OrderByDescending(filterAttribute).ToList()
               : context.City.Where(predicate).Skip(page).Take(size).OrderBy(filterAttribute).ToList();
        }

        public override City GetFirst(Expression<Func<City, bool>> predicate)
        {
            try
            {
                return context.City.FirstOrDefault(predicate);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message, ex.InnerException);
            }
        }

        public override void Update(City entity)
        {
            try
            {
                context.City.Update(entity);
                context.SaveChanges();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message, ex.InnerException);
            }
        }
    }
}
