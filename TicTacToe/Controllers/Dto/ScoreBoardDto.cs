using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TicTacToe.Controllers.Dto
{
    public class ScoreBoardDto
    {
        public int MatchId { get; set; }
        public int FirstPlayerScore { get; set; }
        public int SecondPlayerScore { get; set; }
    }
}
