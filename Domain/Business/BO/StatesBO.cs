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
    public class StatesBO : IStates
    {
        private readonly DomainContext context;
        private readonly IMapper mapper;

        public StatesBO(DomainContext context)
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
        public long Create(StatesAM entity)
        {
            try
            {
                var sancion = mapper.Map<States>(entity);

                IRepository<States> repo = new StatesRepo(context);
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
                IRepository<States> repo = new StatesRepo(context);
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
        public int Count(Expression<Func<StatesAM, bool>> predicate)
        {
            try
            {
                var where = mapper.MapExpression<Expression<Func<States, bool>>>(predicate);

                IRepository<States> repo = new StatesRepo(context);
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
        public StatesAM Get(long id)
        {
            try
            {
                IRepository<States> repo = new StatesRepo(context);
                var sancion = repo.Get(id);

                return mapper.Map<StatesAM>(sancion);
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
        public List<StatesAM> Get()
        {
            try
            {
                IRepository<States> repo = new StatesRepo(context);
                var sancion = repo.Get();

                return mapper.Map<List<StatesAM>>(sancion);
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
        public List<StatesAM> Get(Expression<Func<StatesAM, bool>> predicate)
        {
            try
            {
                var where = mapper.MapExpression<Expression<Func<States, bool>>>(predicate);

                IRepository<States> repo = new StatesRepo(context);
                var sancion = repo.Get(where);

                return mapper.Map<List<StatesAM>>(sancion);
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
        public StatesAM GetFirst(Expression<Func<StatesAM, bool>> predicate)
        {
            try
            {
                var where = mapper.MapExpression<Expression<Func<States, bool>>>(predicate);

                IRepository<States> repo = new StatesRepo(context);
                var sancion = repo.GetFirst(where);

                return mapper.Map<StatesAM>(sancion);
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
        public void Update(StatesAM entity)
        {
            try
            {
                var sancion = mapper.Map<States>(entity);

                IRepository<States> repo = new StatesRepo(context);
                repo.Update(sancion);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message, ex.InnerException);
            }
        }
    }
}
