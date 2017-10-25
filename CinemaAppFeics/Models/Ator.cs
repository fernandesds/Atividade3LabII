using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CinemaAppFeics.Models
{
    public class Ator
    {
        public Ator()
        {
            this.Filmes = new List<Filme>();
        }

        public int AtorID { get; set; }
        public String Nome { get; set; }

        //Entidade Relação
        public virtual ICollection<Filme> Filmes { get; set; }
    }
}