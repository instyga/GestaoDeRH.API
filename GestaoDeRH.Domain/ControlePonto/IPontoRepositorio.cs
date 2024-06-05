
namespace GestaoDeRH.Dominio.ControlePonto
{
    public interface IPontoRepositorio
    {
        List<Ponto> ListarMarcacoesDePonto(int colaboradorId, DateTime inicio, DateTime fim);
        Task<List<Ponto>> ListarTodasMarcacoesDePontoPorCPF(string cpfColaborador);
    }
}
