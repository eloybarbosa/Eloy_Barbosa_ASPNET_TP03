using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Eloy_Barbosa_ASPNET_TP03.Models
{
    public class Aniversariante
    {
        public Guid Id { get; set; }

        [Required(ErrorMessage ="Campo precisa ser preenchido")]
        public string Nome { get; set; }
        public string Sobrenome { get; set; }
        public DateTime Nascimento { get; set; }

    }
}
