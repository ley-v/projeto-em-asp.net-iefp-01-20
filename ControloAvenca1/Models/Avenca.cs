using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

using System.ComponentModel.DataAnnotations;

namespace ControloAvenca1.Models
{
    public class Avenca
    {
        public int Id { get; set; }


        [Required]
        [Display(Name = "Valor")]
        //[RegularExpression("[0-9]+,[0-9]{2}", ErrorMessage = "Preenchimento incorreto")]
        public decimal Valor { get; set; }
        public int ClienteId { get; set; }

        [Display(Name = "Data registoY")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime Data { get; set; }


        public virtual Cliente Cliente { get; set; }

    }
}