using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TicTacToe.Dto;
using TicTacToe.Models;
using TicTacToe.Repositories.Players;

namespace TicTacToe.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PlayerController : ControllerBase
    {
       // public readonly ApplicationDbContext _context;
        private readonly IPlayerRepository _repository;
        public PlayerController(IPlayerRepository repository)
        {
            _repository = repository;
        }
        [HttpPost("/api/CreatePlayer")]
        public IActionResult CreatePlayer(PlayerDto input)
        {
            

            _repository.Create(input);
            return Ok("Record inserted Successfully");


        }
        [HttpGet]
        [Route("/api/showAllPlayers")]
        public IActionResult ShowAllPlayers()
        {
           var players= _repository.GetAllPlayers();
            return Ok(players);
        }

        [HttpGet]
        [Route("/api/GetPlayerById")]
        public IActionResult ShowPlayerById(int id)
        {
            var player=_repository.GetPlayer(id);
            return Ok(player);
        }
    }


        
    }

