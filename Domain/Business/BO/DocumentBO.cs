using DocumentManager.CrossCutting.ApplicationModel;
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
    public class DocumentBO: IDocuments
    {
        private readonly DomainContext context;
        private readonly IMapper mapper;

        public DocumentBO(DomainContext context)
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
        /// Fecha: 2020-08-06
        /// </summary>
        public long Create(DocumentsAM entity)
        {
            try
            {
                var sancion = mapper.Map<Documents>(entity);

                IRepository<Documents> repo = new DocumentRepo(context);
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
        /// Fecha: 2020-08-06
        /// </summary>
        public int Count()
        {
            try
            {
                IRepository<Documents> repo = new DocumentRepo(context);
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
        /// Fecha: 2020-08-06
        /// </summary>
        public int Count(Expression<Func<DocumentsAM, bool>> predicate)
        {
            try
            {
                var where = mapper.MapExpression<Expression<Func<Documents, bool>>>(predicate);

                IRepository<Documents> repo = new DocumentRepo(context);
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
        /// Fecha: 2020-08-06
        /// </summary>
        public DocumentsAM Get(long id)
        {
            try
            {
                IRepository<Documents> repo = new DocumentRepo(context);
                var sancion = repo.Get(id);

                return mapper.Map<DocumentsAM>(sancion);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message, ex.InnerException);
            }
        }

        /// <summary>
        /// Obtener lista de Sancion
        /// Autor: Jair Guerrero
        /// Fecha: 2020-08-06
        /// </summary>
        public List<DocumentsAM> Get()
        {
            try
            {
                IRepository<Documents> repo = new DocumentRepo(context);
                var sancion = repo.Get();

                return mapper.Map<List<DocumentsAM>>(sancion);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message, ex.InnerException);
            }
        }

        /// <summary>
        /// Obtener lista de Sancion
        /// Autor: Jair Guerrero
        /// Fecha: 2020-08-06
        /// </summary>
        public List<DocumentsAM> Get(Expression<Func<DocumentsAM, bool>> predicate)
        {
            try
            {
                var where = mapper.MapExpression<Expression<Func<Documents, bool>>>(predicate);

                IRepository<Documents> repo = new DocumentRepo(context);
                var sancion = repo.Get(where);

                return mapper.Map<List<DocumentsAM>>(sancion);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message, ex.InnerException);
            }
        }

        /// <summary>
        /// Obtener primera Sancion según filtro
        /// Autor: Jair Guerrero
        /// Fecha: 2020-08-06
        /// </summary>
        public DocumentsAM GetFirst(Expression<Func<DocumentsAM, bool>> predicate)
        {
            try
            {
                var where = mapper.MapExpression<Expression<Func<Documents, bool>>>(predicate);

                IRepository<Documents> repo = new DocumentRepo(context);
                var sancion = repo.GetFirst(where);

                return mapper.Map<DocumentsAM>(sancion);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message, ex.InnerException);
            }
        }

        /// <summary>
        /// Actualizar Sancion
        /// Autor: Jair Guerrero
        /// Fecha: 2020-08-06
        /// </summary>
        public void Update(DocumentsAM entity)
        {
            try
            {
                var sancion = mapper.Map<Documents>(entity);

                IRepository<Documents> repo = new DocumentRepo(context);
                repo.Update(sancion);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message, ex.InnerException);
            }
        }
    }
}
