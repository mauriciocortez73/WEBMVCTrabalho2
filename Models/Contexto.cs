using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;

namespace WEBMVCTrabalho2.Models
{
    public class Contexto : DbContext
    {
        public Contexto(DbContextOptions<Contexto> options) :
            base(options)
        { }

        public DbSet<Pessoas> Pessoas { get; set; }

        public DbSet<Bancos> Bancos { get; set; }

        public DbSet<Categoria_Gastos> Categoria_Gastos { get; set; }

        public DbSet<Conta_Bancaria> Conta_Bancaria { get; set; }

    }
}
