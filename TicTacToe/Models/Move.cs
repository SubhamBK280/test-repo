using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TicTacToe.Models
{
    public class Move
    {
        public int Id { get; set; }
        public int MatchId { get; set; }
        public int PlayerId { get; set; }
        public int MoveLocation { get; set; }
        public string MoveName { get; set; }

        public virtual Match Match { get; set; }

        public  virtual Player Player { get; set; }

    }
}
