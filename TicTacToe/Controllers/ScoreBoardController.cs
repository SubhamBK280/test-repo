using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TicTacToe.Controllers.Dto;
using TicTacToe.Models;

namespace TicTacToe.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ScoreBoardController : ControllerBase
    {
        public readonly ApplicationDbContext _context;
        public ScoreBoardController(ApplicationDbContext context)
        {
            _context = context;
        }

        [HttpPost]
        [Route("/api/AddScore")]
        public IActionResult AddScore(ScoreBoardDto input)
        {
            _context.ScoreBoards.Add(new ScoreBoard
            {
                MatchId = input.MatchId,
                FirstPlayerScore = input.FirstPlayerScore,
                SecondPlayerScore = input.SecondPlayerScore
            }
            );
            _context.SaveChanges();
            return Ok("Added Succesfully.");
        }

        [HttpGet]
        [Route("/api/showScoreBoard")]
        public IActionResult ShowScoreBoard(int input)
        {
            var query = _context.ScoreBoards.Where(x => x.MatchId == input).FirstOrDefault();
            ScoreBoardDto action = new ScoreBoardDto()
            {
                MatchId = query.MatchId,
                FirstPlayerScore = query.FirstPlayerScore,
                SecondPlayerScore = query.SecondPlayerScore

            };
            return Ok(action);
        }

        [HttpGet]
        [Route("/api/showWinner")]
        public IActionResult ShowWinner(int matchId)
        {

            var scoreCard = _context.ScoreBoards.Where(x => x.MatchId == matchId).FirstOrDefault();
            var matchDetails = _context.Matches.Where(x => x.Id == matchId).FirstOrDefault();
            var winnerPlayer = scoreCard.FirstPlayerScore >= scoreCard.SecondPlayerScore ? matchDetails.FirstPlayer.FirstName : matchDetails.SecondPlayer.FirstName;

           
           

            

           
            return Ok(winnerPlayer);

            
            
            

        }



    }

    }
