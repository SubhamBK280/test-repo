using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TicTacToe.Controllers.Dto;

namespace TicTacToe.Repositories.Matches
{
    public interface IMatchRepository
    {
        void CreateMatch(MatchDto input);
        List<MatchDto> GetAllMatches();
        MatchDto GetMatch(int Id);
        List<MatchDto> GetMatchByListId(List<int> Ids);
    }
}
