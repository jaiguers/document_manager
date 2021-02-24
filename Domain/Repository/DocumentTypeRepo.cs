using Domain.Context;
using Domain.Models;
using Domain.Repository.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace Domain.Repository
{
    public class DocumentTypeRepo : BaseRepository<DocumentType>
    {
        public DocumentTypeRepo(DomainContext context) : base(context)
        {
        }

        public override int Count()
        {
            try
            {
                return context.DocumentType.Count();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message, ex.InnerException);
            }
        }

        public override int Count(Expression<Func<DocumentType, bool>> predicate)
        {
            try
            {
                return context.DocumentType.Count(predicate);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message, ex.InnerException);
            }
        }

        public override long Create(DocumentType entity)
        {
            try
            {
                context.DocumentType.Add(entity);
                context.SaveChanges();

                return entity.Id;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message, ex.InnerException);
            }
        }

        public override DocumentType Get(long id)
        {
            try
            {
                return context.DocumentType.Where(j => j.Id == id).FirstOrDefault();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message, ex.InnerException);
            }
        }

        public override ICollection<DocumentType> Get()
        {
            try
            {
                return context.DocumentType.ToList();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message, ex.InnerException);
            }
        }

        public override ICollection<DocumentType> Get(Expression<Func<DocumentType, bool>> predicate)
        {
            try
            {
                return context.DocumentType.Where(predicate).ToList();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message, ex.InnerException);
            }
        }

        public override ICollection<DocumentType> Get(Expression<Func<DocumentType, bool>> predicate, int page, int size, Func<DocumentType, object> filterAttribute, bool descending)
        {
            return descending ? context.DocumentType.Where(predicate).Skip(page).Take(size).OrderByDescending(filterAttribute).ToList()
               : context.DocumentType.Where(predicate).Skip(page).Take(size).OrderBy(filterAttribute).ToList();
        }

        public override DocumentType GetFirst(Expression<Func<DocumentType, bool>> predicate)
        {
            try
            {
                return context.DocumentType.FirstOrDefault(predicate);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message, ex.InnerException);
            }
        }

        public override void Update(DocumentType entity)
        {
            try
            {
                context.DocumentType.Update(entity);
                context.SaveChanges();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message, ex.InnerException);
            }
        }
    }
}
