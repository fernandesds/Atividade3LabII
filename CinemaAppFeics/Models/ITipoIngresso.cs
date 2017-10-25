using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace CinemaAppFeics.Models
{
    public enum ITipoIngresso
    {
        [Display(Name = "Entrada Inteira")]
        Inteiro = 1,

        [Display(Name = "Entrada Meia")]
        Meia = 2
    }
}