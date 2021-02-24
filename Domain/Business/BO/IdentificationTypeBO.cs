using AutoMapper;
using AutoMapper.Extensions.ExpressionMapping;
using DocumentManager.CrossCutting.ApplicationModel;
using Domain.Business.Interface;
using Domain.Business.Profiles;
using Domain.Context;
using Domain.Models;
using Domain.Repository;
using Domain.Repository.Interface;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace Domain.Business.BO
{
    public class IdentificationTypeBO: IIdentificationType
    {
        private readonly DomainContext context;
        private readonly IMapper mapper;

        public IdentificationTypeBO(DomainContext context)
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
        public long Create(IdentificationTypeAM entity)
        {
            try
            {
                var sancion = mapper.Map<IdentificationType>(entity);

                IRepository<IdentificationType> repo = new IdentificationTypeRepo(context);
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
                IRepository<IdentificationType> repo = new IdentificationTypeRepo(context);
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
        public int Count(Expression<Func<IdentificationTypeAM, bool>> predicate)
        {
            try
            {
                var where = mapper.MapExpression<Expression<Func<IdentificationType, bool>>>(predicate);

                IRepository<IdentificationType> repo = new IdentificationTypeRepo(context);
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
        public IdentificationTypeAM Get(long id)
        {
            try
            {
                IRepository<IdentificationType> repo = new IdentificationTypeRepo(context);
                var sancion = repo.Get(id);

                return mapper.Map<IdentificationTypeAM>(sancion);
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
        public List<IdentificationTypeAM> Get()
        {
            try
            {
                IRepository<IdentificationType> repo = new IdentificationTypeRepo(context);
                var sancion = repo.Get();

                return mapper.Map<List<IdentificationTypeAM>>(sancion);
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
        public List<IdentificationTypeAM> Get(Expression<Func<IdentificationTypeAM, bool>> predicate)
        {
            try
            {
                var where = mapper.MapExpression<Expression<Func<IdentificationType, bool>>>(predicate);

                IRepository<IdentificationType> repo = new IdentificationTypeRepo(context);
                var sancion = repo.Get(where);

                return mapper.Map<List<IdentificationTypeAM>>(sancion);
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
        public IdentificationTypeAM GetFirst(Expression<Func<IdentificationTypeAM, bool>> predicate)
        {
            try
            {
                var where = mapper.MapExpression<Expression<Func<IdentificationType, bool>>>(predicate);

                IRepository<IdentificationType> repo = new IdentificationTypeRepo(context);
                var sancion = repo.GetFirst(where);

                return mapper.Map<IdentificationTypeAM>(sancion);
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
        public void Update(IdentificationTypeAM entity)
        {
            try
            {
                var sancion = mapper.Map<IdentificationType>(entity);

                IRepository<IdentificationType> repo = new IdentificationTypeRepo(context);
                repo.Update(sancion);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message, ex.InnerException);
            }
        }
    }
}
