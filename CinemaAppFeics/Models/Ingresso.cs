using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CinemaAppFeics.Models
{
    public class Ingresso
    {
        public int IngressoID { get; set; }
        public ITipoIngresso Tipo { get; set; }

        //Entidade Relação
        public int SessaoID { get; set; }
        public virtual Sessao Sessao { get; set; }
    }
}