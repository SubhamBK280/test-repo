using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TicTacToe.Controllers.Dto;
using TicTacToe.Models;
using TicTacToe.Repositories.Matches;

namespace TicTacToe.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MatchController : ControllerBase
    {
        private readonly IMatchRepository _repository;
        public MatchController( IMatchRepository repository)
        {
            _repository = repository;
        }
        
        [HttpPost("/api/AddMatch")]
        public void AddMatch(MatchDto Input)
        {
            _repository.CreateMatch(Input);

        }

        [HttpGet]
        [Route("/api/showMatch")]
        public IActionResult ShowMatch(int id)
        {

           var match= _repository.GetMatch(id);
            return Ok(match);
               
            
        }

        [HttpGet]
        [Route("/api/ShowALLMatches")]
        public IActionResult ShowAllMatches()
        {
            var matches=_repository.GetAllMatches();
            return Ok(matches);
        }
        
        [HttpGet]
        [Route("/api/ShowMatchesByIds")]
        public IActionResult ShowMatchesByIds(List<int> ids)
        {
           var matches= _repository.GetMatchByListId(ids);
            return Ok(matches);
        }
        
    }
}
