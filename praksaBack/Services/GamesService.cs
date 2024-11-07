using praksaBack.Dtos.Category;
using praksaBack.Dtos.Game;
using praksaBack.Interfaces;
using praksaBack.Mappers;
using praksaBack.Models;

namespace praksaBack.Services
{
    public class GamesService : IGamesService
    {
        private readonly IGamesRepository _gamesRepository;

        public GamesService(IGamesRepository gamesRepository)
        {
            _gamesRepository = gamesRepository;
        }

        public async Task<List<GameDto>> GetAllAsync()
        {
            var games = await _gamesRepository.GetAllAsync();
            return games.Select(game => game.ToGameDto()).ToList();
        }

        public async Task<GameDto?> GetByIdAsync(int id)
        {
            var game = await _gamesRepository.GetByIdAsync(id);
            if (game == null)
            {
                return null;
            }
            return game.ToGameDto();
        }

        public async Task<GameDto> CreateAsync(CreateGameDto gameModel)
        {
            var game = gameModel.ToGameFromCreate();
            var createdGame = await _gamesRepository.CreateAsync(game);
            return createdGame.ToGameDto();
        }

        public async Task<GameDto?> DeleteAsync(int id)
        {
            var game = await _gamesRepository.DeleteAsync(id);
            if (game == null)
            {
                return null;
            }
            return game.ToGameDto();
        }

        public async Task<GameDto?> UpdateAsync(int id, UpdateGameRequestDto gameModel)
        {
            var game = gameModel.ToGameFromUpdate();
            var updatedGame = await _gamesRepository.UpdateAsync(id, game);
            if (updatedGame == null)
            {
                return null;
            }
            return updatedGame.ToGameDto();
        }

        // Implementacija pretrage igara
        public async Task<List<GameResponse>> SearchAsync(SearchRequest searchTerm)
        {
            return await _gamesRepository.SearchAsync(searchTerm);
        }
    }
}