using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace CinemaAppFeics.Models
{
    public class Sessao
    {
        public Sessao()
        {
            this.Ingressos = new List<Ingresso>();
            this.Filmes = new List<Filme>();
        }

        public int SessaoID { get; set; }
        public DateTime DataHoraInicio { get; set; }
        public DateTime DataHoraFim { get; set; }
        public decimal ValorInteira { get; set; }
        public decimal ValorMeia { get; set; }
        public bool Encerrado { get; set; }

        //Entidade Relação
        public int SalaID { get; set; }
        public virtual Sala Sala { get; set; }
        public virtual ICollection<Ingresso> Ingressos { get; set; }
        public virtual ICollection<Filme> Filmes { get; set; }

    }
}