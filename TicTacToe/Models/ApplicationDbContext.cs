using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TicTacToe.Models
{
    public class ApplicationDbContext:DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options):base(options)
        {

        }
        public DbSet<Player> Players { get; set; }
        public DbSet<Move> Moves { get; set; }
        public DbSet<ScoreBoard> ScoreBoards { get; set; }
        public DbSet<Match> Matches { get; set; }



        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseLazyLoadingProxies();
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Match>(entity =>
            {
                entity.HasOne(d => d.FirstPlayer)
                .WithMany(p => p.MatchesFirstPlayer)
                .HasForeignKey(d => d.FirstPlayerId);
               // .HasConstraintName("FK_dbo.FirstPlayer_dbo.Player_FirstPlayerId");



                entity.HasOne(d => d.SecondPlayer)
                .WithMany(p => p.MatchesSecondPlayer)
                .HasForeignKey(d => d.SecondPlayerId);
                //.HasConstraintName("FK_dbo.SecondPlayer_dbo.Player_SecondPlayerId");
            });

        }

    }
}
