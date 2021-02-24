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
    public class DocumentRepo : BaseRepository<Documents>
    {
        public DocumentRepo(DomainContext context) : base(context)
        {
        }

        public override int Count()
        {
            try
            {
                return context.Document.Count();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message, ex.InnerException);
            }
        }

        public override int Count(Expression<Func<Documents, bool>> predicate)
        {
            try
            {
                return context.Document.Count(predicate);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message, ex.InnerException);
            }
        }

        public override long Create(Documents entity)
        {
            try
            {
                context.Document.Add(entity);
                context.SaveChanges();

                return entity.Id;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message, ex.InnerException);
            }
        }

        public override Documents Get(long id)
        {
            try
            {
                return context.Document.Where(j => j.Id == id).FirstOrDefault();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message, ex.InnerException);
            }
        }

        public override ICollection<Documents> Get()
        {
            try
            {
                return context.Document.Include(j => j.DocumentType).ToList();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message, ex.InnerException);
            }
        }

        public override ICollection<Documents> Get(Expression<Func<Documents, bool>> predicate)
        {
            try
            {
                return context.Document.Include(j => j.DocumentType).Where(predicate).ToList();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message, ex.InnerException);
            }
        }

        public override ICollection<Documents> Get(Expression<Func<Documents, bool>> predicate, int page, int size, Func<Documents, object> filterAttribute, bool descending)
        {
            return descending ? context.Document.Where(predicate).Skip(page).Take(size).OrderByDescending(filterAttribute).ToList()
               : context.Document.Where(predicate).Skip(page).Take(size).OrderBy(filterAttribute).ToList();
        }

        public override Documents GetFirst(Expression<Func<Documents, bool>> predicate)
        {
            try
            {
                return context.Document.FirstOrDefault(predicate);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message, ex.InnerException);
            }
        }

        public override void Update(Documents entity)
        {
            try
            {
                foreach (var _entity in context.ChangeTracker.Entries())
                    _entity.State = EntityState.Detached;

                context.Document.Update(entity);
                context.SaveChanges();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message + ex.InnerException?.Message);
            }
        }
    }
}
