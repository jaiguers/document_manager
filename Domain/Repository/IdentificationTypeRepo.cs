using Domain.Context;
using Domain.Models;
using Domain.Repository.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace Domain.Repository
{
    public class IdentificationTypeRepo : BaseRepository<IdentificationType>
    {
        public IdentificationTypeRepo(DomainContext context) : base(context)
        {
        }

        public override int Count()
        {
            try
            {
                return context.IdentificationType.Count();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message, ex.InnerException);
            }
        }

        public override int Count(Expression<Func<IdentificationType, bool>> predicate)
        {
            try
            {
                return context.IdentificationType.Count(predicate);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message, ex.InnerException);
            }
        }

        public override long Create(IdentificationType entity)
        {
            try
            {
                context.IdentificationType.Add(entity);
                context.SaveChanges();

                return entity.Id;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message, ex.InnerException);
            }
        }

        public override IdentificationType Get(long id)
        {
            try
            {
                return context.IdentificationType.Where(j => j.Id == id).FirstOrDefault();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message, ex.InnerException);
            }
        }

        public override ICollection<IdentificationType> Get()
        {
            try
            {
                return context.IdentificationType.ToList();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message, ex.InnerException);
            }
        }

        public override ICollection<IdentificationType> Get(Expression<Func<IdentificationType, bool>> predicate)
        {
            try
            {
                return context.IdentificationType.Where(predicate).ToList();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message, ex.InnerException);
            }
        }

        public override ICollection<IdentificationType> Get(Expression<Func<IdentificationType, bool>> predicate, int page, int size, Func<IdentificationType, object> filterAttribute, bool descending)
        {
            return descending ? context.IdentificationType.Where(predicate).Skip(page).Take(size).OrderByDescending(filterAttribute).ToList()
               : context.IdentificationType.Where(predicate).Skip(page).Take(size).OrderBy(filterAttribute).ToList();
        }

        public override IdentificationType GetFirst(Expression<Func<IdentificationType, bool>> predicate)
        {
            try
            {
                return context.IdentificationType.FirstOrDefault(predicate);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message, ex.InnerException);
            }
        }

        public override void Update(IdentificationType entity)
        {
            try
            {
                context.IdentificationType.Update(entity);
                context.SaveChanges();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message, ex.InnerException);
            }
        }
    }
}
