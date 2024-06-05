#nullable disable
using GestaoDeRH.Dominio.Pessoas;
using GestaoDeRH.Dominio.Recrutamento;

namespace GestaoDeRH.Aplicacao.Recrutamento.DTO
{
    public class VagaDto
    {
        public string Nome { get; set; }
        public decimal FaixaSalarialMin { get; set; }
        public decimal FaixaSalarialMax { get; set; }
        public bool Aberta { get; set; }
        public int ColaboradorId { get; set; }

        internal Vaga CriarEntidade(Colaborador colaboradorCriadorDaVaga)
        {
            return new Vaga
            {
                Nome = Nome,
                Aberta = Aberta,
                FaixaSalarialMax = FaixaSalarialMax,
                FaixaSalarialMin = FaixaSalarialMin,
                AbertaPor = colaboradorCriadorDaVaga
            };

            //TODO: Challenge Cargo esta sendo salvo como null;
        }
    }
}
