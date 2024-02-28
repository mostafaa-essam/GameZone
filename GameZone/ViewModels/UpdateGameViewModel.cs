using GameZone.Attributes;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace GameZone.ViewModels
{
    public class UpdateGameViewModel
    {
        [MaxLength(255)]
        public string Name { get; set; } = string.Empty;

        public int Id { get; set; }

        [MaxLength(500)]
        public string Desciption { get; set; } = string.Empty;

        [Display(Name = "Category")]
        public int CategoryId { get; set; }

        public IEnumerable<SelectListItem> Categories { get; set; } = Enumerable.Empty<SelectListItem>();
        [Display(Name = "Supported Devices")]

        public List<int> SelectedDevices { get; set; } = default!;
        public IEnumerable<SelectListItem> Devices { get; set; } = Enumerable.Empty<SelectListItem>();

        [AllowedExtensions(FileSettings.AllowedExtensions)]
        [FileMaxSize(FileSettings.MaxFileSizeInByte)]
        public IFormFile? Cover { get; set; } = default!;
        public string? CurrentCover { get; set; }
    }
}
