using System;
using Microsoft.EntityFrameworkCore;
using TypePonto.Models;

namespace TypePonto.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options) { }

        //Lista de propriedades que irão virar tableas no banco

        public DbSet<Funcionario> TabFuncionarios { get; set; }

        public DbSet<Marcacao> TabMarcacoes { get; set; }

    }
}