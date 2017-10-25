using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CinemaAppFeics.Models
{
    public class Filme
    {
        public Filme()
        {
            this.Atores = new List<Ator>();
        }

        public int FilmeID { get; set; }
        public String Titulo { get; set; }
        public decimal Duracao { get; set; }

        //Entidade Relação
        public int SessaoID { get; set; }
        public virtual Sessao Sessoes { get; set; }
        public virtual ICollection<Ator> Atores { get; set; }
    }
}