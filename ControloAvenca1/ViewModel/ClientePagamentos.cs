using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

using ControloAvenca1.Models;

namespace ControloAvenca1.ViewModel
{
    public class ClientePagamentos
    {
        public IEnumerable<Cliente> Clientes { get; set; }
        public IEnumerable<RegistoPagamento> RegistoPagamentos { get; set; }
        public IEnumerable<Mes> Meses { get; set; }

    }
}