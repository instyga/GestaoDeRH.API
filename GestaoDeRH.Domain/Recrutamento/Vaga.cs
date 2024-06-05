#nullable disable

using GestaoDeRH.Dominio.Base;
using GestaoDeRH.Dominio.Pessoas;

namespace GestaoDeRH.Dominio.Recrutamento
{
    public class Vaga : Entidade
    {
        public string Nome { get; set; }
        public decimal FaixaSalarialMin { get; set; }
        public decimal FaixaSalarialMax { get; set; }
        public bool Aberta { get; set; }
        public string Cargo { get; set; }

        public virtual Colaborador AbertaPor { get; set; }

        public override bool EstaValida(out List<string> erros)
        {
            erros = [];
            if (string.IsNullOrEmpty(Nome))
                erros.Add("Vaga deve ter nome");

            if (AbertaPor == null)
                erros.Add("Vaga deve ser criada por um colaborador.");

            return erros.Count == 0;
        }

        public void FecharVaga()
        {
            Aberta = false;
        }
    }
}
