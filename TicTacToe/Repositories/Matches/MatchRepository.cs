using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TicTacToe.Controllers.Dto;
using TicTacToe.Models;

namespace TicTacToe.Repositories.Matches
{
    public class MatchRepository : IMatchRepository
    {

        private readonly ApplicationDbContext _context;
        public MatchRepository(ApplicationDbContext context)
        {
            _context = context;
        }
        public void CreateMatch(MatchDto input)
        {
            DateTime date=DateTime.Now;
            var match = new Match
            {
                FirstPlayerId=input.FirstPlayerId,
                SecondPlayerId=input.SecondPlayerId,
               StartTime=date
            };
            _context.Matches.Add(match);
            _context.SaveChanges();
            
        }

        public List<MatchDto> GetAllMatches()
        {
            var matches = _context.Matches.Select(x => new MatchDto
            {
                FirstPlayerId=x.FirstPlayerId,
                SecondPlayerId=x.SecondPlayerId,
                EndTime=x.EndTime

            }).ToList();

            return matches;
        }

        public MatchDto GetMatch(int Id)
        {
            var match = _context.Matches.Where(x => x.Id == Id).Select(x => new MatchDto
            {
                FirstPlayerId=x.FirstPlayerId,
                SecondPlayerId=x.SecondPlayerId,
                EndTime=x.EndTime
            }).FirstOrDefault();

            return match;
        }

        public List<MatchDto> GetMatchByListId (List<int> ids)
        {
            //var query= (from match in _context.Matches.ToList()
            //           join id in ids.ToList()
            //           on match.Id equals id
            //           select new MatchDto
            //           {
            //               FirstPlayerId=match.FirstPlayerId,
            //               SecondPlayerId=match.SecondPlayerId

            //           }).ToList();
            //return query;


            var query2 = _context.Matches.Where(x => ids.Contains(x.Id)).Select(x=>new MatchDto { 
            FirstPlayerId=x.FirstPlayerId,
            SecondPlayerId=x.SecondPlayerId
            }).ToList();
            return query2;


            //List<MatchDto> matches = new List<MatchDto>();
            //foreach(int id in ids)
            //{
            //    matches.Add(_context.Matches.Where(x => x.Id == id).Select(x => new MatchDto
            //    {
            //        FirstPlayerId = x.FirstPlayerId,
            //        SecondPlayerId = x.SecondPlayerId,
            //        EndTime = x.EndTime
            //    }
            //     ).FirstOrDefault());
            //}
            //return matches;
        }
    }
}
