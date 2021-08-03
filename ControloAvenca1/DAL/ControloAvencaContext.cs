using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

using System.Data.Entity;
using ControloAvenca1.Models;

namespace ControloAvenca1.DAL
{
    public class ControloAvencaContext : DbContext
    {
        public DbSet<Cliente> TCliente { get; set; }
        public DbSet<Avenca> TAvenca { get; set; }
        public DbSet<RegistoPagamento> TRegistoPagamento { get; set; }
        public DbSet<Mes> TMes { get; set; }
        public DbSet<Login> TLogin { get; set; }
    }
}