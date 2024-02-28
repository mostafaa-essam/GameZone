using Microsoft.AspNetCore.Mvc.Rendering;

namespace GameZone.Services
{
    public class CategoriesService : ICategoriesService
    {
        private readonly ApplicationDbContext _context;

        public CategoriesService(ApplicationDbContext context)
        {
            _context = context;
        }

        public IEnumerable<SelectListItem> GetSelectCategories()
        {
            return _context.Categories
                  .Select(c => new SelectListItem { Value = c.Id.ToString(), Text = c.Name.ToString() })
                  .OrderBy(c => c.Text)
                  .AsNoTracking()
                  .ToList();
        }
    }
}
