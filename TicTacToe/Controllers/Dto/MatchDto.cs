using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TicTacToe.Controllers.Dto
{
    public class MatchDto
    {
        public int FirstPlayerId { get; set; }
        public int SecondPlayerId { get; set; }
        public DateTime? EndTime { get; set; }
       

    }
}
