using API_Jogame.Domains;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API_Jogame.Context
{
    public class ContextJogame : DbContext
    {
       public DbSet<Jogador> Jogadores { get; set; }
       public DbSet<Jogo> Jogos { get; set; }
       public DbSet<JogoJogador> JogoJogadores { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
                optionsBuilder.UseSqlServer(@"Data source=.\Sqlexpress;Initial Catalog=API-Jogame;user id=sa; password=sa132");
            base.OnConfiguring(optionsBuilder);
        }
    }
}
