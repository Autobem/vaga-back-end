using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using Api.Domain.Entities;
using Api.Domain.Interfaces;
using Api.InfraData.Context;
using Microsoft.EntityFrameworkCore;

namespace Api.InfraData.Repository
{
    public class BaseRepository<TEntity> : IRepository<TEntity> where TEntity : BaseEntity
    {
        protected readonly Contexto _contexto;
        private DbSet<TEntity> _dataset;
        public BaseRepository(Contexto contexto)
        {
            //contexto vira por injeção
            _contexto = contexto;
            // setando dataset para não precisar sentar a todo o momento
            _dataset = _contexto.Set<TEntity>();
        }

        public async Task<TEntity> AdicionarAsync(TEntity model)
        {
            try
            {
                model.Criacao = DateTime.UtcNow;
                model.Atualizacao = null;

                _dataset.Add(model);
                await _contexto.SaveChangesAsync();
            }
            catch (System.Exception e)
            {
                throw e;
            }

            return model;
        }

        public async Task<TEntity> AtualizarAsync(TEntity model)
        {
            try
            {
                var modelNow = await _dataset.SingleOrDefaultAsync(t => t.Id == model.Id);

                if (modelNow != null)
                {
                    model.Criacao = modelNow.Criacao;
                    model.Atualizacao = DateTime.UtcNow;

                    _contexto.Entry(modelNow).CurrentValues.SetValues(model);

                    await _contexto.SaveChangesAsync();
                }
                else throw new Exception("Código não encontrado nesta base de dados!");
            }
            catch (System.Exception e)
            {
                throw e;
            }

            return model;
        }

        public async Task<int> DeletarAsync(int id)
        {
            try
            {
                var modelNow = await _dataset.SingleOrDefaultAsync(t => t.Id == id);

                if (modelNow != null)
                {
                    _dataset.Remove(modelNow);

                   return await _contexto.SaveChangesAsync();
                }
            }
            catch (System.Exception e)
            {
                throw e;
            }

            return 0;
        }

        public async Task<IEnumerable<TEntity>> GetAsync()
        {
            try
            {
                return await _dataset.ToListAsync<TEntity>();
            }
            catch (System.Exception e)
            {
                throw e;
            }
        }

        public async Task<TEntity> GetAsync(int id)
        {
            try
            {
                return await _dataset.SingleOrDefaultAsync<TEntity>(t => t.Id == id);
            }
            catch (System.Exception e)
            {
                throw e;
            }
        }
    }
}