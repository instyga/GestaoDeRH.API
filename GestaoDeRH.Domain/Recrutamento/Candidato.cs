#nullable disable

using GestaoDeRH.Dominio.Base;
using GestaoDeRH.Dominio.Pessoas;

namespace GestaoDeRH.Dominio.Recrutamento
{
    public class Candidato : Entidade
    {
        public string Nome { get; set; }
        public string Sobrenome { get; set; }
        public DateTime DataDeNascimento { get; set; }
        /// <summary>
        /// Criar validação para o CPF
        /// </summary>
        public string CPF { get; set; }
        public string RG { get; set; }
        public decimal SalarioPretendido { get; set; }
        public bool Aprovado { get; set; }
        public virtual Vaga VagaAplicada { get; set; }
        public string Email { get; private set; }

        //Challenge criar feature para cadastrar todas as redes sociais de um candidato
        //TODO: Challenge Criar atividade para adicionar uma API de Workflow de processo seletivo, até ser aprovado.
        //Criar feature para não aprovar um candidato mas colocar ele em um banco de talento com uma nota

        public void AprovarCandidatura()
        {
            Aprovado = true;
        }

        public Colaborador CriarColaborador(DateTime dataInicioDoContratoDeTrabalho, decimal salarioNegociado)
        {
            return new Colaborador
            {
                Nome = Nome,
                Sobrenome = Sobrenome,
                CPF = CPF,
                RG = RG,
                DataDeNascimento = DataDeNascimento,
                DataInicioContratoDeTrabalho = dataInicioDoContratoDeTrabalho,
                DataFimContratoDeTrabalho = null,
                Email = Email,
                Salario = salarioNegociado,
                Cargo = VagaAplicada.Cargo
            };
        }
    }
}
