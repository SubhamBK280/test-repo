using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TicTacToe.Dto;

namespace TicTacToe.Repositories.Players
{
    public interface IPlayerRepository
    {
        void Create(PlayerDto input);
        List<PlayerDto> GetAllPlayers();
        PlayerDto GetPlayer(int Id);
    }
}
