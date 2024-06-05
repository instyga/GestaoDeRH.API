using GestaoDeRH.Dominio.Recrutamento;
#nullable disable

namespace GestaoDeRH.Aplicacao.Recrutamento.DTO
{
    public class NovoCandidatoDto
    {
        public string Nome { get; set; }
        public string Sobrenome { get; set; }
        public DateTime DataDeNascimento { get; set; }
        public string CPF { get; set; }
        public string RG { get; set; }
        public decimal SalarioPretendido { get; set; }

        public int VagaId { get; set; }

        internal Candidato CriarEntidade(Vaga vagaAplicada)
        {
            return new Candidato
            {
                Nome = Nome,
                Sobrenome = Sobrenome,
                DataDeNascimento = DataDeNascimento,
                CPF = CPF,
                SalarioPretendido = SalarioPretendido,
                Aprovado = false,
                VagaAplicada = vagaAplicada
            };
        }
    }
}
