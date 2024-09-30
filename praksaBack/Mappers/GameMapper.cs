using praksaBack.Dtos.Game;
using praksaBack.Models;
using System.Runtime.CompilerServices;

namespace praksaBack.Mappers
{
    public static class GameMapper
    {
        public static GameDto ToGameDto(this Game gameModel)
        {
            return new GameDto
            {
                Id = gameModel.Id,
                Title = gameModel.Title,
                Description = gameModel.Description,
                ImageUrl = gameModel.ImageUrl,
                CategoryId = gameModel.CategoryId
            };
        }
    }
}