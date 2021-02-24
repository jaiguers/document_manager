using Abbott.CrossCutting.ApplicationModel;
using AutoMapper;
using AutoMapper.Extensions.ExpressionMapping;
using Domain.Business.Interface;
using Domain.Business.Profiles;
using Domain.Context;
using Domain.Models;
using Domain.Repository;
using Domain.Repository.Interface;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;

namespace Domain.Business.BO
{
    public class DocumentTypeBO: IDocumentType
    {
        private readonly DomainContext context;
        private readonly IMapper mapper;

        public DocumentTypeBO(DomainContext context)
        {
            this.context = context;

            var mapConfig = new MapperConfiguration(cfg =>
            {
                cfg.AddExpressionMapping();
                cfg.AddProfile<AdminProfile>();
            });

            mapper = new Mapper(mapConfig);
        }

        /// <summary>
        /// Crear registro de Sancion
        /// Autor: Jair Guerrero
        /// Fecha: 2020-12-05
        /// </summary>
        public long Create(DocumentTypeAM entity)
        {
            try
            {
                var sancion = mapper.Map<DocumentType>(entity);

                IRepository<DocumentType> repo = new DocumentTypeRepo(context);
                return repo.Create(sancion);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message, ex.InnerException);
            }
        }

        /// <summary>
        /// Obtener cantidad de registros de Sancion
        /// Autor: Jair Guerrero
        /// Fecha: 2020-12-05
        /// </summary>
        public int Count()
        {
            try
            {
                IRepository<DocumentType> repo = new DocumentTypeRepo(context);
                return repo.Count();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message, ex.InnerException);
            }
        }

        /// <summary>
        /// Obtener cantidad de registros de Sancion según filtro
        /// Autor: Jair Guerrero
        /// Fecha: 2020-12-05
        /// </summary>
        public int Count(Expression<Func<DocumentTypeAM, bool>> predicate)
        {
            try
            {
                var where = mapper.MapExpression<Expression<Func<DocumentType, bool>>>(predicate);

                IRepository<DocumentType> repo = new DocumentTypeRepo(context);
                return repo.Count(where);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message, ex.InnerException);
            }
        }

        /// <summary>
        /// Obtener Sancion por Id
        /// Autor: Jair Guerrero
        /// Fecha: 2020-12-05
        /// </summary>
        public DocumentTypeAM Get(long id)
        {
            try
            {
                IRepository<DocumentType> repo = new DocumentTypeRepo(context);
                var sancion = repo.Get(id);

                return mapper.Map<DocumentTypeAM>(sancion);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message, ex.InnerException);
            }
        }

        /// <summary>
        /// Obtener lista de Sancion
        /// Autor: Jair Guerrero
        /// Fecha: 2020-12-05
        /// </summary>
        public List<DocumentTypeAM> Get()
        {
            try
            {
                IRepository<DocumentType> repo = new DocumentTypeRepo(context);
                var sancion = repo.Get();

                return mapper.Map<List<DocumentTypeAM>>(sancion);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message, ex.InnerException);
            }
        }

        /// <summary>
        /// Obtener lista de Sancion
        /// Autor: Jair Guerrero
        /// Fecha: 2020-12-05
        /// </summary>
        public List<DocumentTypeAM> Get(Expression<Func<DocumentTypeAM, bool>> predicate)
        {
            try
            {
                var where = mapper.MapExpression<Expression<Func<DocumentType, bool>>>(predicate);

                IRepository<DocumentType> repo = new DocumentTypeRepo(context);
                var sancion = repo.Get(where);

                return mapper.Map<List<DocumentTypeAM>>(sancion);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message, ex.InnerException);
            }
        }

        /// <summary>
        /// Obtener primera Sancion según filtro
        /// Autor: Jair Guerrero
        /// Fecha: 2020-12-05
        /// </summary>
        public DocumentTypeAM GetFirst(Expression<Func<DocumentTypeAM, bool>> predicate)
        {
            try
            {
                var where = mapper.MapExpression<Expression<Func<DocumentType, bool>>>(predicate);

                IRepository<DocumentType> repo = new DocumentTypeRepo(context);
                var sancion = repo.GetFirst(where);

                return mapper.Map<DocumentTypeAM>(sancion);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message, ex.InnerException);
            }
        }

        /// <summary>
        /// Actualizar Sancion
        /// Autor: Jair Guerrero
        /// Fecha: 2020-12-05
        /// </summary>
        public void Update(DocumentTypeAM entity)
        {
            try
            {
                var sancion = mapper.Map<DocumentType>(entity);

                IRepository<DocumentType> repo = new DocumentTypeRepo(context);
                repo.Update(sancion);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message, ex.InnerException);
            }
        }
    }
}
