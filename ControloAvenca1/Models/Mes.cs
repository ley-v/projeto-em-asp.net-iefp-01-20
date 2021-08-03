using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

// --- data annotations ------------------------
using System.ComponentModel.DataAnnotations;


namespace ControloAvenca1.Models
{
    public class Mes
    {
        public int Id { get; set; }

        //private string[] mesDesignacao = { "Janeiro", "Fevereiro", "Março", "Abril", "Maio", "Junho", "Julho", "Agosto", "Setembro", "Outubro", "Novembro", "Dezembro" };
        //public string[] MesDesginacao { get { return mesDesignacao; } }
        [Display(Name = "Mês")]
        public string MesDesginacao { get; set; }
        public virtual ICollection<RegistoPagamento> RegistoPagamento { get; set; }

        
    }
}