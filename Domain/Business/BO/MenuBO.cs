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

namespace Domain.Business.BO
{
    public class MenuBO: IMenu
    {
        private readonly DomainContext context;
        private readonly IMapper mapper;

        public MenuBO(DomainContext context)
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
        public long Create(MenuAM entity)
        {
            try
            {
                var sancion = mapper.Map<Menu>(entity);

                IRepository<Menu> repo = new MenuRepo(context);
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
                IRepository<Menu> repo = new MenuRepo(context);
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
        public int Count(Expression<Func<MenuAM, bool>> predicate)
        {
            try
            {
                var where = mapper.MapExpression<Expression<Func<Menu, bool>>>(predicate);

                IRepository<Menu> repo = new MenuRepo(context);
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
        public MenuAM Get(long id)
        {
            try
            {
                IRepository<Menu> repo = new MenuRepo(context);
                var sancion = repo.Get(id);

                return mapper.Map<MenuAM>(sancion);
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
        public List<MenuAM> Get()
        {
            try
            {
                IRepository<Menu> repo = new MenuRepo(context);
                var sancion = repo.Get();

                return mapper.Map<List<MenuAM>>(sancion);
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
        public List<MenuAM> Get(Expression<Func<MenuAM, bool>> predicate)
        {
            try
            {
                var where = mapper.MapExpression<Expression<Func<Menu, bool>>>(predicate);

                IRepository<Menu> repo = new MenuRepo(context);
                var sancion = repo.Get(where);

                return mapper.Map<List<MenuAM>>(sancion);
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
        public MenuAM GetFirst(Expression<Func<MenuAM, bool>> predicate)
        {
            try
            {
                var where = mapper.MapExpression<Expression<Func<Menu, bool>>>(predicate);

                IRepository<Menu> repo = new MenuRepo(context);
                var sancion = repo.GetFirst(where);

                return mapper.Map<MenuAM>(sancion);
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
        public void Update(MenuAM entity)
        {
            try
            {
                var sancion = mapper.Map<Menu>(entity);

                IRepository<Menu> repo = new MenuRepo(context);
                repo.Update(sancion);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message, ex.InnerException);
            }
        }
    }
}
