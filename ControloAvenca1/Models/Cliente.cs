using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ControloAvenca1.Models
{
    public class Cliente
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public string Referencia { get; set; }
        public virtual ICollection<RegistoPagamento> RegistoPagamento { get; set; }
    }
}