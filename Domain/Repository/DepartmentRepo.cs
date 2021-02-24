using Domain.Context;
using Domain.Models;
using Domain.Repository.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace Domain.Repository
{
    public class DepartmentRepo : BaseRepository<Department>
    {
        public DepartmentRepo(DomainContext context) : base(context)
        {
        }

        public override int Count()
        {
            try
            {
                return context.Department.Count();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message, ex.InnerException);
            }
        }

        public override int Count(Expression<Func<Department, bool>> predicate)
        {
            try
            {
                return context.Department.Count(predicate);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message, ex.InnerException);
            }
        }

        public override long Create(Department entity)
        {
            try
            {
                context.Department.Add(entity);
                context.SaveChanges();

                return entity.Id;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message, ex.InnerException);
            }
        }

        public override Department Get(long id)
        {
            try
            {
                return context.Department.Where(j => j.Id == id).FirstOrDefault();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message, ex.InnerException);
            }
        }

        public override ICollection<Department> Get()
        {
            try
            {
                return context.Department.ToList();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message, ex.InnerException);
            }
        }

        public override ICollection<Department> Get(Expression<Func<Department, bool>> predicate)
        {
            try
            {
                return context.Department.Where(predicate).ToList();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message, ex.InnerException);
            }
        }

        public override ICollection<Department> Get(Expression<Func<Department, bool>> predicate, int page, int size, Func<Department, object> filterAttribute, bool descending)
        {
            return descending ? context.Department.Where(predicate).Skip(page).Take(size).OrderByDescending(filterAttribute).ToList()
               : context.Department.Where(predicate).Skip(page).Take(size).OrderBy(filterAttribute).ToList();
        }

        public override Department GetFirst(Expression<Func<Department, bool>> predicate)
        {
            try
            {
                return context.Department.FirstOrDefault(predicate);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message, ex.InnerException);
            }
        }

        public override void Update(Department entity)
        {
            try
            {
                context.Department.Update(entity);
                context.SaveChanges();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message, ex.InnerException);
            }
        }
    }
}
