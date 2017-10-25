using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace CinemaAppFeics.Models
{
    public class Sala
    {
        public Sala()
        {
            this.Sessoes = new List<Sessao>();
        }

        public int SalaID { get; set; }
        public int Numero { get; set; }
        public int Capacidade { get; set; }
        public String Descricao { get; set; }

        //Entidade Relacionada
        public virtual ICollection<Sessao> Sessoes { get; set; }
    }
}