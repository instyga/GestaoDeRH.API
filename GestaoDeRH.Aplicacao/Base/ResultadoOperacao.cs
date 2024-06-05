namespace GestaoDeRH.Aplicacao.Base
{
    public class ResultadoOperacao<T> where T : class
    {
        public T? Dados { get; set; }
        public bool Sucesso
        {
            get
            {
                return Erros.Count == 0;
            }
        }

        public List<string> Erros { get; private set; }

        public ResultadoOperacao()
        {
            Erros = [];
        }

        public void AdicionarErros(List<string> erros)
        {
            if (erros == null)
                return;

            Erros.AddRange(erros);
        }
        //Challenge criar middleware para tratar o resultado operacao com o status http correto.
    }
}
