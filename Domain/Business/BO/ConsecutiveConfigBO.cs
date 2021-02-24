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
    public class ConsecutiveConfigBO : IConsecutiveConfig
    {
        private readonly DomainContext context;
        private readonly IMapper mapper;

        public ConsecutiveConfigBO(DomainContext context)
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
        /// Crear registro de ConsecutiveConfig
        /// Autor: Jair Guerrero
        /// Fecha: 2021-02-24
        /// </summary>
        public long Create(ConsecutiveConfigAM entity)
        {
            try
            {
                var ConsecutiveConfig = mapper.Map<ConsecutiveConfig>(entity);

                IRepository<ConsecutiveConfig> repo = new ConsecutiveConfigRepo(context);
                return repo.Create(ConsecutiveConfig);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message, ex.InnerException);
            }
        }

        /// <summary>
        /// Obtener cantidad de registros de ConsecutiveConfig
        /// Autor: Jair Guerrero
        /// Fecha: 2021-02-24
        /// </summary>
        public int Count()
        {
            try
            {
                IRepository<ConsecutiveConfig> repo = new ConsecutiveConfigRepo(context);
                return repo.Count();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message, ex.InnerException);
            }
        }

        /// <summary>
        /// Obtener cantidad de registros de ConsecutiveConfig según filtro
        /// Autor: Jair Guerrero
        /// Fecha: 2021-02-24
        /// </summary>
        public int Count(Expression<Func<ConsecutiveConfigAM, bool>> predicate)
        {
            try
            {
                var where = mapper.MapExpression<Expression<Func<ConsecutiveConfig, bool>>>(predicate);

                IRepository<ConsecutiveConfig> repo = new ConsecutiveConfigRepo(context);
                return repo.Count(where);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message, ex.InnerException);
            }
        }

        /// <summary>
        /// Obtener ConsecutiveConfig por Id
        /// Autor: Jair Guerrero
        /// Fecha: 2021-02-24
        /// </summary>
        public ConsecutiveConfigAM Get(long id)
        {
            try
            {
                IRepository<ConsecutiveConfig> repo = new ConsecutiveConfigRepo(context);
                var ConsecutiveConfig = repo.Get(id);

                return mapper.Map<ConsecutiveConfigAM>(ConsecutiveConfig);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message, ex.InnerException);
            }
        }

        /// <summary>
        /// Obtener lista de ConsecutiveConfig
        /// Autor: Jair Guerrero
        /// Fecha: 2021-02-24
        /// </summary>
        public List<ConsecutiveConfigAM> Get()
        {
            try
            {
                IRepository<ConsecutiveConfig> repo = new ConsecutiveConfigRepo(context);
                var ConsecutiveConfig = repo.Get();

                return mapper.Map<List<ConsecutiveConfigAM>>(ConsecutiveConfig);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message, ex.InnerException);
            }
        }

        /// <summary>
        /// Obtener lista de ConsecutiveConfig
        /// Autor: Jair Guerrero
        /// Fecha: 2021-02-24
        /// </summary>
        public List<ConsecutiveConfigAM> Get(Expression<Func<ConsecutiveConfigAM, bool>> predicate)
        {
            try
            {
                var where = mapper.MapExpression<Expression<Func<ConsecutiveConfig, bool>>>(predicate);

                IRepository<ConsecutiveConfig> repo = new ConsecutiveConfigRepo(context);
                var ConsecutiveConfig = repo.Get(where);

                return mapper.Map<List<ConsecutiveConfigAM>>(ConsecutiveConfig);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message, ex.InnerException);
            }
        }

        /// <summary>
        /// Obtener primera ConsecutiveConfig según filtro
        /// Autor: Jair Guerrero
        /// Fecha: 2021-02-24
        /// </summary>
        public ConsecutiveConfigAM GetFirst(Expression<Func<ConsecutiveConfigAM, bool>> predicate)
        {
            try
            {
                var where = mapper.MapExpression<Expression<Func<ConsecutiveConfig, bool>>>(predicate);

                IRepository<ConsecutiveConfig> repo = new ConsecutiveConfigRepo(context);
                var ConsecutiveConfig = repo.GetFirst(where);

                return mapper.Map<ConsecutiveConfigAM>(ConsecutiveConfig);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message, ex.InnerException);
            }
        }

        /// <summary>
        /// Actualizar ConsecutiveConfig
        /// Autor: Jair Guerrero
        /// Fecha: 2021-02-24
        /// </summary>
        public void Update(ConsecutiveConfigAM entity)
        {
            try
            {
                var ConsecutiveConfig = mapper.Map<ConsecutiveConfig>(entity);

                IRepository<ConsecutiveConfig> repo = new ConsecutiveConfigRepo(context);
                repo.Update(ConsecutiveConfig);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message, ex.InnerException);
            }
        }
    }
}
