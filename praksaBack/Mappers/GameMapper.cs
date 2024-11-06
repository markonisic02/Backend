using praksaBack.Dtos.Category;
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
                CategoryId = gameModel.CategoryId,
            };
        }

        public static Game ToGameFromCreate(this CreateGameDto gameDto)
        {
            return new Game
            {
                Title = gameDto.Title,
                Description = gameDto.Description,
                ImageUrl = gameDto.ImageUrl,
                CategoryId = gameDto.CategoryId,
            };
        }

        public static Game ToGameFromUpdate(this UpdateGameRequestDto gamedto)
        {
            return new Game
            {
                Title = gamedto.Title,
                Description = gamedto.Description,
                ImageUrl = gamedto.ImageUrl,
                CategoryId = gamedto.CategoryId
            };
        }
    }
}