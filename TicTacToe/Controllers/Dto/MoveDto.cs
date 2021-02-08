using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TicTacToe.Controllers.Dto
{
    public class MoveDto
    {
       public int MatchId { get; set; }
       public int PlayerId { get; set; }
        public int MoveLocation { get; set; }
        public string MoveName { get; set; }
    }
}
