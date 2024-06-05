#nullable disable

using GestaoDeRH.Dominio.Base;
using GestaoDeRH.Dominio.Interfaces;
using GestaoDeRH.Infra.BancoDeDados;
using Microsoft.EntityFrameworkCore;

namespace GestaoDeRH.Infra.Repositorios
{
    public class RepositorioGenerico<T>(GestaoDeRhDbContext dbContext) : IRepositorio<T> where T : Entidade
    {
        protected readonly GestaoDeRhDbContext _dbContext = dbContext;

        public async Task Deletar(int id)
        {
            var entity = await Obter(id);

            if (entity == null)
                return;

            _dbContext.Set<T>().Remove(entity);

            await _dbContext.SaveChangesAsync();
        }

        public async Task<List<T>> Listar()
        {
            return await _dbContext.Set<T>().ToListAsync();
        }

        public async Task<T> Obter(int id)
        {
            return await _dbContext.Set<T>().FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task<T> Salvar(T entity)
        {
            if (entity.Id != default)
                _dbContext.Set<T>().Update(entity);
            else
                await _dbContext.Set<T>().AddAsync(entity);

            await _dbContext.SaveChangesAsync();
            return entity;
        }
    }
}
