using System;
using System.Collections;
using System.Collections.Generic;

namespace TicTacToe.Models
{
    public class Match
    {
        public int Id { get; set; }
        public int FirstPlayerId { get; set; }
        public int SecondPlayerId { get; set; }
        public DateTime StartTime { get; set; }

        public DateTime ?EndTime { get; set; }


        public virtual ICollection<Move> Moves { get; set; }

        public virtual Player FirstPlayer { get; set; }
        public virtual Player SecondPlayer { get; set; }

        //public int ScoreBoardId { get; set; }

        //public virtual ScoreBoard ScoreBoard { get; set; }
    }
}