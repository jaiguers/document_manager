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
    public class CityBO : ICity
    {
        private readonly DomainContext context;
        private readonly IMapper mapper;

        public CityBO(DomainContext context)
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
        public long Create(CityAM entity)
        {
            try
            {
                var sancion = mapper.Map<City>(entity);

                IRepository<City> repo = new CityRepo(context);
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
                IRepository<City> repo = new CityRepo(context);
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
        public int Count(Expression<Func<CityAM, bool>> predicate)
        {
            try
            {
                var where = mapper.MapExpression<Expression<Func<City, bool>>>(predicate);

                IRepository<City> repo = new CityRepo(context);
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
        public CityAM Get(long id)
        {
            try
            {
                IRepository<City> repo = new CityRepo(context);
                var sancion = repo.Get(id);

                return mapper.Map<CityAM>(sancion);
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
        public List<CityAM> Get()
        {
            try
            {
                IRepository<City> repo = new CityRepo(context);
                var sancion = repo.Get();

                return mapper.Map<List<CityAM>>(sancion);
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
        public List<CityAM> Get(Expression<Func<CityAM, bool>> predicate)
        {
            try
            {
                var where = mapper.MapExpression<Expression<Func<City, bool>>>(predicate);

                IRepository<City> repo = new CityRepo(context);
                var sancion = repo.Get(where);

                return mapper.Map<List<CityAM>>(sancion);
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
        public CityAM GetFirst(Expression<Func<CityAM, bool>> predicate)
        {
            try
            {
                var where = mapper.MapExpression<Expression<Func<City, bool>>>(predicate);

                IRepository<City> repo = new CityRepo(context);
                var sancion = repo.GetFirst(where);

                return mapper.Map<CityAM>(sancion);
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
        public void Update(CityAM entity)
        {
            try
            {
                var sancion = mapper.Map<City>(entity);

                IRepository<City> repo = new CityRepo(context);
                repo.Update(sancion);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message, ex.InnerException);
            }
        }
    }
}
