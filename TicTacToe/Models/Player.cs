using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TicTacToe.Models
{
    public class Player
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public  string Username { get; set; }
        public string Email { get; set; }

        public virtual ICollection<Match> MatchesFirstPlayer { get; set; }
        public virtual ICollection<Match> MatchesSecondPlayer { get; set; }

        public virtual ICollection<Move> MovesPlayer { get; set; }
        
    }
}
