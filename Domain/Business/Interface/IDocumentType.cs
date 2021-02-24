using Abbott.CrossCutting.ApplicationModel;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;

namespace Domain.Business.Interface
{
    public interface IDocumentType
    {
        public long Create(DocumentTypeAM entity);
        public int Count();
        public int Count(Expression<Func<DocumentTypeAM, bool>> predicate);
        public DocumentTypeAM Get(long id);
        public List<DocumentTypeAM> Get();
        public List<DocumentTypeAM> Get(Expression<Func<DocumentTypeAM, bool>> predicate);
        public DocumentTypeAM GetFirst(Expression<Func<DocumentTypeAM, bool>> predicate);
        public void Update(DocumentTypeAM entity);
    }
}
