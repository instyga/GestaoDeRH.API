using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestaoDeRH.Dominio.Base
{
    public abstract class Entidade
    {
        public int Id { get; set; }

        public virtual bool EstaValida(out List<string> erros)
        {
            erros = [];
            return true;
        }
    }
}
