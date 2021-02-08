using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TicTacToe.Dto;
using TicTacToe.Models;

namespace TicTacToe.Repositories.Players
{
    public class PlayerRepository : IPlayerRepository
    {
        public readonly ApplicationDbContext _context;
        public PlayerRepository(ApplicationDbContext _context)
        {
            this._context = _context;       
        }
        public void Create(PlayerDto input)
        {
            var emailExist = _context.Players.Where(x => x.Email.ToLower() == input.Email.ToLower()).FirstOrDefault();
            if (emailExist == null)
            {


                var newPlayer = new Player()
                {

                    FirstName = input.FirstName,
                    LastName = input.LastName,
                    Username = input.UserName,
                    Email = input.Email


                };
                _context.Add(newPlayer);
                _context.SaveChanges();

            }


            
           
        }



        public List<PlayerDto> GetAllPlayers()
        {
            List<PlayerDto> playersDto = _context.Players.Select(x => new PlayerDto
            {
                FirstName = x.FirstName,
                LastName = x.LastName,
                Email = x.Email,
                UserName = x.Username
            }).ToList();

            //    List<PlayerDto> playersDto = new List<PlayerDto>();
            //List<Player> players= _context.Players.ToList();
            // foreach(Player player in players)
            // {
            //     playersDto.Add(new PlayerDto
            //     { 
            //         FirstName=player.FirstName,
            //         LastName=player.LastName,
            //         Email=player.Email,
            //         UserName=player.Email
            //     });
            //    }    

            return playersDto;
        }


        public PlayerDto GetPlayer(int Id)
        {
            PlayerDto player = _context.Players
                .Where(x => x.Id == Id)
                .Select(x=>new PlayerDto {
                    FirstName=x.FirstName,
                    LastName=x.LastName,
                    Email=x.Email,
                    UserName=x.Username
                }
                ).FirstOrDefault();
            return player;
        }
        
    }
}
 