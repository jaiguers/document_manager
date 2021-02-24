using DocumentManager.CrossCutting.ApplicationModel;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;

namespace Domain.Business.Interface
{
    public interface IDocuments
    {
        public long Create(DocumentsAM entity);
        public int Count();
        public int Count(Expression<Func<DocumentsAM, bool>> predicate);
        public DocumentsAM Get(long id);
        public List<DocumentsAM> Get();
        public List<DocumentsAM> Get(Expression<Func<DocumentsAM, bool>> predicate);
        public DocumentsAM GetFirst(Expression<Func<DocumentsAM, bool>> predicate);
        public void Update(DocumentsAM entity);
    }
}
