using Microsoft.EntityFrameworkCore;
using Prueba_Tecnica_BinaSystem.DAL.Repositorios.Contrato;
using Prueba_Tecnica_BinaSystem.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Prueba_Tecnica_BinaSystem.DAL.Repositorios
{
    public class GenericRepository<TModel> : IGenericRepository<TModel> where TModel : class
    {
        private readonly Prueba_Tecnica_BinaSystem_Context _dbcontext;

        public GenericRepository(Prueba_Tecnica_BinaSystem_Context dbcontext)
        {
            _dbcontext = dbcontext;
        }

        public async Task<IQueryable<TModel>> Consultar(Expression<Func<TModel, bool>> filtro = null)
        {
            try
            {
                IQueryable<TModel> queryModelo = filtro == null ? _dbcontext.Set<TModel>() : _dbcontext.Set<TModel>().Where(filtro);
                return queryModelo;
            }
            catch (Exception)
            {

                throw;
            }
        }

        public async Task<TModel> Crear(TModel modelo)
        {
            try
            {
                _dbcontext.Set<TModel>().Add(modelo);
                await _dbcontext.SaveChangesAsync();
                return modelo;
            }
            catch (Exception)
            {

                throw;
            }
        }

        public async Task<bool> Editar(TModel modelo)
        {
            try
            {
                _dbcontext.Set<TModel>().Update(modelo);
                await _dbcontext.SaveChangesAsync();
                return true;
            }
            catch (Exception)
            {

                throw;
            }
        }

        public async Task<bool> Eliminar(TModel modelo)
        {
            try
            {
                _dbcontext.Set<TModel>().Remove(modelo);
                await _dbcontext.SaveChangesAsync();
                return true;
            }
            catch (Exception)
            {

                throw;
            }
        }

        public async Task<TModel> Obtener(Expression<Func<TModel, bool>> filtro)
        {
            try
            {
                TModel modelo = await _dbcontext.Set<TModel>().FirstOrDefaultAsync(filtro);
                return modelo;
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}
