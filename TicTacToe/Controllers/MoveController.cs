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
    public class MoveController : ControllerBase
    {
        public readonly ApplicationDbContext _context;
        public MoveController(ApplicationDbContext context)
        {
            _context=context;
        }
        [HttpPost]
        [Route("/api/PushMove")]
        public void PushMove(MoveDto Input)
        {
            _context.Moves.Add(
                new Move
                {
                    MatchId=Input.MatchId,
                    PlayerId=Input.PlayerId,
                    MoveLocation=Input.MoveLocation,
                    MoveName=Input.MoveName


                }
                );
            _context.SaveChanges();

        }
        
        [HttpGet]
        [Route("/api/ShowMoves")]
        public IActionResult ShowMoves(int matchId)
        {
            var moves = _context.Moves.Where(x => x.MatchId == matchId).ToList();
            var Player = (from move in moves
                          group move by move.PlayerId into playerProj
                          select new
                          {
                             
                              PlayerId = playerProj.Key,
                              MoveMade =playerProj.Select(x=>x.MoveLocation).ToList()
                              //(from player in playerProj
                              //               group player by player.MoveLocation into moveProj
                              //               select new
                              //               {
                              //                   MoveLocation = moveProj.Key
                                                
                              //               } ).ToList()


                          }).ToList();
            return Ok(Player);

        }

        [HttpGet]
        [Route("/api/ShowAllMoves")]
        public IActionResult ShowAllMoves()
        {
            var moves =(from move in _context.Moves.ToList()
                       group move by  move.MatchId into MoveProj
                       select new
                       {
                           MatchId=MoveProj.Key,
                           MoveDetails= (from move in MoveProj
                                        group move by move.PlayerId into PlayerProj
                                        select new
                                        {

                                            PlayerId = PlayerProj.Key,
                                            MoveValue=PlayerProj.Select(x=>x.MoveName).FirstOrDefault(),
                                            MoveMade = PlayerProj.Select(x => x.MoveLocation).ToList()
                                            

                                        }).ToList()
        }).ToList();

            return Ok(moves);
            

        }

        [HttpGet]
        [Route("/api/MovesId")]
        public IActionResult ShowAllId()
        {
            var moves=_context.Moves.Select(x => x.Id).ToList();

            return Ok(moves);


        }








    }
}