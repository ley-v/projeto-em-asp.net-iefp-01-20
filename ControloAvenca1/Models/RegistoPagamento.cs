using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

using System.ComponentModel.DataAnnotations;

namespace ControloAvenca1.Models
{
    public class RegistoPagamento
    {
        public int Id { get; set; }

        [Display(Name = "Data do registo")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime Data { get; set; }
        [Display(Name = "Descrição")]
        public string Descricao { get; set; }

        [Required]
        [Display(Name = "Valor")]
        //[RegularExpression(@"(\d{0,9}\,\d{1,2})|(\d{0,9})", ErrorMessage = "Preenchimento incorreto")]
        public decimal Valor { get; set; }

        [Display(Name = "Cliente")]
        public int ClienteId { get; set; }

        [Display(Name = "Mês")]
        public int MesId { get; set; }

        public virtual Cliente Cliente { get; set; }
        public virtual Mes Mes { get; set; }
    }
}