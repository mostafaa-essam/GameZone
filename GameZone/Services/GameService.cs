using GameZone.Settings;
using GameZone.ViewModels;

namespace GameZone.Services
{
    public class GameService : IGameService
    {
        private readonly ApplicationDbContext _context;
        private readonly IWebHostEnvironment _webHostEnvironment;
        private readonly string _imagesPath;


        public GameService(ApplicationDbContext context, IWebHostEnvironment webHostEnvironment)
        {
            _context = context;
            _webHostEnvironment = webHostEnvironment;
            //3shan a7ded el path el ht5zen feh el sora 3ala el server
            _imagesPath = $"{_webHostEnvironment.WebRootPath}{FileSettings.ImagesPath}";
        }

        public async Task Create(CreateGameViewModel model)
        {
            //save image into the server:-
            var coverName = await SaveCover(model.Cover);
          
            Game game = new()
            {
                Name = model.Name,
                Description = model.Desciption,
                CategoryId = model.CategoryId,
                Cover = coverName,
                GameDevices=model.SelectedDevices.Select(d=>new GameDevice { DevicId=d}).ToList()
            };
            _context.Games.Add(game);
            _context.SaveChanges();
        }

        public bool Delete(int id)
        {
            var isDeleted = false;

            var game=_context.Games.Find(id);
            if (game is null)
                return isDeleted;

            _context.Games.Remove(game);

            var effectedRowed=_context.SaveChanges();
            if(effectedRowed>0)
            {
                isDeleted= true;
                var cover = Path.Combine(_imagesPath, game.Cover);
                File.Delete(cover);
            }

            return isDeleted;
        }

        public IEnumerable<Game> GetAll()
        {
            return _context.Games
                .Include(g=>g.Category)
                .Include(g=>g.GameDevices)
                .ThenInclude(d=>d.Device)
                .AsNoTracking()
                .ToList();
        }

        public Game? GetById(int id)
        {
            return _context.Games
             .Include(g => g.Category)
             .Include(g => g.GameDevices)
             .ThenInclude(d => d.Device)
             .AsNoTracking()
             .SingleOrDefault(g=>g.Id==id);
        }

        public  async Task<Game?> Update(UpdateGameViewModel model)
        {
            var game = _context.Games.Include(g => g.GameDevices)
                                     .SingleOrDefault(g => g.Id == model.Id);
            var hasNewCover = model.Cover is not null;
            var oldCover = game.Cover;
            if(game is null)
                return null;
            game.Name = model.Name;
            game.Description = model.Desciption;
            game.CategoryId = model.CategoryId;
            game.GameDevices = model.SelectedDevices.Select(d=>new GameDevice { DevicId=d})
                                .ToList();
            if(hasNewCover)
                game.Cover=await SaveCover(model.Cover!);

            var effectedRows=_context.SaveChanges();
            if(effectedRows>0)
            {
                if (hasNewCover)
                {
                    var cover = Path.Combine(_imagesPath, oldCover);
                    File.Delete(cover);
                }
                return game;
            }
            else
            {
                return null;
                var cover = Path.Combine(_imagesPath, game.Cover);
                File.Delete(cover);
            }

        }
        private async Task<string> SaveCover(IFormFile cover)
        {
            var coverName = $"{Guid.NewGuid()}{Path.GetExtension(cover.FileName)}";
            var path = Path.Combine(_imagesPath, coverName);
            using var stream = File.Create(path);
            await cover.CopyToAsync(stream);
            return coverName;
        }

    }
}
