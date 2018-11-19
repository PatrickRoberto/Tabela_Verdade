using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TabelaVerdade
{
    class Entrada
    {
        public string Id { get; }
        bool? Valor { get; set; }

        #region Contrutores

        public Entrada(string id)
        {
            this.Id = id;
        }

        public Entrada(string id, bool val)
        {
            this.Id = id;
            this.Valor = val;
        }
        #endregion


        public void FixarValor(bool v)
        {
            this.Valor = v;
        }

        public void ReiniciarValor()
        {
            this.Valor = null;
        }

    }
}
