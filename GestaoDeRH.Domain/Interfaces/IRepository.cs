using GestaoDeRH.Dominio.Base;

namespace GestaoDeRH.Dominio.Interfaces
{
    public interface IRepositorio<T> where T : Entidade
    {
        Task<T> Obter(int id);
        Task<List<T>> Listar();
        Task<T> Salvar(T entity);
        Task Deletar(int id);
    }
}
