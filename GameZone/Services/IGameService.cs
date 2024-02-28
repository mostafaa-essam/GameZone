using GameZone.ViewModels;

namespace GameZone.Services
{
    public interface IGameService
    {
        Task Create(CreateGameViewModel model);
        IEnumerable<Game> GetAll();
        Game? GetById(int id);

        Task<Game?> Update(UpdateGameViewModel model);

        bool Delete(int id);


    }
}
