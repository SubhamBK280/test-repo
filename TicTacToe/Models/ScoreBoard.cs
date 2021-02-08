using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TicTacToe.Models
{
    public class ScoreBoard
    {
        public int Id { get; set; }
        public int MatchId { get; set; }
        public int FirstPlayerScore { get; set; }
        public int SecondPlayerScore { get; set; }
        

        public virtual Match Match { get; set; }
    }
}
